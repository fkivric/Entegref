namespace Entegref.Ticimax
{
    partial class frmListe
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
            this.dtgResultList = new DevExpress.XtraGrid.GridControl();
            this.ViewResultList = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewResultList)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgResultList
            // 
            this.dtgResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgResultList.Location = new System.Drawing.Point(0, 0);
            this.dtgResultList.MainView = this.ViewResultList;
            this.dtgResultList.Name = "dtgResultList";
            this.dtgResultList.Size = new System.Drawing.Size(899, 635);
            this.dtgResultList.TabIndex = 0;
            this.dtgResultList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewResultList});
            // 
            // ViewResultList
            // 
            this.ViewResultList.GridControl = this.dtgResultList;
            this.ViewResultList.Name = "ViewResultList";
            // 
            // frmListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 635);
            this.Controls.Add(this.dtgResultList);
            this.Name = "frmListe";
            this.Text = "frmListe";
            this.Load += new System.EventHandler(this.frmListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewResultList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dtgResultList;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewResultList;
    }
}