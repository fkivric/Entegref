namespace Entegref
{
    partial class frmStokSinifi
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.chkRenk = new System.Windows.Forms.CheckBox();
            this.chkBeden = new System.Windows.Forms.CheckBox();
            this.grpSinif = new DevExpress.XtraEditors.GroupControl();
            this.cmbsinif6 = new System.Windows.Forms.ComboBox();
            this.cmbsinif5 = new System.Windows.Forms.ComboBox();
            this.cmbsinif4 = new System.Windows.Forms.ComboBox();
            this.cmbsinif3 = new System.Windows.Forms.ComboBox();
            this.cmbsinif2 = new System.Windows.Forms.ComboBox();
            this.cmbsinif1 = new System.Windows.Forms.ComboBox();
            this.grpOzellik = new DevExpress.XtraEditors.GroupControl();
            this.cmbFiyatlandırma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.grpKavala = new System.Windows.Forms.GroupBox();
            this.cmbKavala = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkKavala = new System.Windows.Forms.CheckBox();
            this.grpBeden = new System.Windows.Forms.GroupBox();
            this.cmbBeden = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpSinif)).BeginInit();
            this.grpSinif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOzellik)).BeginInit();
            this.grpOzellik.SuspendLayout();
            this.grpKavala.SuspendLayout();
            this.grpBeden.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(5, 208);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(336, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Seç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // chkRenk
            // 
            this.chkRenk.AutoSize = true;
            this.chkRenk.Location = new System.Drawing.Point(5, 21);
            this.chkRenk.Name = "chkRenk";
            this.chkRenk.Size = new System.Drawing.Size(113, 17);
            this.chkRenk.TabIndex = 0;
            this.chkRenk.Text = "Üründe Renk Var";
            this.chkRenk.UseVisualStyleBackColor = true;
            this.chkRenk.CheckedChanged += new System.EventHandler(this.chkRenk_CheckedChanged);
            // 
            // chkBeden
            // 
            this.chkBeden.AutoSize = true;
            this.chkBeden.Location = new System.Drawing.Point(2, 15);
            this.chkBeden.Name = "chkBeden";
            this.chkBeden.Size = new System.Drawing.Size(119, 17);
            this.chkBeden.TabIndex = 0;
            this.chkBeden.Text = "Üründe Beden Var";
            this.chkBeden.UseVisualStyleBackColor = true;
            this.chkBeden.CheckedChanged += new System.EventHandler(this.chkBeden_CheckedChanged);
            // 
            // grpSinif
            // 
            this.grpSinif.Controls.Add(this.cmbsinif6);
            this.grpSinif.Controls.Add(this.cmbsinif5);
            this.grpSinif.Controls.Add(this.cmbsinif4);
            this.grpSinif.Controls.Add(this.cmbsinif3);
            this.grpSinif.Controls.Add(this.cmbsinif2);
            this.grpSinif.Controls.Add(this.cmbsinif1);
            this.grpSinif.Controls.Add(this.simpleButton1);
            this.grpSinif.Location = new System.Drawing.Point(11, 8);
            this.grpSinif.Name = "grpSinif";
            this.grpSinif.Size = new System.Drawing.Size(348, 245);
            this.grpSinif.TabIndex = 1;
            this.grpSinif.Text = "Ürün Belirle";
            // 
            // cmbsinif6
            // 
            this.cmbsinif6.Enabled = false;
            this.cmbsinif6.FormattingEnabled = true;
            this.cmbsinif6.Location = new System.Drawing.Point(5, 179);
            this.cmbsinif6.Name = "cmbsinif6";
            this.cmbsinif6.Size = new System.Drawing.Size(336, 21);
            this.cmbsinif6.TabIndex = 4;
            // 
            // cmbsinif5
            // 
            this.cmbsinif5.Enabled = false;
            this.cmbsinif5.FormattingEnabled = true;
            this.cmbsinif5.Location = new System.Drawing.Point(5, 147);
            this.cmbsinif5.Name = "cmbsinif5";
            this.cmbsinif5.Size = new System.Drawing.Size(336, 21);
            this.cmbsinif5.TabIndex = 4;
            this.cmbsinif5.SelectedIndexChanged += new System.EventHandler(this.cmbsinif5_SelectedIndexChanged);
            // 
            // cmbsinif4
            // 
            this.cmbsinif4.Enabled = false;
            this.cmbsinif4.FormattingEnabled = true;
            this.cmbsinif4.Location = new System.Drawing.Point(5, 115);
            this.cmbsinif4.Name = "cmbsinif4";
            this.cmbsinif4.Size = new System.Drawing.Size(336, 21);
            this.cmbsinif4.TabIndex = 4;
            this.cmbsinif4.SelectedIndexChanged += new System.EventHandler(this.cmbsinif4_SelectedIndexChanged);
            // 
            // cmbsinif3
            // 
            this.cmbsinif3.Enabled = false;
            this.cmbsinif3.FormattingEnabled = true;
            this.cmbsinif3.Location = new System.Drawing.Point(5, 83);
            this.cmbsinif3.Name = "cmbsinif3";
            this.cmbsinif3.Size = new System.Drawing.Size(336, 21);
            this.cmbsinif3.TabIndex = 4;
            this.cmbsinif3.SelectedIndexChanged += new System.EventHandler(this.cmbsinif3_SelectedIndexChanged);
            // 
            // cmbsinif2
            // 
            this.cmbsinif2.Enabled = false;
            this.cmbsinif2.FormattingEnabled = true;
            this.cmbsinif2.Location = new System.Drawing.Point(5, 51);
            this.cmbsinif2.Name = "cmbsinif2";
            this.cmbsinif2.Size = new System.Drawing.Size(336, 21);
            this.cmbsinif2.TabIndex = 4;
            this.cmbsinif2.SelectedIndexChanged += new System.EventHandler(this.cmbsinif2_SelectedIndexChanged);
            // 
            // cmbsinif1
            // 
            this.cmbsinif1.FormattingEnabled = true;
            this.cmbsinif1.Location = new System.Drawing.Point(5, 19);
            this.cmbsinif1.Name = "cmbsinif1";
            this.cmbsinif1.Size = new System.Drawing.Size(336, 21);
            this.cmbsinif1.TabIndex = 4;
            this.cmbsinif1.SelectedIndexChanged += new System.EventHandler(this.cmbsinif1_SelectedIndexChanged);
            // 
            // grpOzellik
            // 
            this.grpOzellik.Controls.Add(this.cmbFiyatlandırma);
            this.grpOzellik.Controls.Add(this.label3);
            this.grpOzellik.Controls.Add(this.simpleButton2);
            this.grpOzellik.Controls.Add(this.grpKavala);
            this.grpOzellik.Controls.Add(this.grpBeden);
            this.grpOzellik.Controls.Add(this.chkRenk);
            this.grpOzellik.Enabled = false;
            this.grpOzellik.Location = new System.Drawing.Point(367, 8);
            this.grpOzellik.Name = "grpOzellik";
            this.grpOzellik.Size = new System.Drawing.Size(348, 245);
            this.grpOzellik.TabIndex = 4;
            this.grpOzellik.Text = "Ürün Özellikleri";
            // 
            // cmbFiyatlandırma
            // 
            this.cmbFiyatlandırma.Enabled = false;
            this.cmbFiyatlandırma.FormattingEnabled = true;
            this.cmbFiyatlandırma.Location = new System.Drawing.Point(5, 182);
            this.cmbFiyatlandırma.Name = "cmbFiyatlandırma";
            this.cmbFiyatlandırma.Size = new System.Drawing.Size(331, 21);
            this.cmbFiyatlandırma.TabIndex = 4;
            this.cmbFiyatlandırma.SelectedIndexChanged += new System.EventHandler(this.cmbFiyatlandırma_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fiyatlandırma";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(7, 208);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(336, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Seç";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // grpKavala
            // 
            this.grpKavala.Controls.Add(this.cmbKavala);
            this.grpKavala.Controls.Add(this.label2);
            this.grpKavala.Controls.Add(this.chkKavala);
            this.grpKavala.Location = new System.Drawing.Point(5, 104);
            this.grpKavala.Name = "grpKavala";
            this.grpKavala.Size = new System.Drawing.Size(337, 58);
            this.grpKavala.TabIndex = 1;
            this.grpKavala.TabStop = false;
            // 
            // cmbKavala
            // 
            this.cmbKavala.Enabled = false;
            this.cmbKavala.FormattingEnabled = true;
            this.cmbKavala.Location = new System.Drawing.Point(67, 31);
            this.cmbKavala.Name = "cmbKavala";
            this.cmbKavala.Size = new System.Drawing.Size(264, 21);
            this.cmbKavala.TabIndex = 4;
            this.cmbKavala.SelectedIndexChanged += new System.EventHandler(this.cmbKavala_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kavala Adı";
            // 
            // chkKavala
            // 
            this.chkKavala.AutoSize = true;
            this.chkKavala.Location = new System.Drawing.Point(2, 15);
            this.chkKavala.Name = "chkKavala";
            this.chkKavala.Size = new System.Drawing.Size(119, 17);
            this.chkKavala.TabIndex = 0;
            this.chkKavala.Text = "Üründe Kavala Var";
            this.chkKavala.UseVisualStyleBackColor = true;
            this.chkKavala.CheckedChanged += new System.EventHandler(this.chkKavala_CheckedChanged);
            // 
            // grpBeden
            // 
            this.grpBeden.Controls.Add(this.cmbBeden);
            this.grpBeden.Controls.Add(this.label1);
            this.grpBeden.Controls.Add(this.chkBeden);
            this.grpBeden.Enabled = false;
            this.grpBeden.Location = new System.Drawing.Point(5, 42);
            this.grpBeden.Name = "grpBeden";
            this.grpBeden.Size = new System.Drawing.Size(338, 58);
            this.grpBeden.TabIndex = 1;
            this.grpBeden.TabStop = false;
            // 
            // cmbBeden
            // 
            this.cmbBeden.FormattingEnabled = true;
            this.cmbBeden.Location = new System.Drawing.Point(67, 31);
            this.cmbBeden.Name = "cmbBeden";
            this.cmbBeden.Size = new System.Drawing.Size(264, 21);
            this.cmbBeden.TabIndex = 4;
            this.cmbBeden.SelectedIndexChanged += new System.EventHandler(this.cmbBeden_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Beden Adı";
            // 
            // frmStokSinifi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 262);
            this.Controls.Add(this.grpOzellik);
            this.Controls.Add(this.grpSinif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(731, 285);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(731, 285);
            this.Name = "frmStokSinifi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStokSinifi";
            this.Load += new System.EventHandler(this.frmStokSinifi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSinif)).EndInit();
            this.grpSinif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpOzellik)).EndInit();
            this.grpOzellik.ResumeLayout(false);
            this.grpOzellik.PerformLayout();
            this.grpKavala.ResumeLayout(false);
            this.grpKavala.PerformLayout();
            this.grpBeden.ResumeLayout(false);
            this.grpBeden.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.CheckBox chkRenk;
        private System.Windows.Forms.CheckBox chkBeden;
        private DevExpress.XtraEditors.GroupControl grpSinif;
        private DevExpress.XtraEditors.GroupControl grpOzellik;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.GroupBox grpKavala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkKavala;
        private System.Windows.Forms.GroupBox grpBeden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbsinif6;
        private System.Windows.Forms.ComboBox cmbsinif5;
        private System.Windows.Forms.ComboBox cmbsinif4;
        private System.Windows.Forms.ComboBox cmbsinif3;
        private System.Windows.Forms.ComboBox cmbsinif2;
        private System.Windows.Forms.ComboBox cmbsinif1;
        private System.Windows.Forms.ComboBox cmbKavala;
        private System.Windows.Forms.ComboBox cmbBeden;
        private System.Windows.Forms.ComboBox cmbFiyatlandırma;
    }
}