namespace Entegref
{
    partial class frmDepo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepo));
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
            ((System.ComponentModel.ISupportInitialize)(this.gridDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDepo
            // 
            resources.ApplyResources(this.gridDepo, "gridDepo");
            this.gridDepo.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridDepo.EmbeddedNavigator.AccessibleDescription");
            this.gridDepo.EmbeddedNavigator.AccessibleName = resources.GetString("gridDepo.EmbeddedNavigator.AccessibleName");
            this.gridDepo.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridDepo.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridDepo.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridDepo.EmbeddedNavigator.Anchor")));
            this.gridDepo.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridDepo.EmbeddedNavigator.BackgroundImage")));
            this.gridDepo.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridDepo.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridDepo.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridDepo.EmbeddedNavigator.ImeMode")));
            this.gridDepo.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridDepo.EmbeddedNavigator.MaximumSize")));
            this.gridDepo.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridDepo.EmbeddedNavigator.TextLocation")));
            this.gridDepo.EmbeddedNavigator.ToolTip = resources.GetString("gridDepo.EmbeddedNavigator.ToolTip");
            this.gridDepo.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridDepo.EmbeddedNavigator.ToolTipIconType")));
            this.gridDepo.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridDepo.EmbeddedNavigator.ToolTipTitle");
            this.gridDepo.MainView = this.cardViewDepo;
            this.gridDepo.Name = "gridDepo";
            this.gridDepo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemPictureEdit1});
            this.gridDepo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardViewDepo});
            // 
            // cardViewDepo
            // 
            this.cardViewDepo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            resources.ApplyResources(this.cardViewDepo, "cardViewDepo");
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
            resources.ApplyResources(this.colTrademark, "colTrademark");
            this.colTrademark.FieldName = "sDepo";
            this.colTrademark.Name = "colTrademark";
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "depoadi";
            this.colName.Name = "colName";
            // 
            // colModification
            // 
            resources.ApplyResources(this.colModification, "colModification");
            this.colModification.FieldName = "firma";
            this.colModification.Name = "colModification";
            // 
            // colCategory
            // 
            resources.ApplyResources(this.colCategory, "colCategory");
            this.colCategory.FieldName = "depotipi";
            this.colCategory.Name = "colCategory";
            // 
            // colPhoto
            // 
            resources.ApplyResources(this.colPhoto, "colPhoto");
            this.colPhoto.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 110;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // 
            // colDescription
            // 
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colDescription.FieldName = "adress";
            this.colDescription.Name = "colDescription";
            // 
            // repositoryItemMemoExEdit1
            // 
            resources.ApplyResources(this.repositoryItemMemoExEdit1, "repositoryItemMemoExEdit1");
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemMemoExEdit1.Buttons"))))});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.PopupFormSize = new System.Drawing.Size(350, 150);
            // 
            // colsVergiDairesi
            // 
            resources.ApplyResources(this.colsVergiDairesi, "colsVergiDairesi");
            this.colsVergiDairesi.FieldName = "sVergiDairesi";
            this.colsVergiDairesi.Name = "colsVergiDairesi";
            // 
            // colsVergiNo
            // 
            resources.ApplyResources(this.colsVergiNo, "colsVergiNo");
            this.colsVergiNo.FieldName = "sVergiNo";
            this.colsVergiNo.Name = "colsVergiNo";
            // 
            // frmDepo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDepo);
            this.Name = "frmDepo";
            this.Load += new System.EventHandler(this.frmDepo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardViewDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
    }
}