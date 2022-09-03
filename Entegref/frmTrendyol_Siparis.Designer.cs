using DevExpress.XtraEditors;

namespace Entegref
{
    partial class frmTrendyol_Siparis
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
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cnhTarih = new System.Windows.Forms.CheckBox();
            this.dteStartDate = new DevExpress.XtraEditors.DateEdit();
            this.dteEndDate = new DevExpress.XtraEditors.DateEdit();
            this.txtshipmentPackageIds = new DevExpress.XtraEditors.TextEdit();
            this.txtorderNumber = new DevExpress.XtraEditors.TextEdit();
            this.chkstatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtshipmentPackageIds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.Enabled = false;
            this.simpleButton2.Location = new System.Drawing.Point(472, 80);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(153, 52);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Trendyol Siparişşleri Listele";
            this.simpleButton2.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 232);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1138, 406);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gridView1.OptionsFind.ClearFindOnClose = false;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.groupControl3);
            this.ultraPanel3.ClientArea.Controls.Add(this.chkstatus);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel3.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(1138, 232);
            this.ultraPanel3.TabIndex = 2;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupControl1);
            this.groupControl3.Controls.Add(this.simpleButton2);
            this.groupControl3.Controls.Add(this.groupControl4);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(209, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(929, 232);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "Filitreler";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.label3);
            this.groupControl4.Controls.Add(this.label4);
            this.groupControl4.Controls.Add(this.cnhTarih);
            this.groupControl4.Controls.Add(this.dteStartDate);
            this.groupControl4.Controls.Add(this.dteEndDate);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl4.Location = new System.Drawing.Point(2, 16);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(208, 214);
            this.groupControl4.TabIndex = 5;
            this.groupControl4.Text = "Tarih Filtersi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Başlanğıç Tarihi";
            // 
            // cnhTarih
            // 
            this.cnhTarih.AutoSize = true;
            this.cnhTarih.Location = new System.Drawing.Point(5, 26);
            this.cnhTarih.Name = "cnhTarih";
            this.cnhTarih.Size = new System.Drawing.Size(107, 17);
            this.cnhTarih.TabIndex = 3;
            this.cnhTarih.Text = "Tarih Filtresi Var";
            this.cnhTarih.UseVisualStyleBackColor = true;
            this.cnhTarih.CheckedChanged += new System.EventHandler(this.cnhTarih_CheckedChanged);
            // 
            // dteStartDate
            // 
            this.dteStartDate.EditValue = null;
            this.dteStartDate.Enabled = false;
            this.dteStartDate.Location = new System.Drawing.Point(5, 61);
            this.dteStartDate.Name = "dteStartDate";
            this.dteStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteStartDate.Size = new System.Drawing.Size(176, 20);
            this.dteStartDate.TabIndex = 1;
            this.dteStartDate.EditValueChanged += new System.EventHandler(this.dteStartDate_EditValueChanged);
            // 
            // dteEndDate
            // 
            this.dteEndDate.EditValue = null;
            this.dteEndDate.Enabled = false;
            this.dteEndDate.Location = new System.Drawing.Point(5, 99);
            this.dteEndDate.Name = "dteEndDate";
            this.dteEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteEndDate.Size = new System.Drawing.Size(176, 20);
            this.dteEndDate.TabIndex = 2;
            this.dteEndDate.EditValueChanged += new System.EventHandler(this.dteEndDate_EditValueChanged);
            // 
            // txtshipmentPackageIds
            // 
            this.txtshipmentPackageIds.Location = new System.Drawing.Point(19, 99);
            this.txtshipmentPackageIds.Name = "txtshipmentPackageIds";
            this.txtshipmentPackageIds.Size = new System.Drawing.Size(176, 20);
            this.txtshipmentPackageIds.TabIndex = 4;
            // 
            // txtorderNumber
            // 
            this.txtorderNumber.Location = new System.Drawing.Point(17, 61);
            this.txtorderNumber.Name = "txtorderNumber";
            this.txtorderNumber.Size = new System.Drawing.Size(176, 20);
            this.txtorderNumber.TabIndex = 3;
            // 
            // chkstatus
            // 
            this.chkstatus.CheckOnClick = true;
            this.chkstatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkstatus.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Created", "Tamamlanan", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(" Picking", "Toplama Bekleyen"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Invoiced", "Faturası Yüklenmiş"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Shipped", "Gönderisi Yapılmış"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("UnDelivered", "Kargoda Teslimat Bekleyen"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Delivered", "Teslim Edilmiş"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Cancelled", "İptal Edilenler"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Repack", "Yeniden Paketlenen"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("UnPacked", "Peketlenemyi Bekleyen"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("UnSupplied", "Tedarik Edilemeyen")});
            this.chkstatus.Location = new System.Drawing.Point(0, 0);
            this.chkstatus.Name = "chkstatus";
            this.chkstatus.Size = new System.Drawing.Size(209, 232);
            this.chkstatus.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtorderNumber);
            this.groupControl1.Controls.Add(this.txtshipmentPackageIds);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(210, 16);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(222, 214);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "İşlem Filitresi";
            // 
            // frmTrendyol_Siparis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 638);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ultraPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTrendyol_Siparis";
            this.Text = "frmTrendyol_Siparis";
            this.Load += new System.EventHandler(this.frmTrendyol_Siparis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtshipmentPackageIds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private SimpleButton simpleButton2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private GroupControl groupControl3;
        private GroupControl groupControl4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cnhTarih;
        private DateEdit dteStartDate;
        private DateEdit dteEndDate;
        private TextEdit txtshipmentPackageIds;
        private TextEdit txtorderNumber;
        private CheckedListBoxControl chkstatus;
        private GroupControl groupControl1;
    }
}