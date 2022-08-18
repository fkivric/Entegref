namespace Entegref
{
    partial class frmKargo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridKargo = new DevExpress.XtraGrid.GridControl();
            this.viewKargo = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridKargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewKargo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 0;
            // 
            // gridKargo
            // 
            this.gridKargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKargo.Location = new System.Drawing.Point(0, 46);
            this.gridKargo.MainView = this.viewKargo;
            this.gridKargo.Name = "gridKargo";
            this.gridKargo.Size = new System.Drawing.Size(800, 404);
            this.gridKargo.TabIndex = 1;
            this.gridKargo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewKargo});
            // 
            // viewKargo
            // 
            this.viewKargo.GridControl = this.gridKargo;
            this.viewKargo.Name = "viewKargo";
            this.viewKargo.OptionsFind.AlwaysVisible = true;
            this.viewKargo.OptionsView.ShowGroupPanel = false;
            // 
            // frmKargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridKargo);
            this.Controls.Add(this.panel1);
            this.Name = "frmKargo";
            this.Text = "frmKargo";
            this.Load += new System.EventHandler(this.frmKargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewKargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridKargo;
        private DevExpress.XtraGrid.Views.Grid.GridView viewKargo;
    }
}