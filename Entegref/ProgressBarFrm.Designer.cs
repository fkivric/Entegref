namespace Entegref
{
    partial class ProgressBarFrm
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
            this.prgProgress = new DevExpress.XtraEditors.ProgressBarControl();
            this.prpMain = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.prgProgress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // prgProgress
            // 
            this.prgProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prgProgress.Location = new System.Drawing.Point(0, 86);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Properties.ShowTitle = true;
            this.prgProgress.Size = new System.Drawing.Size(407, 18);
            this.prgProgress.TabIndex = 3;
            // 
            // prpMain
            // 
            this.prpMain.Appearance.BackColor = System.Drawing.Color.White;
            this.prpMain.Appearance.Options.UseBackColor = true;
            this.prpMain.Caption = "Lütfen Bekleyiniz.";
            this.prpMain.Description = " İşlemler Yapılıyor ( Bağlantı Hızı ve Cevap verme Süresine Göre Değişir)...";
            this.prpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpMain.Location = new System.Drawing.Point(0, 0);
            this.prpMain.Name = "prpMain";
            this.prpMain.Size = new System.Drawing.Size(407, 86);
            this.prpMain.TabIndex = 4;
            this.prpMain.Text = "progressPanel1";
            // 
            // ProgressBarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 104);
            this.Controls.Add(this.prpMain);
            this.Controls.Add(this.prgProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBarFrm";
            this.Text = "ProgressBarFrm";
            this.Load += new System.EventHandler(this.ProgressBarFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prgProgress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl prgProgress;
        private DevExpress.XtraWaitForm.ProgressPanel prpMain;
    }
}