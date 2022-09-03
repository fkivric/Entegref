namespace Entegref
{
    partial class frmDepoAc
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.gridDepo = new DevExpress.XtraGrid.GridControl();
            this.cardViewDepo = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colTrademark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colsVergiDairesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsVergiNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlYeni = new Infragistics.Win.Misc.UltraPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.txtMuhSube = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtDepoCalisan = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDepoDoviz = new DevExpress.XtraEditors.SimpleButton();
            this.btnDepoMuhSube = new DevExpress.XtraEditors.SimpleButton();
            this.btnDepoTipi = new DevExpress.XtraEditors.SimpleButton();
            this.btnDepoCari = new DevExpress.XtraEditors.SimpleButton();
            this.txtDepoMudur = new System.Windows.Forms.TextBox();
            this.txtDepoDoviz = new System.Windows.Forms.TextBox();
            this.txtDepoTipi = new System.Windows.Forms.TextBox();
            this.txtDepoCari = new System.Windows.Forms.TextBox();
            this.txtDepoAdi = new System.Windows.Forms.TextBox();
            this.txtDepoKodu = new System.Windows.Forms.TextBox();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.pnlYeni.ClientArea.SuspendLayout();
            this.pnlYeni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.gridDepo);
            this.ultraTabPageControl1.Controls.Add(this.pnlYeni);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1136, 613);
            // 
            // gridDepo
            // 
            this.gridDepo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDepo.Location = new System.Drawing.Point(416, 0);
            this.gridDepo.MainView = this.cardViewDepo;
            this.gridDepo.Name = "gridDepo";
            this.gridDepo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemPictureEdit1});
            this.gridDepo.Size = new System.Drawing.Size(720, 613);
            this.gridDepo.TabIndex = 4;
            this.gridDepo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardViewDepo});
            // 
            // cardViewDepo
            // 
            this.cardViewDepo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cardViewDepo.CardCaptionFormat = "Depo{0}";
            this.cardViewDepo.CardWidth = 300;
            this.cardViewDepo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTrademark,
            this.colName,
            this.colModification,
            this.colCategory,
            this.colPhoto,
            this.colDescription,
            this.colsVergiDairesi,
            this.colsVergiNo});
            this.cardViewDepo.GridControl = this.gridDepo;
            this.cardViewDepo.Name = "cardViewDepo";
            this.cardViewDepo.OptionsBehavior.FieldAutoHeight = true;
            // 
            // colTrademark
            // 
            this.colTrademark.Caption = "Depo Kodu";
            this.colTrademark.FieldName = "sDepo";
            this.colTrademark.Name = "colTrademark";
            this.colTrademark.Visible = true;
            this.colTrademark.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "depoadi";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colModification
            // 
            this.colModification.FieldName = "firma";
            this.colModification.Name = "colModification";
            this.colModification.Visible = true;
            this.colModification.VisibleIndex = 2;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "depotipi";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 3;
            // 
            // colPhoto
            // 
            this.colPhoto.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.Visible = true;
            this.colPhoto.VisibleIndex = 4;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 110;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Adres";
            this.colDescription.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colDescription.FieldName = "adress";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.PopupFormSize = new System.Drawing.Size(350, 150);
            // 
            // colsVergiDairesi
            // 
            this.colsVergiDairesi.Caption = "Vergi Dairesi";
            this.colsVergiDairesi.FieldName = "sVergiDairesi";
            this.colsVergiDairesi.Name = "colsVergiDairesi";
            this.colsVergiDairesi.Visible = true;
            this.colsVergiDairesi.VisibleIndex = 6;
            // 
            // colsVergiNo
            // 
            this.colsVergiNo.Caption = "Vergi No";
            this.colsVergiNo.FieldName = "sVergiNo";
            this.colsVergiNo.Name = "colsVergiNo";
            this.colsVergiNo.Visible = true;
            this.colsVergiNo.VisibleIndex = 7;
            // 
            // pnlYeni
            // 
            // 
            // pnlYeni.ClientArea
            // 
            this.pnlYeni.ClientArea.Controls.Add(this.label7);
            this.pnlYeni.ClientArea.Controls.Add(this.label8);
            this.pnlYeni.ClientArea.Controls.Add(this.label6);
            this.pnlYeni.ClientArea.Controls.Add(this.simpleButton7);
            this.pnlYeni.ClientArea.Controls.Add(this.txtMuhSube);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoCalisan);
            this.pnlYeni.ClientArea.Controls.Add(this.linkLabel2);
            this.pnlYeni.ClientArea.Controls.Add(this.linkLabel1);
            this.pnlYeni.ClientArea.Controls.Add(this.label5);
            this.pnlYeni.ClientArea.Controls.Add(this.label4);
            this.pnlYeni.ClientArea.Controls.Add(this.label3);
            this.pnlYeni.ClientArea.Controls.Add(this.label2);
            this.pnlYeni.ClientArea.Controls.Add(this.label1);
            this.pnlYeni.ClientArea.Controls.Add(this.btnDepoDoviz);
            this.pnlYeni.ClientArea.Controls.Add(this.btnDepoMuhSube);
            this.pnlYeni.ClientArea.Controls.Add(this.btnDepoTipi);
            this.pnlYeni.ClientArea.Controls.Add(this.btnDepoCari);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoMudur);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoDoviz);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoTipi);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoCari);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoAdi);
            this.pnlYeni.ClientArea.Controls.Add(this.txtDepoKodu);
            this.pnlYeni.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlYeni.Location = new System.Drawing.Point(0, 0);
            this.pnlYeni.Name = "pnlYeni";
            this.pnlYeni.Size = new System.Drawing.Size(416, 613);
            this.pnlYeni.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Kira Dövize Endeksli ise Döviz Tipi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Çalışan Sayısı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sorumlu Yönetici Adı";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Location = new System.Drawing.Point(7, 442);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(75, 23);
            this.simpleButton7.TabIndex = 0;
            this.simpleButton7.Text = "KAYDET";
            // 
            // txtMuhSube
            // 
            this.txtMuhSube.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtMuhSube.InputMask = "nn";
            this.txtMuhSube.Location = new System.Drawing.Point(13, 242);
            this.txtMuhSube.MaxValue = ((short)(99));
            this.txtMuhSube.MinValue = ((short)(0));
            this.txtMuhSube.Name = "txtMuhSube";
            this.txtMuhSube.NonAutoSizeHeight = 22;
            this.txtMuhSube.Nullable = false;
            this.txtMuhSube.NullText = "0";
            this.txtMuhSube.Size = new System.Drawing.Size(242, 22);
            this.txtMuhSube.TabIndex = 4;
            this.txtMuhSube.MaskChanged += new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit.MaskChangedEventHandler(this.ultraMaskedEdit1_MaskChanged);
            // 
            // txtDepoCalisan
            // 
            this.txtDepoCalisan.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtDepoCalisan.InputMask = "nn";
            this.txtDepoCalisan.Location = new System.Drawing.Point(13, 395);
            this.txtDepoCalisan.MaxValue = ((short)(99));
            this.txtDepoCalisan.MinValue = ((short)(0));
            this.txtDepoCalisan.Name = "txtDepoCalisan";
            this.txtDepoCalisan.NonAutoSizeHeight = 22;
            this.txtDepoCalisan.Nullable = false;
            this.txtDepoCalisan.NullText = "0";
            this.txtDepoCalisan.Size = new System.Drawing.Size(41, 22);
            this.txtDepoCalisan.TabIndex = 4;
            this.txtDepoCalisan.MaskChanged += new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit.MaskChangedEventHandler(this.ultraMaskedEdit1_MaskChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel2.Location = new System.Drawing.Point(282, 142);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(17, 21);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            this.linkLabel2.MouseHover += new System.EventHandler(this.linkLabel2_MouseHover);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabel1.Location = new System.Drawing.Point(282, 193);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(17, 21);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.MouseHover += new System.EventHandler(this.linkLabel1_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Muhasebe Şube / Mağaza Kodu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Depo / Mağaza Tipi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Depo / Mağaza Cari Hesap Kodu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Depo / Mağaza Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Depo / Mağaza Kodu";
            // 
            // btnDepoDoviz
            // 
            this.btnDepoDoviz.Location = new System.Drawing.Point(254, 293);
            this.btnDepoDoviz.Name = "btnDepoDoviz";
            this.btnDepoDoviz.Size = new System.Drawing.Size(24, 23);
            this.btnDepoDoviz.TabIndex = 0;
            this.btnDepoDoviz.Text = "...";
            this.btnDepoDoviz.Click += new System.EventHandler(this.btnDepoDoviz_Click);
            // 
            // btnDepoMuhSube
            // 
            this.btnDepoMuhSube.Location = new System.Drawing.Point(254, 242);
            this.btnDepoMuhSube.Name = "btnDepoMuhSube";
            this.btnDepoMuhSube.Size = new System.Drawing.Size(24, 23);
            this.btnDepoMuhSube.TabIndex = 0;
            this.btnDepoMuhSube.Text = "...";
            // 
            // btnDepoTipi
            // 
            this.btnDepoTipi.Location = new System.Drawing.Point(254, 140);
            this.btnDepoTipi.Name = "btnDepoTipi";
            this.btnDepoTipi.Size = new System.Drawing.Size(24, 23);
            this.btnDepoTipi.TabIndex = 0;
            this.btnDepoTipi.Text = "...";
            this.btnDepoTipi.Click += new System.EventHandler(this.btnDepoTipi_Click);
            // 
            // btnDepoCari
            // 
            this.btnDepoCari.Location = new System.Drawing.Point(254, 191);
            this.btnDepoCari.Name = "btnDepoCari";
            this.btnDepoCari.Size = new System.Drawing.Size(24, 23);
            this.btnDepoCari.TabIndex = 0;
            this.btnDepoCari.Text = "...";
            // 
            // txtDepoMudur
            // 
            this.txtDepoMudur.Location = new System.Drawing.Point(13, 344);
            this.txtDepoMudur.Name = "txtDepoMudur";
            this.txtDepoMudur.Size = new System.Drawing.Size(242, 22);
            this.txtDepoMudur.TabIndex = 0;
            // 
            // txtDepoDoviz
            // 
            this.txtDepoDoviz.Location = new System.Drawing.Point(13, 293);
            this.txtDepoDoviz.Name = "txtDepoDoviz";
            this.txtDepoDoviz.Size = new System.Drawing.Size(242, 22);
            this.txtDepoDoviz.TabIndex = 0;
            // 
            // txtDepoTipi
            // 
            this.txtDepoTipi.Location = new System.Drawing.Point(13, 140);
            this.txtDepoTipi.Name = "txtDepoTipi";
            this.txtDepoTipi.ReadOnly = true;
            this.txtDepoTipi.Size = new System.Drawing.Size(242, 22);
            this.txtDepoTipi.TabIndex = 0;
            this.txtDepoTipi.Tag = "0001";
            this.txtDepoTipi.Text = "Sevk & Lojistik Depo";
            // 
            // txtDepoCari
            // 
            this.txtDepoCari.Location = new System.Drawing.Point(13, 191);
            this.txtDepoCari.Name = "txtDepoCari";
            this.txtDepoCari.ReadOnly = true;
            this.txtDepoCari.Size = new System.Drawing.Size(242, 22);
            this.txtDepoCari.TabIndex = 0;
            this.txtDepoCari.Tag = "000000000001";
            this.txtDepoCari.Text = "Netbil Bilgisayar San.Tic.Ltd.Şti";
            // 
            // txtDepoAdi
            // 
            this.txtDepoAdi.Location = new System.Drawing.Point(13, 89);
            this.txtDepoAdi.Name = "txtDepoAdi";
            this.txtDepoAdi.Size = new System.Drawing.Size(396, 22);
            this.txtDepoAdi.TabIndex = 0;
            // 
            // txtDepoKodu
            // 
            this.txtDepoKodu.Location = new System.Drawing.Point(13, 34);
            this.txtDepoKodu.MaxLength = 4;
            this.txtDepoKodu.Name = "txtDepoKodu";
            this.txtDepoKodu.ReadOnly = true;
            this.txtDepoKodu.Size = new System.Drawing.Size(47, 22);
            this.txtDepoKodu.TabIndex = 0;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1136, 613);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.CloseButtonLocation = Infragistics.Win.UltraWinTabs.TabCloseButtonLocation.HeaderArea;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.ShowButtonSeparators = true;
            this.ultraTabControl1.Size = new System.Drawing.Size(1138, 637);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.ultraTabControl1.TabButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013ScrollbarButton;
            this.ultraTabControl1.TabIndex = 5;
            this.ultraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Yeni Depo / Mağaza Kodu Aç";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Depo / Mağaza Transfer Parametreleri";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1136, 613);
            // 
            // frmDepoAc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 637);
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "frmDepoAc";
            this.Text = "frmDepoAc";
            this.Load += new System.EventHandler(this.frmDepoAc_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.pnlYeni.ClientArea.ResumeLayout(false);
            this.pnlYeni.ClientArea.PerformLayout();
            this.pnlYeni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel pnlYeni;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtDepoCalisan;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnDepoMuhSube;
        private DevExpress.XtraEditors.SimpleButton btnDepoTipi;
        private DevExpress.XtraEditors.SimpleButton btnDepoCari;
        private System.Windows.Forms.TextBox txtDepoMudur;
        private System.Windows.Forms.TextBox txtDepoDoviz;
        private System.Windows.Forms.TextBox txtDepoTipi;
        private System.Windows.Forms.TextBox txtDepoCari;
        private System.Windows.Forms.TextBox txtDepoAdi;
        private System.Windows.Forms.TextBox txtDepoKodu;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.ToolTip toolTip1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private DevExpress.XtraGrid.GridControl gridDepo;
        private DevExpress.XtraGrid.Views.Card.CardView cardViewDepo;
        private DevExpress.XtraGrid.Columns.GridColumn colTrademark;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colModification;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoto;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colsVergiDairesi;
        private DevExpress.XtraGrid.Columns.GridColumn colsVergiNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtMuhSube;
        private DevExpress.XtraEditors.SimpleButton btnDepoDoviz;
        private System.Windows.Forms.Label label8;
    }
}