namespace Entegref
{
    partial class frmFiyatTipi
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
            this.gridFiyatTipi = new DevExpress.XtraGrid.GridControl();
            this.ViewFiyatTipi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FiyatTipiFipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FiyatTipiAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FiyatTipiHangiFislerde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FiyatTipiKdvDahil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FiyatTipiDovizBaglı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FiyatTipiLookUp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiyatTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewFiyatTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFiyatTipi
            // 
            this.gridFiyatTipi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFiyatTipi.Location = new System.Drawing.Point(0, 0);
            this.gridFiyatTipi.MainView = this.ViewFiyatTipi;
            this.gridFiyatTipi.Name = "gridFiyatTipi";
            this.gridFiyatTipi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridFiyatTipi.Size = new System.Drawing.Size(800, 450);
            this.gridFiyatTipi.TabIndex = 23;
            this.gridFiyatTipi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewFiyatTipi});
            // 
            // ViewFiyatTipi
            // 
            this.ViewFiyatTipi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FiyatTipiFipi,
            this.FiyatTipiAciklama,
            this.FiyatTipiHangiFislerde,
            this.FiyatTipiKdvDahil,
            this.FiyatTipiDovizBaglı,
            this.FiyatTipiLookUp});
            this.ViewFiyatTipi.GridControl = this.gridFiyatTipi;
            this.ViewFiyatTipi.Name = "ViewFiyatTipi";
            this.ViewFiyatTipi.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.ViewFiyatTipi.OptionsFind.ClearFindOnClose = false;
            this.ViewFiyatTipi.OptionsFind.SearchInPreview = true;
            this.ViewFiyatTipi.OptionsFind.ShowClearButton = false;
            this.ViewFiyatTipi.OptionsView.ShowAutoFilterRow = true;
            this.ViewFiyatTipi.OptionsView.ShowGroupPanel = false;
            this.ViewFiyatTipi.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ViewFiyatTipi_RowCellClick);
            // 
            // FiyatTipiFipi
            // 
            this.FiyatTipiFipi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FiyatTipiFipi.AppearanceHeader.Options.UseFont = true;
            this.FiyatTipiFipi.Caption = "Fiyat Tipi";
            this.FiyatTipiFipi.FieldName = "Fiyat Tipi";
            this.FiyatTipiFipi.Name = "FiyatTipiFipi";
            this.FiyatTipiFipi.OptionsColumn.AllowEdit = false;
            this.FiyatTipiFipi.OptionsColumn.AllowSize = false;
            this.FiyatTipiFipi.OptionsColumn.FixedWidth = true;
            this.FiyatTipiFipi.Visible = true;
            this.FiyatTipiFipi.VisibleIndex = 0;
            this.FiyatTipiFipi.Width = 74;
            // 
            // FiyatTipiAciklama
            // 
            this.FiyatTipiAciklama.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FiyatTipiAciklama.AppearanceHeader.Options.UseFont = true;
            this.FiyatTipiAciklama.Caption = "Açiklama";
            this.FiyatTipiAciklama.FieldName = "Açiklama";
            this.FiyatTipiAciklama.Name = "FiyatTipiAciklama";
            this.FiyatTipiAciklama.OptionsColumn.AllowEdit = false;
            this.FiyatTipiAciklama.OptionsColumn.AllowSize = false;
            this.FiyatTipiAciklama.OptionsColumn.FixedWidth = true;
            this.FiyatTipiAciklama.Visible = true;
            this.FiyatTipiAciklama.VisibleIndex = 1;
            this.FiyatTipiAciklama.Width = 145;
            // 
            // FiyatTipiHangiFislerde
            // 
            this.FiyatTipiHangiFislerde.Caption = "Hangi Fislerde";
            this.FiyatTipiHangiFislerde.FieldName = "Hangi Fislerde";
            this.FiyatTipiHangiFislerde.Name = "FiyatTipiHangiFislerde";
            this.FiyatTipiHangiFislerde.OptionsColumn.FixedWidth = true;
            this.FiyatTipiHangiFislerde.Visible = true;
            this.FiyatTipiHangiFislerde.VisibleIndex = 2;
            this.FiyatTipiHangiFislerde.Width = 138;
            // 
            // FiyatTipiKdvDahil
            // 
            this.FiyatTipiKdvDahil.Caption = "Kdv Dahil";
            this.FiyatTipiKdvDahil.FieldName = "Kdv Dahil";
            this.FiyatTipiKdvDahil.Name = "FiyatTipiKdvDahil";
            this.FiyatTipiKdvDahil.OptionsColumn.FixedWidth = true;
            this.FiyatTipiKdvDahil.Visible = true;
            this.FiyatTipiKdvDahil.VisibleIndex = 3;
            this.FiyatTipiKdvDahil.Width = 138;
            // 
            // FiyatTipiDovizBaglı
            // 
            this.FiyatTipiDovizBaglı.Caption = "[Dövize Bagli]";
            this.FiyatTipiDovizBaglı.FieldName = "Dövize Bagli";
            this.FiyatTipiDovizBaglı.Name = "FiyatTipiDovizBaglı";
            this.FiyatTipiDovizBaglı.OptionsColumn.FixedWidth = true;
            this.FiyatTipiDovizBaglı.Visible = true;
            this.FiyatTipiDovizBaglı.VisibleIndex = 4;
            this.FiyatTipiDovizBaglı.Width = 138;
            // 
            // FiyatTipiLookUp
            // 
            this.FiyatTipiLookUp.Caption = "Döviz Cinsi";
            this.FiyatTipiLookUp.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.FiyatTipiLookUp.FieldName = "sDovizCinsi";
            this.FiyatTipiLookUp.Name = "FiyatTipiLookUp";
            this.FiyatTipiLookUp.OptionsColumn.FixedWidth = true;
            this.FiyatTipiLookUp.Visible = true;
            this.FiyatTipiLookUp.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // frmFiyatTipi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridFiyatTipi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmFiyatTipi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFiyatTipi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFiyatTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewFiyatTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridFiyatTipi;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewFiyatTipi;
        private DevExpress.XtraGrid.Columns.GridColumn FiyatTipiFipi;
        private DevExpress.XtraGrid.Columns.GridColumn FiyatTipiAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn FiyatTipiHangiFislerde;
        private DevExpress.XtraGrid.Columns.GridColumn FiyatTipiKdvDahil;
        private DevExpress.XtraGrid.Columns.GridColumn FiyatTipiDovizBaglı;
        private DevExpress.XtraGrid.Columns.GridColumn FiyatTipiLookUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}