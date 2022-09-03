namespace Entegref
{
    partial class frmTrendyol_FirmaAdresBilgisi
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
            this.gridAddress = new DevExpress.XtraGrid.GridControl();
            this.cardViewAddress = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colDistrict = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshipmentAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colreturningAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvoiceAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridAddress);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 637);
            this.panel2.TabIndex = 1;
            // 
            // gridAddress
            // 
            this.gridAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAddress.Location = new System.Drawing.Point(0, 0);
            this.gridAddress.MainView = this.cardViewAddress;
            this.gridAddress.Name = "gridAddress";
            this.gridAddress.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemPictureEdit1});
            this.gridAddress.Size = new System.Drawing.Size(1138, 637);
            this.gridAddress.TabIndex = 2;
            this.gridAddress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardViewAddress});
            // 
            // cardViewAddress
            // 
            this.cardViewAddress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cardViewAddress.CardCaptionFormat = "Adresler{0}";
            this.cardViewAddress.CardWidth = 300;
            this.cardViewAddress.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colType,
            this.colAddress,
            this.colDistrict,
            this.colpostCode,
            this.colshipmentAddress,
            this.colreturningAddress,
            this.colinvoiceAddress,
            this.colPhoto});
            this.cardViewAddress.GridControl = this.gridAddress;
            this.cardViewAddress.Name = "cardViewAddress";
            this.cardViewAddress.OptionsBehavior.FieldAutoHeight = true;
            // 
            // colid
            // 
            this.colid.Caption = "Adress ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.FixedWidth = true;
            this.colid.Visible = true;
            this.colid.VisibleIndex = 8;
            // 
            // colType
            // 
            this.colType.Caption = "Adress Türü";
            this.colType.FieldName = "addressType";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.FixedWidth = true;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            // 
            // colAddress
            // 
            this.colAddress.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colAddress.FieldName = "fullAddress";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.PopupFormSize = new System.Drawing.Size(350, 150);
            // 
            // colDistrict
            // 
            this.colDistrict.Caption = "Adress Semt";
            this.colDistrict.FieldName = "district";
            this.colDistrict.Name = "colDistrict";
            this.colDistrict.OptionsColumn.FixedWidth = true;
            this.colDistrict.Visible = true;
            this.colDistrict.VisibleIndex = 1;
            // 
            // colpostCode
            // 
            this.colpostCode.Caption = "Adress Posta Kodu";
            this.colpostCode.FieldName = "postCode";
            this.colpostCode.Name = "colpostCode";
            this.colpostCode.OptionsColumn.FixedWidth = true;
            this.colpostCode.Visible = true;
            this.colpostCode.VisibleIndex = 3;
            // 
            // colshipmentAddress
            // 
            this.colshipmentAddress.Caption = "Ürün Sevk Adresi";
            this.colshipmentAddress.FieldName = "shipmentAddress";
            this.colshipmentAddress.Name = "colshipmentAddress";
            this.colshipmentAddress.OptionsColumn.FixedWidth = true;
            this.colshipmentAddress.Visible = true;
            this.colshipmentAddress.VisibleIndex = 5;
            // 
            // colreturningAddress
            // 
            this.colreturningAddress.Caption = "Ürün İade Adresi";
            this.colreturningAddress.FieldName = "returningAddress";
            this.colreturningAddress.Name = "colreturningAddress";
            this.colreturningAddress.OptionsColumn.FixedWidth = true;
            this.colreturningAddress.Visible = true;
            this.colreturningAddress.VisibleIndex = 6;
            // 
            // colinvoiceAddress
            // 
            this.colinvoiceAddress.Caption = "Ürün Fatura Adresi";
            this.colinvoiceAddress.FieldName = "invoiceAddress";
            this.colinvoiceAddress.Name = "colinvoiceAddress";
            this.colinvoiceAddress.OptionsColumn.FixedWidth = true;
            this.colinvoiceAddress.Visible = true;
            this.colinvoiceAddress.VisibleIndex = 7;
            // 
            // colPhoto
            // 
            this.colPhoto.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.OptionsColumn.FixedWidth = true;
            this.colPhoto.Visible = true;
            this.colPhoto.VisibleIndex = 2;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 110;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // 
            // frmTrendyol_FirmaAdresBilgisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 637);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTrendyol_FirmaAdresBilgisi";
            this.Text = "frmTrendyol_FirmaAdresBilgisi";
            this.Load += new System.EventHandler(this.frmTrendyol_FirmaAdresBilgisi_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridAddress;
        private DevExpress.XtraGrid.Views.Card.CardView cardViewAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoto;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colDistrict;
        private DevExpress.XtraGrid.Columns.GridColumn colpostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colshipmentAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colreturningAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colinvoiceAddress;
    }
}