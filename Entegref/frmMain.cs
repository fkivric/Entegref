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
        frmStokAc FRMSTOKAC;
        frmFiyat FRMFIYAT;
        frmMusteri FRMMUSTERI;


        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            switch (e.Item.Key.ToString())
            {
                case "11":
                    if (FRMSTOKAC != null)
                    {
                        FRMSTOKAC.Show();
                    }
                    else
                    {
                        FRMSTOKAC = new frmStokAc();
                        FRMSTOKAC.MdiParent = this;
                        FRMSTOKAC.Show();
                    }

                    //frmStokAc stok = new frmStokAc();
                    //stok.MdiParent = this;
                    //stok.Show();
                    break;

                case "12":
                    if (FRMFIYAT != null)
                    {
                        FRMFIYAT.Show();
                    }
                    else
                    {
                        FRMFIYAT = new frmFiyat();
                        FRMFIYAT.MdiParent = this;
                        FRMFIYAT.Show();
                    }
                    break;

                case "21":
                    OpenForm(new frmMusteri());
                    break;

                case "31":
                    OpenForm(new frmFirma());
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
                    toOpen.Focus();
                }
            }
            if (var == 0)
            {
                toOpen.MdiParent = this;
                toOpen.Show();
            }
        }
    }
}
