using System;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VG
{
    public partial class KodyRabatowe : Form
    {

        #region Pola
        /// <summary>
        /// Obsługuje operacje na katalogach roboczych. 
        /// </summary>
        private KatalogRoboczy kr = new KatalogRoboczy("VC", "Kody_rabatowe", "KodyRabatowe.txt");
        /// <summary>
        /// Liczba znaków (zestawu znaków) z których generowyny jest kod 
        /// </summary>
        private int iloscWszystkichZnakow;
        /// <summary>
        ///  Prefix przed kodem
        /// </summary>
        private string prefix;
        /// <summary>
        /// Ile kodów ma być generowanych
        /// </summary>
        private int iloscKodow;
        /// <summary>
        /// Indeks początkowy generowanego kodu
        /// </summary>
        private int startIndex;
        /// <summary>
        /// Indeks ostatniego kodu
        /// </summary>
        private int endIndex;
        /// <summary>
        /// Czy jest to kontynuacja generowania kodów (z istniejącego pliku)
        /// </summary>
        private bool kontynuacja;
        /// <summary>
        /// HashSet na kody rabatowe.
        /// HashSet zawiera tylko unikatowe wpisy.
        /// </summary>
        public HashSet<string> kodyRabatoweHashSet = new HashSet<string>();
        /// <summary>
        /// Zestaw znaków z których mają być losowane kody
        /// </summary>
        private string zestawZnakow;
        /// <summary>
        /// Ilość znaków w kodzie (z ilu znaków ma się składać kod)
        /// </summary>
        private int iloscZnakow;
        /// <summary>
        /// Lista na argumenty do przekazania do BackgroundWorkera
        /// </summary>
        List<object> arguments = new List<object>();
        /// <summary>
        /// Oznaczenie czy anulowano generowanie kodów.
        /// Jeśli tak, a program nie został zamknięty to wygenerowane kody znajdują się jeszcze na liście
        /// co przy ponownym uruchomieniu generowania (w tym samym otwaartym oknie) nie będzie wymuszało
        /// ponownego ładowania kodów z pliku do listy.
        /// </summary>
        private bool isCanceled;
        #endregion

        #region Dostęp do pól
        /// <summary>
        /// Obsługuje operacje na katalogach roboczych. 
        /// </summary>
        internal KatalogRoboczy Kr { get => kr; set => kr = value; }
        /// <summary>
        /// Zestaw znaków z których mają być losowane kody
        /// </summary>
        public string ZestawZnakow { get => zestawZnakow; set => zestawZnakow = value; }
        /// <summary>
        /// Ilość znaków w kodzie (z ilu znaków ma się składać kod)
        /// </summary>
        public int IloscZnakow { get => iloscZnakow; set => iloscZnakow = value; }
        /// <summary>
        /// Liczba znaków (zestawu znaków) z których generowyny jest kod 
        /// </summary>
        public int IloscWszystkichZnakow { get => iloscWszystkichZnakow; set => iloscWszystkichZnakow = value; }
        /// <summary>
        /// Ile kodów ma być generowanych
        /// </summary>
        public int IloscKodow { get => iloscKodow; set => iloscKodow = value; }
        /// <summary>
        /// Indeks początkowy generowanego kodu
        /// </summary>
        public int StartIndex { get => startIndex; set => startIndex = value; }
        /// <summary>
        /// Indeks ostatniego kodu
        /// </summary>
        public int EndIndex { get => endIndex; set => endIndex = value; }
        /// <summary>
        ///  Prefix przed kodem
        /// </summary>
        public string Prefix { get => prefix; set => prefix = value; }
        /// <summary>
        /// Czy jest to kontynuacja generowania kodów (z istniejącego pliku)
        /// </summary>
        public bool Kontynuacja { get => kontynuacja; set => kontynuacja = value; }
        /// <summary>
        /// Metoda Get/Set oznaczenia czy anulowano generowanie kodów.
        /// </summary>
        public bool IsCanceled { get => isCanceled; set => isCanceled = value; }
        #endregion

        /// <summary>
        /// OPIS DZIAŁANIA FUNKCJI
        /// Zestaw znaków: ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789
        /// Maksymalna ilość nzaków: 20
        /// Maksymalna ilość kodów: 5.000.000
        /// 1. Prefix: Zestaw znaków (max 8), który jest wstawiany przed wygenerowanym kodem. Znak (: dwukropek) jest znakiem niedozwolonym w prefiksie.
        /// 2. Jeśli program wykryje istniejący plik (KodyRabatowe) z kodami to wyswietli zapytanie czy kontynuować generowanie kodów
        /// zgodnie z ustawieniami zawartymi w pliku i kolejnym numerem kodu (w takim przypadku bierzące ustawienia są ignorowane na rzecz ustawień zapisanych w pliku).
        /// Powyższa funkcjonalność ma zastosowanie gdy generujemy dużą ilość kodów (np. 50000) i z jakiegość chcemy przerwać generowanie kodów, w takim 
        /// przypadku można anulować generowanie kodów (Opcje->Anuluj generowanie kodów/wczytywanie pliku do listy), wtedy plik z kodami i ustawieniami 
        /// jest zapisywany w katalogu roboczym.
        /// Po zaakceptowaniu kontynuacji generownia kodów w pierwszej kolejności:
        /// a. program ustawia zapisaną konfigurację kodów,
        /// b. następnie ładuje wygenerowane kody z pliku do listy,
        /// c. dalej z listy wcześniej wygenerowane kody ładowane są do okna programu,
        /// d. po załadowaniu wszystkich kodów generowane są nowe kody.
        /// Jeśli proces generowania kodów zostanie anulowany, a okno generatora kodów nie zostało jeszcze zamknięte to uruchamiając 
        /// ponownie generowanie kodów, wygenerowane kody znajdują się w pamięci programu (na liście), w takim przypadku pomijane jest
        /// ładowanie wygenerowanych kodów z pliku co w przypadku dużej liczby kodów znacząco skraca czas kontynuacji generowania nowych kodów.
        /// 3. W przypadku generowania nowej listy kodów plik z dotychczas wygenerowanymi kodami zostanie nadpisany plikiem z nowymi ustawieniami i kodami.
        /// Ważne: Linia konfiguracji jest weryfikowana, nie wolno modyfikować pliku KodyRabatowe.txt ręcznie. 
        /// Opcja Spakuj kody:
        /// Zaznaczenie tej opcji spowoduje spakowanie wygenerowanych kodów do katalogu Kody_rabatowe w katalogu głównym (roboczym) photoBOX
        /// </summary>
        public KodyRabatowe()
        {
            InitializeComponent();

            try
            {
                // SpraKrza czy katalogi istnieją, jeśli nie to je utworzy.
                if (!Directory.Exists(Kr.PathToKatalogKodyRabatowe))
                {
                    Directory.CreateDirectory(Kr.PathToKatalogKodyRabatowe);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Umożliwia odbieranie zdarzenia keyDown na formularzu
            //this.KeyPreview = true;
            //The reason is that when a key is pressed it will go to the control which has focus on the form, as the KeyPreview property of Form is set to False by default.Let us say the cursor is in a TextBox. Now, if the F3 key is pressed it will not go to the Form's KeyDown event and instead it is captured by the TextBox and the KeyDown event of TextBox fires.
            //So, to enable the KeyDown event of Form even when the focus is on any other control, then the KeyPreview property of the Form has to be set to true as explained here
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.form.keypreview.aspx[^]
            //KeyPreview Gets or sets a value indicating whether the form will receive key events before the event is passed to the control that has focus.
            //and under remarks as
            //To handle keyboard events only at the form level and not allow controls to receive keyboard events, set the KeyPressEventArgs.Handled property in your form's KeyPress event handler to true.
            //After setting KeyPreview property the Form's KeyDown event will fire first, then the KeyDown event of the control which has focus will be fired if the KeyPressEventArgs.Handled is not set to true as stated above.

            this.KeyPreview = true;

        }

        #region Menu Opcje
        /// <summary>
        /// Menu - otwórz katalog roboczy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Kr.PathToKatalogRoboczy))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = Kr.PathToKatalogRoboczy,
                    FileName = "explorer.exe",
                };
                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Katalog " + Kr.RoboczyKatalog + " nie istnieje", "Katalog roboczy nie istnieje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Menu - otwórz katalog kody rabatowe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otwórzToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Kr.PathToKatalogRoboczy))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = Kr.PathToKatalogKodyRabatowe,
                    FileName = "explorer.exe",
                };
                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Katalog " + Kr.KatalogKodyRabatowe + " nie istnieje", "Katalog roboczy nie istnieje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void anulujGenerowanieKodówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (generujKodWorker.WorkerSupportsCancellation == true)
                {
                    this.generujKodWorker.CancelAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void anulujWczytywaniePlikuDoListyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadWorker.WorkerSupportsCancellation == true)
                {
                    this.loadWorker.CancelAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Usuwa zawartość (bez folderów) katalogu roboczego (kodów rabatowych).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usuńZawartośćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kr.DeleteFolderContent(Kr.PathToKatalogKodyRabatowe);
        }
        #endregion

        #region Menu Pomoc
        /// <summary>
        /// Lista skrótów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaSkrótówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klawiszologia klawiszologia = new Klawiszologia();
            klawiszologia.ShowDialog();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OProgramie oProgramie = new OProgramie();
            oProgramie.ShowDialog();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            /// Jeśli tak, a program nie został zamknięty to wygenerowane kody znajdują się jeszcze na liście
            /// co przy ponownym uruchomieniu generowania (w tym samym otwaartym oknie) nie będzie wymuszało
            /// ponownego ładowania kodów z pliku do listy.
            if (IsCanceled == false)
            {
                // Wyczyść listę
                kodyRabatoweHashSet.Clear();
            }

            // Wyczyść richTextBox
            richTextBox1.Clear();
            // Pobierz zestaw znaków
            ZestawZnakow = textBox2.Text;
            // Pobierz prefix, usuń zarezerwowany znak (:)
            Prefix = textBox1.Text.Replace(":", "");
            // i zaktualizuj prefix na textBoksie
            textBox1.Text = Prefix;
            // Ilość wszystkich znaków
            IloscWszystkichZnakow = ZestawZnakow.Length;

            // SpraKrź poprawność danych (jest ustawione we właściwościach kontrolki textBox1)
            try
            {
                // Pobierz ilość znaków (długość kodów)
                IloscZnakow = Convert.ToInt32(comboBox1.Text);
                // Pobierz ilość kodów
                IloscKodow = Convert.ToInt32(comboBox2.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show("Tu można wpisać tylko cyfry.\r\n" + error.Message.ToString(), "Błędna wartość.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Warunek dla ilości wprowadzonych kodów i znaków.
            if (IloscZnakow > 20 || IloscKodow > 5000000)
            {
                MessageBox.Show("Maksymalna wartości to\r\n" + "Ilość znaków: 20\r\n" + "Ilość kodów: 5.000.000", "Błędna wartość.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ilość kombinacji
            double iloscKombinacji = Kombinacje(iloscZnakow, IloscWszystkichZnakow);
            // Maksymalna ilość kodów
            double maksymalnaIloscKodow = Math.Round(((iloscKombinacji) * (10) / 100), 0);

            // Ilość kodów nie może być większa od ilości możliwych kombinacji
            if (IloscKodow > iloscKombinacji || IloscKodow > maksymalnaIloscKodow)
            {
                MessageBox.Show("Ilość generowanych kodów nie może być większa od \r\n" + iloscKombinacji + " \r\n aby zachować losowość ustaw maksymalną ilość kodów na: \r\n" + maksymalnaIloscKodow + "  lub zwiększ długość kodu.", "Błędna wartość.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (File.Exists(Kr.PathToPlikKodyRabatowe))
            {
                //SpraKrź hash linii konfiguracji
                DialogResult dialogResult = MessageBox.Show("Wykryto listę z kodami, czy kontynuować generowanie kodów do obecnej listy ?", "Lista z kodami istnieje.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    // Wyciągnij informacje o konfiguracji z pierwszej linii pliku
                    StreamReader readingFile = new StreamReader(Kr.PathToPlikKodyRabatowe);

                    // linia konfiguracji
                    string configLine = readingFile.ReadLine();
                    // tablica wpisów linii konfiguracji (rozdzielona :)
                    string[] configs = configLine.Split(':');
                    readingFile.Close();

                    // Ustawienia pobrane z pierwszej linii pliku z kodami
                    textBox2.Text = configs[0]; // Zestaw znaków
                    textBox1.Text = configs[1]; // Prefix
                    comboBox1.Text = configs[2]; // Ilość znaków
                    comboBox2.Text = configs[3]; // Ilość kodów
                    var encodedConfigLineString = configs[4]; // Hash MD5 z linii konfiguracji

                    // SpraKrza czy hash linii konfiguracji jest zgodny z tym zapisanym wcześniej
                    // (do spraKrzenia czy linia konfiguracji nie została zmodyfikowana ręcznie)
                    // np. hash z ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789::4:10 musi być równy->FAC5833341581F9354E4826722D660F6

                    // 1. Utwórz MD5 z linii konfiguracji
                    byte[] encodedExistingConfigLineByteArray = new UTF8Encoding().GetBytes(configs[0] + ":" + configs[1] + ":" + configs[2] + ":" + configs[3]);
                    byte[] hashMD5ExistingConfigLineByteArray = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedExistingConfigLineByteArray);
                    // 2. Przekonwertuj zapisany wcześniej hash na tablicę byte
                    // string rencodedConfigLineString = configs[4];
                    try
                    {
                        byte[] savedHash = Convert.FromBase64String(configs[4]);
                        // 3. Porównaj hashe
                        // https://docs.microsoft.com/en-us/troubleshoot/dotnet/csharp/compute-hash-values
                        bool bEqual = false;
                        if (hashMD5ExistingConfigLineByteArray.Length == savedHash.Length)
                        {
                            int i = 0;
                            while ((i < hashMD5ExistingConfigLineByteArray.Length) && (hashMD5ExistingConfigLineByteArray[i] == savedHash[i]))
                            {
                                i += 1;
                            }
                            if (i == hashMD5ExistingConfigLineByteArray.Length)
                            {
                                bEqual = true;
                            }
                        }

                        if (bEqual == false)
                        {
                            MessageBox.Show("Linia konfiguracji w pliku KodyRabatowe zawiera błąd.",
                                "Kody rabatowe.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ZestawZnakow = configs[0];
                            Prefix = configs[1];
                            IloscZnakow = Convert.ToInt32(configs[2]);
                            IloscKodow = Convert.ToInt32(configs[3]);

                            // BACKGROUND WORKER Ładowanie z pliku do listy oraz richTextBoxa, jeśli skończy pomyślnie to uruchomi kolejnego BG workera,
                            // który będzie generował kolejne kody
                            if (loadWorker.IsBusy != true)
                            {
                                button1.Enabled = false;
                                toolStripProgressBar1.Visible = true;
                                toolStripStatusLabel1.Text = "";
                                toolStripStatusLabel1.Visible = true;
                                toolStripProgressBar1.Minimum = 1;
                                toolStripProgressBar1.Maximum = IloscKodow;
                                toolStripProgressBar1.Step = 1;
                                anulujWczytywaniePlikuDoListyToolStripMenuItem.Enabled = true;
                                loadWorker.RunWorkerAsync();
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        // Gdy ręcznie usunie się znak z kodu Base64 Lj7qli7WRlCIzj9l/6dMnA== to pojawi się wyjątek.
                        MessageBox.Show("Błąd w sekcji Base64 \r\n " + error.Message.ToString(),
                                        "Kody rabatowe.",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    File.Delete(Kr.PathToPlikKodyRabatowe);

                    if (generujKodWorker.IsBusy != true)
                    {
                        StartIndex = 1;
                        arguments.Insert(0, false);  // Czy kontynuacja generowania kodów
                        arguments.Insert(1, StartIndex); // Od którego indeksu zacząć generowanie
                        arguments.Insert(2, IloscKodow); // Ile kodów pozostało do wygenerowania
                        button1.Enabled = false;
                        //textBox1.Enabled = false;
                        //comboBox1.Enabled = false;
                        //comboBox2.Enabled = false;
                        toolStripProgressBar1.Visible = true;
                        toolStripStatusLabel1.Text = "";
                        toolStripStatusLabel1.Visible = true;
                        toolStripProgressBar1.Minimum = 1;
                        toolStripProgressBar1.Maximum = IloscKodow;
                        toolStripProgressBar1.Step = 1;
                        anulujGenerowanieKodówToolStripMenuItem.Enabled = true;
                        generujKodWorker.RunWorkerAsync(arguments);
                    }
                }
            }
            else
            {
                if (generujKodWorker.IsBusy != true)
                {
                    StartIndex = 1;
                    arguments.Insert(0, false);  // Czy kontynuacja generowania kodów
                    arguments.Insert(1, StartIndex); // Od którego indeksu zacząć generowanie
                    arguments.Insert(2, IloscKodow); // Ile kodów pozostało do wygenerowania
                    button1.Enabled = false;
                    //textBox1.Enabled = false;
                    //comboBox1.Enabled = false;
                    //comboBox2.Enabled = false;
                    toolStripProgressBar1.Visible = true;
                    toolStripStatusLabel1.Text = "";
                    toolStripStatusLabel1.Visible = true;
                    toolStripProgressBar1.Minimum = 1;
                    toolStripProgressBar1.Maximum = IloscKodow;
                    toolStripProgressBar1.Step = 1;
                    anulujGenerowanieKodówToolStripMenuItem.Enabled = true;
                    generujKodWorker.RunWorkerAsync(arguments);
                }
            }
        }
        /// <summary>
        /// Klawisze skrótu dla generowania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KodyRabatowe_KeyDown(object sender, KeyEventArgs e)
        {
            // Status klawisza
            bool controlKeyStatus = false;

            // Jeśli jest wciśnięty klawisz shift to zmienna controlKeyStatus przyjmuje wartość true
            if (Control.ModifierKeys == Keys.Shift)
            {
                controlKeyStatus = true;
            }

            // Shift+R uruchamia akcję kliknięcia w button 1
            if (controlKeyStatus == true)
            {
                // https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.keys?view=net-5.0
                if (e.KeyCode == Keys.R)
                {
                    button1_Click(sender, e);
                }
            }
        }

        #region Generowanie kodów
        /// <summary>
        /// Oblicza silnię.
        /// </summary>
        /// <param name="iloscZnakow"></param>
        /// <returns>Zwraca silnię liczby.</returns>
        public static double Silnia(int iloscZnakow)
        {
            double silnia = 1;
            for (int i = 1; i <= iloscZnakow; i++)
            {
                silnia *= i;
            }
            return silnia;
        }
        /// <summary>
        /// Oblicza ilość kombinacji bez powtórzeń.
        /// Liczby nie mogą się powtarzać oraz kolejność nie jest ważna.
        /// n!/k!(n-k)!
        /// https://www.naukowiec.org/kalkulatory/kombinatoryka.html
        /// </summary>
        /// <param name="k">ile elementów wybierasz</param>
        /// <param name="n">z ilu elementów</param>
        /// <returns>Ilość kombinacji bez powtórzeń</returns>
        public static double Kombinacje(int k, int n)
        {
            double iloscKombinacji;
            double ns = Silnia(n); // n silnia
            double ks = Silnia(k);  // k silnia
            int nk = n - k;
            double nks = Silnia(nk); // n-k silnia
            iloscKombinacji = (ns) / (ks * nks);
            return iloscKombinacji;
        }

        /// <summary>
        /// Generuje kody
        /// </summary>
        /// <param name="prefix">Prefix.</param>
        /// <param name="zestawZnakow">Zestaw znaków z których ma być generowany kod.</param>
        /// <param name="liczbaZnakow">Długoość generowanego kodu.</param>
        /// <param name="parallel">Czy obliczenia mają być wykonywane równolegle.</param>
        /// <returns>Kod promocyjny wraz z prefixem.</returns>
        public static string GenerujKod(string prefix, string zestawZnakow, int liczbaZnakow, bool parallel)
        {
            // Reprezentuje znak jako jednostkę kodu UTF-16.
            // https://docs.microsoft.com/pl-pl/dotnet/api/system.char?view=net-5.0
            var stringChars = new char[liczbaZnakow];

            // Reprezentuje generator liczb losowych, który jest algorytmem, 
            // który tworzy sekwencję numerów, które spełniają pewne wymagania statystyczne losowości.
            var random = new Random();

            // Czy równolegle
            switch (parallel)
            {
                case true:
                    Parallel.For(0, stringChars.Length, i =>
                    {
                        // Dla każdego znaku [i] zwraca losowy znak z zestawu znaków.
                        stringChars[i] = zestawZnakow[random.Next(zestawZnakow.Length)];
                    });
                    break;
                case false:
                    // Dla każdego znaku [i] zwraca losowy znak z zestawu znaków.
                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = zestawZnakow[random.Next(zestawZnakow.Length)];
                    }
                    break;
            }

            var kodRabatowy = new String(stringChars);
            return prefix + kodRabatowy;
        }
        #endregion

        #region BackgroundWorkery
        private void generujKodWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //// Pomiar czasu wykonywanego kodu.
            //// https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?redirectedfrom=MSDN&view=net-5.0
            // Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();

            List<object> arguments = e.Argument as List<object>;
            bool kontynuuj = (bool)arguments[0];
            int number = (int)arguments[1];
            int numberOfCodes = (int)arguments[2];

            // Tablica bajtów zawierająca odpowiadające znakom UTF-8 cyfry dziesiętne
            byte[] encodedConfigLineByteArray = new UTF8Encoding().GetBytes(zestawZnakow + ":" + prefix + ":" + iloscZnakow + ":" + iloscKodow);
            // Tablica 16 bajtów zawierająca liczby dziesiętne odpowiadające liczbom hex
            byte[] hashMD5ConfigLineByteArray = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedConfigLineByteArray);
            // Przekonwertowana powyższa tablica do string z dec->hex. W celu krótszego zapisu użyto Base64
            //string encodedConfigLineString = BitConverter.ToString(hashMD5ConfigLineByteArray).Replace("-", "");
            // Przekonwertowany do Base64 hash z tablicy byte.
            string encodedToBase64ConfigLineString = Convert.ToBase64String(hashMD5ConfigLineByteArray);

            // Jeśli nie jest to kontynuacja generowania kodów to wstaw informacje o konfiguracji do pliku oraz zakodowany hash.
            if (kontynuuj == false)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(Kr.PathToPlikKodyRabatowe))
                    {
                        sw.WriteLine(zestawZnakow + ":" + prefix + ":" + iloscZnakow + ":" + iloscKodow + ":" + encodedToBase64ConfigLineString);
                    }
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message.ToString(), "generujKodWorker_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            do
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Zmienna kod zawiera prefix oraz kod, następnie dodawana jest do HashSeta oraz pliku.
                    var kod = GenerujKod(prefix, ZestawZnakow, IloscZnakow, true);

                    if (kodyRabatoweHashSet.Add(kod) == true) // HashSet zwraca true gdy dodajemy unikatową wartość, false gdy kod jest już na liście.
                    {

                        using (StreamWriter sw = File.AppendText(Kr.PathToPlikKodyRabatowe))
                        {
                            sw.WriteLine(number + ":" + kod);
                        }
                        richTextBox1.Invoke(new Action(() => richTextBox1.AppendText(Convert.ToString(number) + " : " + kod + "\n")));
                        worker.ReportProgress(number);
                        number++;
                    }
                }

            } while (number <= numberOfCodes);

            //foreach (var item in kodyRabatoweHashSet)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            // stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);
        }
        private void generujKodWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = ("Generuję kody " + e.ProgressPercentage.ToString() + "/" + IloscKodow.ToString());
            toolStripProgressBar1.Value = e.ProgressPercentage;

        }
        private void generujKodWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = "Anulowano generowanie kodów.";
                toolStripProgressBar1.Visible = false;
                button1.Enabled = true;
                anulujGenerowanieKodówToolStripMenuItem.Enabled = false;
                IsCanceled = true;
            }
            else
            {
                toolStripStatusLabel1.Text = "Kody wygenerowane.";
                toolStripProgressBar1.Visible = false;
                button1.Enabled = true;
                //textBox1.Enabled = true;
                //comboBox1.Enabled = true;
                //comboBox2.Enabled = true;
                anulujGenerowanieKodówToolStripMenuItem.Enabled = false;

                //https://docs.microsoft.com/pl-pl/dotnet/api/system.io.compression.zipfile?view=net-5.0
                if (checkBox1.Checked)
                {
                    if (File.Exists(Kr.PathToKatalogKodyRabatowe + ".zip"))
                    {
                        File.Delete(Kr.PathToKatalogKodyRabatowe + ".zip");
                    }
                    try
                    {
                        ZipFile.CreateFromDirectory(Kr.PathToKatalogKodyRabatowe, Kr.PathToKatalogKodyRabatowe + ".zip", CompressionLevel.Optimal, false);

                    }
                    catch (Exception error)
                    {

                        MessageBox.Show(error.Message.ToString(),
                            "Pakowanie", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                    }
                }

                IsCanceled = false;
            }
            arguments.Clear();
        }
        /// <summary>
        /// Ładuje zawartość pliku do listy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // Jeśli lista z kodami jest pusta
            if (kodyRabatoweHashSet.Count == 0)
            {
                // Tablica zawierająca linie (index:kod) z pliku .txt 
                string[] fileLine = File.ReadAllLines(Kr.PathToPlikKodyRabatowe);
                // Każdą linię rozbija po ":" i dodaje kod do listy z kodami 
                for (int i = 1; i < fileLine.Length; i++)
                {

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        string[] data = fileLine[i].Split(':');
                        kodyRabatoweHashSet.Add(data[1]);
                        richTextBox1.Invoke(new Action(() => richTextBox1.AppendText(fileLine[i] + "\r\n")));
                        worker.ReportProgress(i);
                    }
                }

                // Ustawia od którego indeksu rozpocząć generowanie kodów.
                StartIndex = fileLine.Length;

            }
            else
            {
                // Ustawia od którego indeksu rozpocząć generowanie kodów (ilość znajdujących się kodów + 1- aby index się nie zduplikował).
                StartIndex = kodyRabatoweHashSet.Count + 1;
            }
        }
        private void loadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = ("Ładuję kody z pliku do listy " + e.ProgressPercentage.ToString() + "/" + IloscKodow.ToString());
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }
        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Musi być spraKrzenie czy nie anulowano tego bgworkera w przeciwnym wypadku po 
            // anulowaniu tego bgworkera uruchomi kolejny (czyli generowanie kodów).
            if (e.Cancelled != true)
            {
                // Uruchom kontynuowanie generowania kodów jeśli ich zadeklarowana ilość w pliku jest mniejsza od ilości wygenerowanej
                if (StartIndex < IloscKodow)
                {
                    anulujWczytywaniePlikuDoListyToolStripMenuItem.Enabled = false;
                    if (generujKodWorker.IsBusy != true)
                    {
                        arguments.Insert(0, true);  // Czy kontynuacja generowania kodów
                        arguments.Insert(1, StartIndex); // Od którego indeksu zacząć generowanie
                        arguments.Insert(2, IloscKodow); // Ile kodów pozostało do wygenerowania
                        button1.Enabled = false;
                        //textBox1.Enabled = false;
                        //comboBox1.Enabled = false;
                        //comboBox2.Enabled = false;
                        anulujGenerowanieKodówToolStripMenuItem.Enabled = true;
                        toolStripProgressBar1.Visible = true;
                        toolStripStatusLabel1.Text = "";
                        toolStripStatusLabel1.Visible = true;
                        toolStripProgressBar1.Minimum = StartIndex;
                        toolStripProgressBar1.Maximum = IloscKodow;
                        toolStripProgressBar1.Step = 1;
                        generujKodWorker.RunWorkerAsync(arguments);
                    }
                }
                else
                {
                    button1.Enabled = true;
                    //textBox1.Enabled = true;
                    //comboBox1.Enabled = true;
                    //comboBox2.Enabled = true;
                    toolStripProgressBar1.Visible = false;
                    toolStripStatusLabel1.Text = "Kody z pliku wczytane do listy.";
                    anulujWczytywaniePlikuDoListyToolStripMenuItem.Enabled = false;

                    MessageBox.Show("Plik nie wymagał generowania kodów ponieważ lista zawiera określoną liczbę kodów.",
                        "Ładowanie kodów do listy.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                button1.Enabled = true;
                //textBox1.Enabled = true;
                //comboBox1.Enabled = true;
                //comboBox2.Enabled = true;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Text = "Anulowano wczytywanie kodów z pliku do listy.";
                anulujWczytywaniePlikuDoListyToolStripMenuItem.Enabled = false;
            }
        }
        #endregion
    }
}
