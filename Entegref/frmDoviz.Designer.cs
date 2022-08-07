namespace Entegref
{
    partial class frmDoviz
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
            this.gridDoviz = new DevExpress.XtraGrid.GridControl();
            this.viewDoviz = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDoviz)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDoviz
            // 
            this.gridDoviz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDoviz.Location = new System.Drawing.Point(0, 0);
            this.gridDoviz.MainView = this.viewDoviz;
            this.gridDoviz.Name = "gridDoviz";
            this.gridDoviz.Size = new System.Drawing.Size(460, 518);
            this.gridDoviz.TabIndex = 0;
            this.gridDoviz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDoviz});
            // 
            // viewDoviz
            // 
            this.viewDoviz.GridControl = this.gridDoviz;
            this.viewDoviz.Name = "viewDoviz";
            this.viewDoviz.OptionsView.ShowGroupPanel = false;
            // 
            // frmDoviz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 518);
            this.Controls.Add(this.gridDoviz);
            this.Name = "frmDoviz";
            this.Text = "frmDoviz";
            this.Load += new System.EventHandler(this.frmDoviz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDoviz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDoviz;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDoviz;
    }
}