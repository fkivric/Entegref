using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entegref
{
    public partial class frmFiyat : XtraForm
    {        
        public frmFiyat()
        {
            InitializeComponent();
        }

        private void frmFiyat_Load(object sender, EventArgs e)
        {
        }
        public void OpenForm(Form toOpen)
        {
        //    int var = 0;
        //    foreach (Form child in MdiChildren)
        //    {
        //        if (child.Name == toOpen.Name)
        //        {
        //            //child.Close();
        //            var = 1;
        //            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
        //            args.AutoCloseOptions.Delay = 2000;
        //            args.Caption = "Uyarı";
        //            args.Text = toOpen.Text.ToString() + "Açık.";
        //            args.Buttons = new DialogResult[] { DialogResult.OK };
        //            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
        //            XtraMessageBox.Show(args).ToString();
        //            toOpen.Close();
        //            toOpen.Dispose();
        //            toOpen.Focus();
        //        }
        //    }
        //    if (var == 0)
        //    {
        //        toOpen.MdiParent = this;
        //        toOpen.Show();
        //    }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pnlFiyat.Controls.Clear();
            frmFiyatTek tek = new frmFiyatTek();
            tek.TopLevel = false;
            pnlFiyat.Controls.Add(tek);
            tek.Show();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pnlFiyat.Controls.Clear();
            frmFiyatToplu toplu = new frmFiyatToplu();
            toplu.TopLevel = false;
            pnlFiyat.Controls.Add(toplu);
            toplu.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            pnlFiyat.Controls.Clear();
            frmFiyatOtomatik otomatik = new frmFiyatOtomatik();
            otomatik.TopLevel = false;
            pnlFiyat.Controls.Add(otomatik);
            otomatik.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            pnlFiyat.Controls.Clear();
            frmFiyatArttırAzalt arttırAzalt  = new frmFiyatArttırAzalt();
            arttırAzalt.TopLevel = false;
            pnlFiyat.Controls.Add(arttırAzalt);
            arttırAzalt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
