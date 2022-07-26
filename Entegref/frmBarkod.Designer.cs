namespace Entegref
{
    partial class frmBarkod
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBarkodSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnBarkodIslem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtFirmaStokAd = new System.Windows.Forms.TextBox();
            this.txtFirmaStokKod = new System.Windows.Forms.TextBox();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridBarkod = new DevExpress.XtraGrid.GridControl();
            this.ViewBarkod = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BarkodsBarkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BarkodsFirmaKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BarkodsKarsiStokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BarkodsKarsiStokAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBarkod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBarkod)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBarkodSil);
            this.panel1.Controls.Add(this.btnBarkodIslem);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.txtFirmaStokAd);
            this.panel1.Controls.Add(this.txtFirmaStokKod);
            this.panel1.Controls.Add(this.txtFirma);
            this.panel1.Controls.Add(this.txtBarkod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 85);
            this.panel1.TabIndex = 0;
            // 
            // btnBarkodSil
            // 
            this.btnBarkodSil.Location = new System.Drawing.Point(450, 56);
            this.btnBarkodSil.Name = "btnBarkodSil";
            this.btnBarkodSil.Size = new System.Drawing.Size(425, 23);
            this.btnBarkodSil.TabIndex = 6;
            this.btnBarkodSil.Text = "Yeni";
            this.btnBarkodSil.Click += new System.EventHandler(this.btnBarkodSil_Click);
            // 
            // btnBarkodIslem
            // 
            this.btnBarkodIslem.Location = new System.Drawing.Point(13, 56);
            this.btnBarkodIslem.Name = "btnBarkodIslem";
            this.btnBarkodIslem.Size = new System.Drawing.Size(425, 23);
            this.btnBarkodIslem.TabIndex = 6;
            this.btnBarkodIslem.Text = "Ekle";
            this.btnBarkodIslem.Click += new System.EventHandler(this.btnBarkodIslem_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(465, 30);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(20, 20);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Firma Stok Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Firma Stok Kodu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Firma kodu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barkod";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(125, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "EAN13 Standardında";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtFirmaStokAd
            // 
            this.txtFirmaStokAd.Location = new System.Drawing.Point(635, 31);
            this.txtFirmaStokAd.Name = "txtFirmaStokAd";
            this.txtFirmaStokAd.Size = new System.Drawing.Size(240, 20);
            this.txtFirmaStokAd.TabIndex = 5;
            // 
            // txtFirmaStokKod
            // 
            this.txtFirmaStokKod.Location = new System.Drawing.Point(494, 30);
            this.txtFirmaStokKod.Name = "txtFirmaStokKod";
            this.txtFirmaStokKod.Size = new System.Drawing.Size(135, 20);
            this.txtFirmaStokKod.TabIndex = 4;
            // 
            // txtFirma
            // 
            this.txtFirma.Location = new System.Drawing.Point(334, 30);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(129, 20);
            this.txtFirma.TabIndex = 2;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(144, 30);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(184, 20);
            this.txtBarkod.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridBarkod);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 365);
            this.panel2.TabIndex = 0;
            // 
            // gridBarkod
            // 
            this.gridBarkod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBarkod.Location = new System.Drawing.Point(0, 0);
            this.gridBarkod.MainView = this.ViewBarkod;
            this.gridBarkod.Name = "gridBarkod";
            this.gridBarkod.Size = new System.Drawing.Size(878, 365);
            this.gridBarkod.TabIndex = 0;
            this.gridBarkod.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewBarkod});
            // 
            // ViewBarkod
            // 
            this.ViewBarkod.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BarkodsBarkod,
            this.BarkodsFirmaKodu,
            this.BarkodsKarsiStokKodu,
            this.BarkodsKarsiStokAciklama});
            this.ViewBarkod.GridControl = this.gridBarkod;
            this.ViewBarkod.Name = "ViewBarkod";
            this.ViewBarkod.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ViewBarkod_RowCellClick);
            // 
            // BarkodsBarkod
            // 
            this.BarkodsBarkod.Caption = "Stok Barkod";
            this.BarkodsBarkod.FieldName = "sBarkod";
            this.BarkodsBarkod.Name = "BarkodsBarkod";
            this.BarkodsBarkod.OptionsColumn.AllowEdit = false;
            this.BarkodsBarkod.Visible = true;
            this.BarkodsBarkod.VisibleIndex = 0;
            this.BarkodsBarkod.Width = 220;
            // 
            // BarkodsFirmaKodu
            // 
            this.BarkodsFirmaKodu.Caption = "Firma Kodu";
            this.BarkodsFirmaKodu.FieldName = "sFirmaKodu";
            this.BarkodsFirmaKodu.Name = "BarkodsFirmaKodu";
            this.BarkodsFirmaKodu.OptionsColumn.AllowEdit = false;
            this.BarkodsFirmaKodu.Visible = true;
            this.BarkodsFirmaKodu.VisibleIndex = 1;
            this.BarkodsFirmaKodu.Width = 210;
            // 
            // BarkodsKarsiStokKodu
            // 
            this.BarkodsKarsiStokKodu.Caption = "Karsi Stok Kodu";
            this.BarkodsKarsiStokKodu.FieldName = "sKarsiStokKodu";
            this.BarkodsKarsiStokKodu.Name = "BarkodsKarsiStokKodu";
            this.BarkodsKarsiStokKodu.OptionsColumn.AllowEdit = false;
            this.BarkodsKarsiStokKodu.Visible = true;
            this.BarkodsKarsiStokKodu.VisibleIndex = 2;
            this.BarkodsKarsiStokKodu.Width = 210;
            // 
            // BarkodsKarsiStokAciklama
            // 
            this.BarkodsKarsiStokAciklama.Caption = "sKarsi Stok Aciklama";
            this.BarkodsKarsiStokAciklama.FieldName = "sKarsiStokAciklama";
            this.BarkodsKarsiStokAciklama.Name = "BarkodsKarsiStokAciklama";
            this.BarkodsKarsiStokAciklama.OptionsColumn.AllowEdit = false;
            this.BarkodsKarsiStokAciklama.Visible = true;
            this.BarkodsKarsiStokAciklama.VisibleIndex = 3;
            this.BarkodsKarsiStokAciklama.Width = 213;
            // 
            // frmBarkod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBarkod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmBarkod";
            this.Load += new System.EventHandler(this.fmBarkod_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBarkod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBarkod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridBarkod;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtFirmaStokAd;
        private System.Windows.Forms.TextBox txtFirmaStokKod;
        private System.Windows.Forms.TextBox txtFirma;
        private DevExpress.XtraEditors.SimpleButton btnBarkodIslem;
        private DevExpress.XtraGrid.Columns.GridColumn BarkodsBarkod;
        private DevExpress.XtraGrid.Columns.GridColumn BarkodsFirmaKodu;
        private DevExpress.XtraGrid.Columns.GridColumn BarkodsKarsiStokKodu;
        private DevExpress.XtraGrid.Columns.GridColumn BarkodsKarsiStokAciklama;
        private DevExpress.XtraEditors.SimpleButton btnBarkodSil;
    }
}