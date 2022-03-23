using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG
{

    /// <summary>
    /// Operacje na katalogu roboczym
    /// </summary>
    /// <see cref="https://docs.microsoft.com/pl-pl/dotnet/standard/io/how-to-copy-directories"/>
    class KatalogRoboczy
    {
        #region Pola
        /// <summary>
        /// Reprezentuje ścieżkę do folderu Moje Dokumenty.
        /// </summary>
        private string zapiszDoMojeDokumenty = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>
        /// Nazwa katalogu roboczego
        /// </summary>
        private string roboczyKatalog;
        /// <summary>
        /// Ścieżka do katalogu roboczego
        /// </summary>
        private string pathToKatalogRoboczy;
        /// <summary>
        /// Nazwa katalogu na kody rabatowe
        /// </summary>
        private string katalogKodyRabatowe;
        /// <summary>
        /// Ścieżka do katalogu na kody rabatowe
        /// </summary>
        private string pathToKatalogKodyRabatowe;
        /// <summary>
        /// Nazwa pliku z kodami rabatowymi
        /// </summary>
        private string plikKodyRabatowe;
        /// <summary>
        /// Ścieżka do pliku z kodami rabatowymi
        /// </summary>
        private string pathToPlikKodyRabatowe;
        #endregion

        #region Właściwości dostępu do pól
        /// <summary>
        /// Ścieżka do katalogu roboczego
        /// </summary>
        public string PathToKatalogRoboczy { get => pathToKatalogRoboczy; set => pathToKatalogRoboczy = value; }
        /// <summary>
        /// Ścieżka do katalogu na kody rabatowe
        /// </summary>
        public string PathToKatalogKodyRabatowe { get => pathToKatalogKodyRabatowe; set => pathToKatalogKodyRabatowe = value; }
        /// <summary>
        /// Nazwa katalogu na kody rabatowe
        /// </summary>
        public string KatalogKodyRabatowe { get => katalogKodyRabatowe; set => katalogKodyRabatowe = value; }
        /// <summary>
        /// Reprezentuje ścieżkę do folderu Moje Dokumenty.
        /// </summary>
        public string ZapiszDoMojeDokumenty { get => zapiszDoMojeDokumenty; set => zapiszDoMojeDokumenty = value; }
        /// <summary>
        /// Nazwa katalogu roboczego
        /// </summary>
        public string RoboczyKatalog { get => roboczyKatalog; set => roboczyKatalog = value; }
        /// <summary>
        /// Nazwa pliku z kodami rabatowymi
        /// </summary>
        public string PlikKodyRabatowe { get => plikKodyRabatowe; set => plikKodyRabatowe = value; }
        /// <summary>
        /// Ścieżka do pliku z kodami rabatowymi
        /// </summary>
        public string PathToPlikKodyRabatowe { get => pathToPlikKodyRabatowe; set => pathToPlikKodyRabatowe = value; }
        #endregion

        /// <summary>
        /// W konstruktorze generuje ścieżki do katalogów.
        /// https://docs.microsoft.com/pl-pl/dotnet/api/system.io.path.combine?view=net-6.0
        /// </summary>
        /// <param name="roboczyKatalog">Podaj nazwę katalogu roboczego</param>
        /// <param name="katalogKodyRabatowe">Podaj nazwę katalogu dla kodów rabatowych</param>
        /// <param name="plikKodyRabatowe">Podaj nzwę pliku z kodami rabatowymi</param>
        /// <exception cref="ArgumentNullException"></exception>
        public KatalogRoboczy(string roboczyKatalog, string katalogKodyRabatowe, string plikKodyRabatowe)
        {
            this.roboczyKatalog = roboczyKatalog ?? throw new ArgumentNullException(nameof(roboczyKatalog));
            this.katalogKodyRabatowe = katalogKodyRabatowe ?? throw new ArgumentNullException(nameof(katalogKodyRabatowe));
            this.plikKodyRabatowe = plikKodyRabatowe ?? throw new ArgumentNullException(nameof(plikKodyRabatowe));

            PathToKatalogRoboczy = Path.Combine(ZapiszDoMojeDokumenty, RoboczyKatalog);
            PathToKatalogKodyRabatowe = Path.Combine(ZapiszDoMojeDokumenty, RoboczyKatalog, KatalogKodyRabatowe);
            PathToPlikKodyRabatowe = Path.Combine(ZapiszDoMojeDokumenty, RoboczyKatalog, KatalogKodyRabatowe, PlikKodyRabatowe);
        }

        /// <summary>
        /// Usuwa zawartość wskazanego katalogu.
        /// </summary>
        /// <param name="pathToFolder">Ścieżka do katalogu.</param>
        /// <seealso cref="https://www.techiedelight.com/delete-all-files-sub-directories-csharp/"/>
        public void DeleteFolderContent(string pathToFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToFolder);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
        }
    }
}