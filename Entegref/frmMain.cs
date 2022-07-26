using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entegref
{
    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            switch (e.Item.Key.ToString())
            {
                case "11":
                    OpenForm(new frmStokAc());
                    break;

                case "12":
                    OpenForm(new frmFiyat());
                    break;

                case "21":
                    OpenForm(new frmMusteri());
                    break;

                case "31":
                    OpenForm(new frmFirma());
                    break;

                case "82":
                    OpenForm(new frmAyarlarUrun());
                    break;
            }
        }
        public void OpenForm(Form toOpen)
        {
            int var = 0;
            foreach (Form child in MdiChildren)
            {
                if (child.Name == toOpen.Name)
                {
                    //child.Close();
                    var = 1;
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.Caption = "Uyarı";
                    args.Text = toOpen.Text.ToString() + "Açık.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    XtraMessageBox.Show(args).ToString();
                    toOpen.Focus();
                }
            }
            if (var == 0)
            {
                toOpen.MdiParent = this;
                toOpen.Show();
            }
        }

        int show = 0;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            

            
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (show == 0)
            {
                Point p = this.Location;
                p.Offset(this.Width / 2, this.Height / 2);
                radialMenu1.ShowPopup(p);
            }
            else
            {
                radialMenu1.HidePopup();
                show = 1;
            }
        }
    }
}
