namespace Entegref
{
    partial class frmTrendyol_Create_Item
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
            this.gridUrunler = new DevExpress.XtraGrid.GridControl();
            this.viewUrunler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUrun_Grubu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsUzunNot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSatis_Fiyati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrendyol_Satis_Fiyati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUrunler
            // 
            this.gridUrunler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridUrunler.Location = new System.Drawing.Point(0, 29);
            this.gridUrunler.MainView = this.viewUrunler;
            this.gridUrunler.Name = "gridUrunler";
            this.gridUrunler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridUrunler.Size = new System.Drawing.Size(1280, 663);
            this.gridUrunler.TabIndex = 0;
            this.gridUrunler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewUrunler});
            // 
            // viewUrunler
            // 
            this.viewUrunler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsModel,
            this.colsKodu,
            this.colsAciklama,
            this.colUrun_Grubu,
            this.colMarka,
            this.colsUzunNot,
            this.colSatis_Fiyati,
            this.colTrendyol_Satis_Fiyati,
            this.colDurum,
            this.colKalan,
            this.colKargo});
            this.viewUrunler.GridControl = this.gridUrunler;
            this.viewUrunler.Name = "viewUrunler";
            this.viewUrunler.OptionsBehavior.Editable = false;
            this.viewUrunler.OptionsView.ColumnAutoWidth = false;
            this.viewUrunler.OptionsView.ShowGroupPanel = false;
            this.viewUrunler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.viewUrunler_RowClick);
            // 
            // colsModel
            // 
            this.colsModel.Caption = "Model";
            this.colsModel.FieldName = "sModel";
            this.colsModel.Name = "colsModel";
            this.colsModel.OptionsColumn.AllowEdit = false;
            this.colsModel.Visible = true;
            this.colsModel.VisibleIndex = 0;
            // 
            // colsKodu
            // 
            this.colsKodu.Caption = "Kodu";
            this.colsKodu.FieldName = "sKodu";
            this.colsKodu.Name = "colsKodu";
            this.colsKodu.OptionsColumn.AllowEdit = false;
            this.colsKodu.Visible = true;
            this.colsKodu.VisibleIndex = 1;
            // 
            // colsAciklama
            // 
            this.colsAciklama.Caption = "Aciklama";
            this.colsAciklama.FieldName = "sAciklama";
            this.colsAciklama.Name = "colsAciklama";
            this.colsAciklama.OptionsColumn.AllowEdit = false;
            this.colsAciklama.Visible = true;
            this.colsAciklama.VisibleIndex = 2;
            // 
            // colUrun_Grubu
            // 
            this.colUrun_Grubu.Caption = "Urun Grubu";
            this.colUrun_Grubu.FieldName = "Urun_Grubu";
            this.colUrun_Grubu.Name = "colUrun_Grubu";
            this.colUrun_Grubu.OptionsColumn.AllowEdit = false;
            this.colUrun_Grubu.Visible = true;
            this.colUrun_Grubu.VisibleIndex = 3;
            // 
            // colMarka
            // 
            this.colMarka.Caption = "Marka";
            this.colMarka.FieldName = "Marka";
            this.colMarka.Name = "colMarka";
            this.colMarka.OptionsColumn.AllowEdit = false;
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 4;
            // 
            // colsUzunNot
            // 
            this.colsUzunNot.Caption = "Urun Açıklama";
            this.colsUzunNot.FieldName = "sUzunNot";
            this.colsUzunNot.Name = "colsUzunNot";
            this.colsUzunNot.OptionsColumn.AllowEdit = false;
            this.colsUzunNot.Visible = true;
            this.colsUzunNot.VisibleIndex = 5;
            // 
            // colSatis_Fiyati
            // 
            this.colSatis_Fiyati.Caption = "Satis Fiyati";
            this.colSatis_Fiyati.FieldName = "Satis_Fiyati";
            this.colSatis_Fiyati.Name = "colSatis_Fiyati";
            this.colSatis_Fiyati.OptionsColumn.AllowEdit = false;
            this.colSatis_Fiyati.Visible = true;
            this.colSatis_Fiyati.VisibleIndex = 6;
            // 
            // colTrendyol_Satis_Fiyati
            // 
            this.colTrendyol_Satis_Fiyati.Caption = "Trendyol Satis Fiyati";
            this.colTrendyol_Satis_Fiyati.FieldName = "Trendyol_Satis_Fiyati";
            this.colTrendyol_Satis_Fiyati.Name = "colTrendyol_Satis_Fiyati";
            this.colTrendyol_Satis_Fiyati.OptionsColumn.AllowEdit = false;
            this.colTrendyol_Satis_Fiyati.Visible = true;
            this.colTrendyol_Satis_Fiyati.VisibleIndex = 7;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durum";
            this.colDurum.FieldName = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.OptionsColumn.AllowEdit = false;
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 8;
            // 
            // colKalan
            // 
            this.colKalan.Caption = "Kalan";
            this.colKalan.FieldName = "Kalan";
            this.colKalan.Name = "colKalan";
            this.colKalan.OptionsColumn.AllowEdit = false;
            this.colKalan.Visible = true;
            this.colKalan.VisibleIndex = 9;
            // 
            // colKargo
            // 
            this.colKargo.ColumnEdit = this.repositoryItemComboBox1;
            this.colKargo.FieldName = "cargoCompanyId";
            this.colKargo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colKargo.Name = "colKargo";
            this.colKargo.OptionsColumn.AllowEdit = false;
            this.colKargo.Visible = true;
            this.colKargo.VisibleIndex = 10;
            this.colKargo.Width = 162;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // frmTrendyol_Create_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 692);
            this.Controls.Add(this.gridUrunler);
            this.Name = "frmTrendyol_Create_Item";
            this.Text = "frmTrendyol_Create_Item";
            this.Load += new System.EventHandler(this.frmTrendyol_Create_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridUrunler;
        private DevExpress.XtraGrid.Views.Grid.GridView viewUrunler;
        private DevExpress.XtraGrid.Columns.GridColumn colsModel;
        private DevExpress.XtraGrid.Columns.GridColumn colsKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colsAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colUrun_Grubu;
        private DevExpress.XtraGrid.Columns.GridColumn colMarka;
        private DevExpress.XtraGrid.Columns.GridColumn colsUzunNot;
        private DevExpress.XtraGrid.Columns.GridColumn colSatis_Fiyati;
        private DevExpress.XtraGrid.Columns.GridColumn colTrendyol_Satis_Fiyati;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private DevExpress.XtraGrid.Columns.GridColumn colKalan;
        private DevExpress.XtraGrid.Columns.GridColumn colKargo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}