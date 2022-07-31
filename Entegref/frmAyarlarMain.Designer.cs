namespace Entegref
{
    partial class frmDepoAyarları
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ürünAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünGenelParametreAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.urunozellik = new System.Windows.Forms.ToolStripMenuItem();
            this.depoAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikciAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pazarYeriAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünAyarlarıToolStripMenuItem,
            this.depoAyarlarıToolStripMenuItem,
            this.satışAyarlarıToolStripMenuItem,
            this.tedarikciAyarlarıToolStripMenuItem,
            this.pazarYeriAyarlarıToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1461, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ürünAyarlarıToolStripMenuItem
            // 
            this.ürünAyarlarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünGenelParametreAyarlarıToolStripMenuItem,
            this.toolStripSeparator1,
            this.urunozellik});
            this.ürünAyarlarıToolStripMenuItem.Name = "ürünAyarlarıToolStripMenuItem";
            this.ürünAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.ürünAyarlarıToolStripMenuItem.Text = "Ürün Ayarları";
            // 
            // ürünGenelParametreAyarlarıToolStripMenuItem
            // 
            this.ürünGenelParametreAyarlarıToolStripMenuItem.Name = "ürünGenelParametreAyarlarıToolStripMenuItem";
            this.ürünGenelParametreAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.ürünGenelParametreAyarlarıToolStripMenuItem.Text = "Ürün Genel Parametre Ayarları";
            this.ürünGenelParametreAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.ürünGenelParametreAyarlarıToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // urunozellik
            // 
            this.urunozellik.Name = "urunozellik";
            this.urunozellik.Size = new System.Drawing.Size(233, 22);
            this.urunozellik.Text = "Ürün Özellikleri Ayarları";
            this.urunozellik.Click += new System.EventHandler(this.urunozellik_Click);
            // 
            // depoAyarlarıToolStripMenuItem
            // 
            this.depoAyarlarıToolStripMenuItem.Name = "depoAyarlarıToolStripMenuItem";
            this.depoAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.depoAyarlarıToolStripMenuItem.Text = "Depo Ayarları";
            // 
            // satışAyarlarıToolStripMenuItem
            // 
            this.satışAyarlarıToolStripMenuItem.Name = "satışAyarlarıToolStripMenuItem";
            this.satışAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.satışAyarlarıToolStripMenuItem.Text = "Satış Ayarları";
            // 
            // tedarikciAyarlarıToolStripMenuItem
            // 
            this.tedarikciAyarlarıToolStripMenuItem.Name = "tedarikciAyarlarıToolStripMenuItem";
            this.tedarikciAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.tedarikciAyarlarıToolStripMenuItem.Text = "Tedarikci Ayarları";
            // 
            // pazarYeriAyarlarıToolStripMenuItem
            // 
            this.pazarYeriAyarlarıToolStripMenuItem.Name = "pazarYeriAyarlarıToolStripMenuItem";
            this.pazarYeriAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.pazarYeriAyarlarıToolStripMenuItem.Text = "PazarYeri Ayarları";
            // 
            // pnlForm
            // 
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 24);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1461, 710);
            this.pnlForm.TabIndex = 1;
            // 
            // frmDepoAyarları
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 734);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDepoAyarları";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntegreF Ayarlar";
            this.Load += new System.EventHandler(this.frmDepoAyarları_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ürünAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünGenelParametreAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunozellik;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.ToolStripMenuItem satışAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikciAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pazarYeriAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depoAyarlarıToolStripMenuItem;
    }
}