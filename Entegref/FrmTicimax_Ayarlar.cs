using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Entegref
{
    public partial class FrmTicimax_Ayarlar : DevExpress.XtraEditors.XtraForm
    {
        public FrmTicimax_Ayarlar()
        {
            InitializeComponent();
        }

        private void btnAlanAdiUyeKoduOnayla_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TicimaxAlanAdi = tbAlanAdi.Text;
            Properties.Settings.Default.TicimaxYetkiKodu = tbUyeKodu.Text;
            Properties.Settings.Default.Save();

            StaticVariables.alanAdi = tbAlanAdi.Text;
            StaticVariables.uyeKodu = tbUyeKodu.Text;
        }
    }
}