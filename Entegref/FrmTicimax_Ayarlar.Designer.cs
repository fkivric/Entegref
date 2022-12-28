namespace Entegref
{
    partial class FrmTicimax_Ayarlar
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
            this.btnAlanAdiUyeKoduOnayla = new System.Windows.Forms.Button();
            this.tbUyeKodu = new System.Windows.Forms.TextBox();
            this.tbAlanAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAlanAdiUyeKoduOnayla
            // 
            this.btnAlanAdiUyeKoduOnayla.Location = new System.Drawing.Point(277, 184);
            this.btnAlanAdiUyeKoduOnayla.Name = "btnAlanAdiUyeKoduOnayla";
            this.btnAlanAdiUyeKoduOnayla.Size = new System.Drawing.Size(75, 23);
            this.btnAlanAdiUyeKoduOnayla.TabIndex = 10;
            this.btnAlanAdiUyeKoduOnayla.Text = "ONAYLA";
            this.btnAlanAdiUyeKoduOnayla.UseVisualStyleBackColor = true;
            this.btnAlanAdiUyeKoduOnayla.Click += new System.EventHandler(this.btnAlanAdiUyeKoduOnayla_Click);
            // 
            // tbUyeKodu
            // 
            this.tbUyeKodu.Location = new System.Drawing.Point(106, 148);
            this.tbUyeKodu.Name = "tbUyeKodu";
            this.tbUyeKodu.Size = new System.Drawing.Size(246, 22);
            this.tbUyeKodu.TabIndex = 9;
            // 
            // tbAlanAdi
            // 
            this.tbAlanAdi.Location = new System.Drawing.Point(106, 114);
            this.tbAlanAdi.Name = "tbAlanAdi";
            this.tbAlanAdi.Size = new System.Drawing.Size(246, 22);
            this.tbAlanAdi.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Üye kodu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Alan Adı:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTicimax_Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 220);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAlanAdiUyeKoduOnayla);
            this.Controls.Add(this.tbUyeKodu);
            this.Controls.Add(this.tbAlanAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTicimax_Ayarlar";
            this.Text = "FrmTicimax_Ayarlar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAlanAdiUyeKoduOnayla;
        private System.Windows.Forms.TextBox tbUyeKodu;
        private System.Windows.Forms.TextBox tbAlanAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}