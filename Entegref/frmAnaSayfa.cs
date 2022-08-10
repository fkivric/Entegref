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
using System.Data.SqlClient;

namespace Entegref
{
    public partial class frmAnaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);

        private void frmAnaSayfa_Load(object sender, EventArgs e)
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
                    //pnlfiyat.Dock = DockStyle.Fill;
                    //frmFiyat fyt = new frmFiyat();
                    //fyt.TopLevel = true;

                    //pnlfiyat.Controls.Add(fyt);
                    //fyt.Show();
                    OpenForm(new frmFiyat());
                    break;

                case "21":
                    OpenForm(new frmMusteri());
                    break;

                case "31":
                    OpenForm(new frmFirma());
                    break;

                case "81":
                    OpenForm(new frmReportView());
                    break;

                case "82":
                    Report frmreport = new Report();
                    frmreport.ShowDialog();
                    //OpenForm(new Report());
                    break;

                case "92":
                    OpenForm(new frmDepoAyarları());
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
                    toOpen.Close();
                    toOpen.Dispose();
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