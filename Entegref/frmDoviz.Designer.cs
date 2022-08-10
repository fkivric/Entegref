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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDoviz = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDovizMerkez = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoviz)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDovizMerkez);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 60);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDoviz);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 470);
            this.panel2.TabIndex = 1;
            // 
            // gridDoviz
            // 
            this.gridDoviz.AllowUserToAddRows = false;
            this.gridDoviz.AllowUserToDeleteRows = false;
            this.gridDoviz.AllowUserToOrderColumns = true;
            this.gridDoviz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDoviz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDoviz.Location = new System.Drawing.Point(0, 0);
            this.gridDoviz.Name = "gridDoviz";
            this.gridDoviz.Size = new System.Drawing.Size(957, 470);
            this.gridDoviz.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDovizMerkez
            // 
            this.btnDovizMerkez.Location = new System.Drawing.Point(12, 3);
            this.btnDovizMerkez.Name = "btnDovizMerkez";
            this.btnDovizMerkez.Size = new System.Drawing.Size(236, 51);
            this.btnDovizMerkez.TabIndex = 1;
            this.btnDovizMerkez.Text = "Merkez Bankası döviz Kurlarını Güncelle";
            this.btnDovizMerkez.Click += new System.EventHandler(this.btnDovizMerkez_Click);
            // 
            // frmDoviz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDoviz";
            this.Text = "frmDoviz";
            this.Load += new System.EventHandler(this.frmDoviz_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDoviz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridDoviz;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btnDovizMerkez;
    }
}