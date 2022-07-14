namespace Entegref
{
    partial class frmStokBul
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridStok = new DevExpress.XtraGrid.GridControl();
            this.ViewStok = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoksKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoksAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStok)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridStok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 450);
            this.panel2.TabIndex = 0;
            // 
            // gridStok
            // 
            this.gridStok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStok.Location = new System.Drawing.Point(0, 0);
            this.gridStok.MainView = this.ViewStok;
            this.gridStok.Name = "gridStok";
            this.gridStok.Size = new System.Drawing.Size(800, 450);
            this.gridStok.TabIndex = 22;
            this.gridStok.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewStok});
            // 
            // ViewStok
            // 
            this.ViewStok.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.StoksKodu,
            this.StoksAciklama});
            this.ViewStok.GridControl = this.gridStok;
            this.ViewStok.Name = "ViewStok";
            this.ViewStok.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.ViewStok.OptionsFind.ClearFindOnClose = false;
            this.ViewStok.OptionsFind.SearchInPreview = true;
            this.ViewStok.OptionsFind.ShowClearButton = false;
            this.ViewStok.OptionsView.ShowAutoFilterRow = true;
            this.ViewStok.OptionsView.ShowGroupPanel = false;
            this.ViewStok.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ViewFirma_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "id";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            // 
            // StoksKodu
            // 
            this.StoksKodu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.StoksKodu.AppearanceHeader.Options.UseFont = true;
            this.StoksKodu.Caption = "Stok Kodu";
            this.StoksKodu.FieldName = "sKodu";
            this.StoksKodu.Name = "StoksKodu";
            this.StoksKodu.OptionsColumn.AllowEdit = false;
            this.StoksKodu.OptionsColumn.AllowSize = false;
            this.StoksKodu.Visible = true;
            this.StoksKodu.VisibleIndex = 0;
            this.StoksKodu.Width = 102;
            // 
            // StoksAciklama
            // 
            this.StoksAciklama.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.StoksAciklama.AppearanceHeader.Options.UseFont = true;
            this.StoksAciklama.Caption = "Ürün Adı";
            this.StoksAciklama.FieldName = "sAciklama";
            this.StoksAciklama.Name = "StoksAciklama";
            this.StoksAciklama.OptionsColumn.AllowEdit = false;
            this.StoksAciklama.OptionsColumn.AllowSize = false;
            this.StoksAciklama.Visible = true;
            this.StoksAciklama.VisibleIndex = 1;
            this.StoksAciklama.Width = 673;
            // 
            // frmStokBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Name = "frmStokBul";
            this.Text = "frmStokbul";
            this.Load += new System.EventHandler(this.frmFirmaBul_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridStok;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewStok;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn StoksKodu;
        private DevExpress.XtraGrid.Columns.GridColumn StoksAciklama;
    }
}