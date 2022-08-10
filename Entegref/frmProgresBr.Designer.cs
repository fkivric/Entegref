namespace Entegref
{
    partial class frmProgresBr
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
            this.prpMain = new DevExpress.XtraWaitForm.ProgressPanel();
            this.prgProgress = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.prgProgress.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.prpMain.Size = new System.Drawing.Size(420, 97);
            this.prpMain.TabIndex = 3;
            this.prpMain.Text = "progressPanel1";
            // 
            // prgProgress
            // 
            this.prgProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prgProgress.Location = new System.Drawing.Point(0, 79);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Properties.ShowTitle = true;
            this.prgProgress.Size = new System.Drawing.Size(420, 18);
            this.prgProgress.TabIndex = 4;
            // 
            // frmProgresBr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 97);
            this.ControlBox = false;
            this.Controls.Add(this.prgProgress);
            this.Controls.Add(this.prpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmProgresBr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.prgProgress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl prgProgress;
        private DevExpress.XtraWaitForm.ProgressPanel prpMain;
    }
}