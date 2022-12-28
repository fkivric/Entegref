namespace Entegref
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDil = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.button3 = new System.Windows.Forms.Button();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtGUID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtSecretPhease = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDatabase = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.SQLComboBox = new System.Windows.Forms.ComboBox();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLisansing = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuUserName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifupassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.lblversion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSaniye = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecretPhease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase)).BeginInit();
            this.navigationPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifupassword)).BeginInit();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.cmbDil);
            this.panelControl1.Controls.Add(this.button1);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cmbDil
            // 
            this.cmbDil.FormattingEnabled = true;
            resources.ApplyResources(this.cmbDil, "cmbDil");
            this.cmbDil.Name = "cmbDil";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            resources.ApplyResources(this.navigationFrame1, "navigationFrame1");
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.navigationPage2;
            // 
            // navigationPage1
            // 
            resources.ApplyResources(this.navigationPage1, "navigationPage1");
            this.navigationPage1.Controls.Add(this.button3);
            this.navigationPage1.Controls.Add(this.ultraLabel4);
            this.navigationPage1.Controls.Add(this.ultraLabel3);
            this.navigationPage1.Controls.Add(this.ultraLabel2);
            this.navigationPage1.Controls.Add(this.ultraLabel1);
            this.navigationPage1.Controls.Add(this.txtGUID);
            this.navigationPage1.Controls.Add(this.txtSecretPhease);
            this.navigationPage1.Controls.Add(this.txtDatabase);
            this.navigationPage1.Controls.Add(this.SQLComboBox);
            this.navigationPage1.Name = "navigationPage1";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ultraLabel4
            // 
            resources.ApplyResources(this.ultraLabel4, "ultraLabel4");
            this.ultraLabel4.Name = "ultraLabel4";
            // 
            // ultraLabel3
            // 
            resources.ApplyResources(this.ultraLabel3, "ultraLabel3");
            this.ultraLabel3.Name = "ultraLabel3";
            // 
            // ultraLabel2
            // 
            resources.ApplyResources(this.ultraLabel2, "ultraLabel2");
            this.ultraLabel2.Name = "ultraLabel2";
            // 
            // ultraLabel1
            // 
            resources.ApplyResources(this.ultraLabel1, "ultraLabel1");
            this.ultraLabel1.Name = "ultraLabel1";
            // 
            // txtGUID
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            this.txtGUID.Appearance = appearance1;
            resources.ApplyResources(this.txtGUID, "txtGUID");
            this.txtGUID.Name = "txtGUID";
            this.txtGUID.ReadOnly = true;
            // 
            // txtSecretPhease
            // 
            resources.ApplyResources(this.txtSecretPhease, "txtSecretPhease");
            this.txtSecretPhease.Name = "txtSecretPhease";
            this.txtSecretPhease.ReadOnly = true;
            // 
            // txtDatabase
            // 
            resources.ApplyResources(this.txtDatabase, "txtDatabase");
            this.txtDatabase.Name = "txtDatabase";
            // 
            // SQLComboBox
            // 
            this.SQLComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.SQLComboBox, "SQLComboBox");
            this.SQLComboBox.Name = "SQLComboBox";
            this.SQLComboBox.SelectedIndexChanged += new System.EventHandler(this.SQLComboBox_SelectedIndexChanged);
            // 
            // navigationPage2
            // 
            resources.ApplyResources(this.navigationPage2, "navigationPage2");
            this.navigationPage2.Controls.Add(this.tabControl1);
            this.navigationPage2.Controls.Add(this.metroPanel2);
            this.navigationPage2.Name = "navigationPage2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLisansing);
            this.tabPage1.Controls.Add(this.groupControl1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLisansing
            // 
            resources.ApplyResources(this.txtLisansing, "txtLisansing");
            this.txtLisansing.Name = "txtLisansing";
            this.txtLisansing.ReadOnly = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.bunifuCheckbox1);
            this.groupControl1.Controls.Add(this.bunifuUserName);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.bunifupassword);
            this.groupControl1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Name = "groupControl1";
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.Transparent;
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.bunifuCheckbox1, "bunifuCheckbox1");
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            // 
            // bunifuUserName
            // 
            resources.ApplyResources(this.bunifuUserName, "bunifuUserName");
            this.bunifuUserName.Name = "bunifuUserName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("simpleButton1.Appearance.Font")));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label7.Name = "label7";
            // 
            // bunifupassword
            // 
            resources.ApplyResources(this.bunifupassword, "bunifupassword");
            this.bunifupassword.Name = "bunifupassword";
            this.bunifupassword.PasswordChar = '*';
            this.bunifupassword.Enter += new System.EventHandler(this.ultraTextEditor1_Enter);
            this.bunifupassword.Leave += new System.EventHandler(this.ultraTextEditor1_Leave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.metroPanel2, "metroPanel2");
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // lblversion
            // 
            resources.ApplyResources(this.lblversion, "lblversion");
            this.lblversion.Name = "lblversion";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSaniye
            // 
            resources.ApplyResources(this.lblSaniye, "lblSaniye");
            this.lblSaniye.Name = "lblSaniye";
            // 
            // frmLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ControlBox = false;
            this.Controls.Add(this.lblSaniye);
            this.Controls.Add(this.lblversion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.panelControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmLogin";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationFrame1.PerformLayout();
            this.navigationPage1.ResumeLayout(false);
            this.navigationPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecretPhease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase)).EndInit();
            this.navigationPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifupassword)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtGUID;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSecretPhease;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDatabase;
        private System.Windows.Forms.ComboBox SQLComboBox;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor bunifuUserName;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor bunifupassword;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Label lblversion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtLisansing;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSaniye;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDil;
    }
}