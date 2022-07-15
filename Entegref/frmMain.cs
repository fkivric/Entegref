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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            switch (e.Item.Key.ToString())
            {
                case "11":
                    frmStokAc stok = new frmStokAc();
                    stok.MdiParent = this;
                    stok.Show();
                    break;

                case "12":
                    frmFiyat fiyat = new frmFiyat();
                    fiyat.MdiParent = this;
                    fiyat.Show();
                    break;

                case "21":
                    frmYapılandırma yapılandırma = new frmYapılandırma();
                    yapılandırma.MdiParent = this;
                    yapılandırma.Show();
                    break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
