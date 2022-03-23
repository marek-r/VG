namespace VG
{
    partial class KodyRabatowe
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KodyRabatowe));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anulujGenerowanieKodówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.katalogRoboczyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kodyRabatoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńZawartośćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaSkrótówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.generujKodWorker = new System.ComponentModel.BackgroundWorker();
            this.loadWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcjeToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anulujGenerowanieKodówToolStripMenuItem,
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem,
            this.katalogRoboczyToolStripMenuItem});
            this.opcjeToolStripMenuItem.Image = global::VG.Properties.Resources.options_2;
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // anulujGenerowanieKodówToolStripMenuItem
            // 
            this.anulujGenerowanieKodówToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.anulujGenerowanieKodówToolStripMenuItem.Enabled = false;
            this.anulujGenerowanieKodówToolStripMenuItem.Image = global::VG.Properties.Resources.Cancel;
            this.anulujGenerowanieKodówToolStripMenuItem.Name = "anulujGenerowanieKodówToolStripMenuItem";
            this.anulujGenerowanieKodówToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.anulujGenerowanieKodówToolStripMenuItem.Text = "Anuluj generowanie kodów";
            this.anulujGenerowanieKodówToolStripMenuItem.Click += new System.EventHandler(this.anulujGenerowanieKodówToolStripMenuItem_Click);
            // 
            // anulujWczytywaniePlikuDoListyToolStripMenuItem
            // 
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.Enabled = false;
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.Image = global::VG.Properties.Resources.Cancel;
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.Name = "anulujWczytywaniePlikuDoListyToolStripMenuItem";
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.Text = "Anuluj wczytywanie pliku do listy";
            this.anulujWczytywaniePlikuDoListyToolStripMenuItem.Click += new System.EventHandler(this.anulujWczytywaniePlikuDoListyToolStripMenuItem_Click);
            // 
            // katalogRoboczyToolStripMenuItem
            // 
            this.katalogRoboczyToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.katalogRoboczyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.kodyRabatoweToolStripMenuItem});
            this.katalogRoboczyToolStripMenuItem.Image = global::VG.Properties.Resources.upcoming_work1;
            this.katalogRoboczyToolStripMenuItem.Name = "katalogRoboczyToolStripMenuItem";
            this.katalogRoboczyToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.katalogRoboczyToolStripMenuItem.Text = "Katalog roboczy";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.otwórzToolStripMenuItem.Image = global::VG.Properties.Resources.Folder_with_Contents;
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // kodyRabatoweToolStripMenuItem
            // 
            this.kodyRabatoweToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.kodyRabatoweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem1,
            this.usuńZawartośćToolStripMenuItem});
            this.kodyRabatoweToolStripMenuItem.Image = global::VG.Properties.Resources.Documents1;
            this.kodyRabatoweToolStripMenuItem.Name = "kodyRabatoweToolStripMenuItem";
            this.kodyRabatoweToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.kodyRabatoweToolStripMenuItem.Text = "Kody rabatowe";
            // 
            // otwórzToolStripMenuItem1
            // 
            this.otwórzToolStripMenuItem1.Image = global::VG.Properties.Resources.Folder_with_Contents;
            this.otwórzToolStripMenuItem1.Name = "otwórzToolStripMenuItem1";
            this.otwórzToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.otwórzToolStripMenuItem1.Size = new System.Drawing.Size(222, 22);
            this.otwórzToolStripMenuItem1.Text = "Otwórz";
            this.otwórzToolStripMenuItem1.Click += new System.EventHandler(this.otwórzToolStripMenuItem1_Click);
            // 
            // usuńZawartośćToolStripMenuItem
            // 
            this.usuńZawartośćToolStripMenuItem.Image = global::VG.Properties.Resources.File_Delete;
            this.usuńZawartośćToolStripMenuItem.Name = "usuńZawartośćToolStripMenuItem";
            this.usuńZawartośćToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.usuńZawartośćToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.usuńZawartośćToolStripMenuItem.Text = "Usuń zawartość";
            this.usuńZawartośćToolStripMenuItem.Click += new System.EventHandler(this.usuńZawartośćToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaSkrótówToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1});
            this.pomocToolStripMenuItem.Image = global::VG.Properties.Resources.Help;
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // listaSkrótówToolStripMenuItem
            // 
            this.listaSkrótówToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.listaSkrótówToolStripMenuItem.Image = global::VG.Properties.Resources.preferences_desktop_keyboard_shortcuts;
            this.listaSkrótówToolStripMenuItem.Name = "listaSkrótówToolStripMenuItem";
            this.listaSkrótówToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.listaSkrótówToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.listaSkrótówToolStripMenuItem.Text = "Lista skrótów";
            this.listaSkrótówToolStripMenuItem.Click += new System.EventHandler(this.listaSkrótówToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.AliceBlue;
            this.toolStripMenuItem1.Image = global::VG.Properties.Resources.help_about;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem1.Text = "O programie";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(549, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // generujKodWorker
            // 
            this.generujKodWorker.WorkerReportsProgress = true;
            this.generujKodWorker.WorkerSupportsCancellation = true;
            this.generujKodWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.generujKodWorker_DoWork);
            this.generujKodWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.generujKodWorker_ProgressChanged);
            this.generujKodWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.generujKodWorker_RunWorkerCompleted);
            // 
            // loadWorker
            // 
            this.loadWorker.WorkerReportsProgress = true;
            this.loadWorker.WorkerSupportsCancellation = true;
            this.loadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadWorker_DoWork);
            this.loadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.loadWorker_ProgressChanged);
            this.loadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadWorker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ilość znaków";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ilość kodów";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Zestaw znaków";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 58);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(122, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(415, 13);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox1.Location = new System.Drawing.Point(122, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "4";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "500",
            "1000",
            "1500",
            "2000",
            "2500",
            "3000",
            "3500",
            "4000",
            "4500",
            "5000",
            "10000",
            "20000",
            "30000",
            "40000",
            "50000",
            "75000",
            "100000"});
            this.comboBox2.Location = new System.Drawing.Point(122, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.Text = "10";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(61, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Spakuj kody";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VG.Properties.Resources.zip_room_9793;
            this.pictureBox1.Location = new System.Drawing.Point(15, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(212, 58);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(325, 268);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VG.Properties.Resources.play_1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(420, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.DarkRed;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // KodyRabatowe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(549, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KodyRabatowe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator kodów rabatowych";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KodyRabatowe_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker generujKodWorker;
        private System.ComponentModel.BackgroundWorker loadWorker;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anulujGenerowanieKodówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anulujWczytywaniePlikuDoListyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem katalogRoboczyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kodyRabatoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuńZawartośćToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaSkrótówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

