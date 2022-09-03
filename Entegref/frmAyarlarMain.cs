using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entegref
{
    public partial class frmDepoAyarları : DevExpress.XtraEditors.XtraForm
    {
        public frmDepoAyarları()
        {
            InitializeComponent();
        }

        private void frmDepoAyarları_Load(object sender, EventArgs e)
        {

        }
        public void OpenForm(Form toOpen)
        {
            int var = 0;
            foreach (Form child in Application.OpenForms)
            {
                if (child.Name == toOpen.Name)
                {
                    //child.Close();
                    var = 1;
                }
            }
            if (var == 0)
            {
                pnlForm.Controls.Clear();
                toOpen.TopLevel = false;
                pnlForm.Controls.Add(toOpen);
                try
                {

                    toOpen.Show();
                }
                catch (Exception e)
                {

                    XtraMessageBox.Show(e.Message);
                    toOpen.Show();
                }
                toOpen.Dock = DockStyle.Left;
                toOpen.BringToFront();
            }
            else
            {

                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 2000;
                args.Caption = "Uyarı";
                args.Text = toOpen.Text.ToString() + "Açık.";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.Retry };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.Showing += Args_Showing;
                if (XtraMessageBox.Show(args) == DialogResult.Retry)
                {
                    toOpen.Close();
                    toOpen.Dispose();
                };
                toOpen.Close();
                toOpen.Dispose();
            }
        }
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            foreach (var control in e.Form.Controls)
            {
                SimpleButton button = control as SimpleButton;
                if (button != null)
                {
                    // button.Height = 25;
                    switch (button.DialogResult.ToString())
                    {
                        case ("OK"):
                            break;
                        case ("Cancel"):
                            break;
                        case ("Retry"):
                            break;
                    }
                }
            }
        }
        private void ürünGenelParametreAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmAyarlarUrunGenel());
        }

        private void urunozellik_Click(object sender, EventArgs e)
        {
            OpenForm(new frmAyarlarUrun());

            //pnlForm.Controls.Clear();
            //frmAyarlarUrun f1 = new frmAyarlarUrun();
            //f1.TopLevel = false;
            //pnlForm.Controls.Add(f1);
            //f1.Show();
            ////f1.Dock = DockStyle.Fill;
            //f1.BringToFront();
        }

        private void depoTipiAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmDepoAc());
        }

        private void trendyolApiAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
