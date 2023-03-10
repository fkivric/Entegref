namespace Entegref
{
    partial class frmdepoBul
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
            this.gridDepo = new DevExpress.XtraGrid.GridControl();
            this.ViewDepo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoksKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoksAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDepo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDepo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 450);
            this.panel2.TabIndex = 0;
            // 
            // gridDepo
            // 
            this.gridDepo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDepo.Location = new System.Drawing.Point(0, 0);
            this.gridDepo.MainView = this.ViewDepo;
            this.gridDepo.Name = "gridDepo";
            this.gridDepo.Size = new System.Drawing.Size(800, 450);
            this.gridDepo.TabIndex = 22;
            this.gridDepo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewDepo});
            // 
            // ViewDepo
            // 
            this.ViewDepo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.StoksKodu,
            this.StoksAciklama});
            this.ViewDepo.GridControl = this.gridDepo;
            this.ViewDepo.Name = "ViewDepo";
            this.ViewDepo.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.ViewDepo.OptionsFind.ClearFindOnClose = false;
            this.ViewDepo.OptionsFind.SearchInPreview = true;
            this.ViewDepo.OptionsFind.ShowClearButton = false;
            this.ViewDepo.OptionsView.ShowAutoFilterRow = true;
            this.ViewDepo.OptionsView.ShowGroupPanel = false;
            this.ViewDepo.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ViewDepo_RowCellClick);
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
            // frmdepoBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmdepoBul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmdepoBul";
            this.Load += new System.EventHandler(this.frmFirmaBul_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDepo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridDepo;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewDepo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn StoksKodu;
        private DevExpress.XtraGrid.Columns.GridColumn StoksAciklama;
    }
}