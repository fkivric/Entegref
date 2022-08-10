using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Entegref
{

    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);

        private void frmMain_Load(object sender, EventArgs e)
        {
           if (frmLogin.loginok != true)
            {
                frmLogin frmLogin = new frmLogin(Properties.Settings.Default.VKN);
                frmLogin.ShowDialog();
                this.Close();
                this.Dispose();
            }
        }
        private BackgroundWorker _backgroundWorker;
        private ManualResetEvent _workerCompletedEvent = new ManualResetEvent(false);
        private const string READY_TEXT = "Hazır";
        private void executeBackground(Action doWorkAction, Action progressAction = null, Action completedAction = null)
        {
            try
            {
                if (_backgroundWorker != null)
                {


                    if (_backgroundWorker.IsBusy)
                    {
                        //XtraMessageBox.Show("Her oturum açıldığında 1 işlem yapacak. Eğer bu girişteki ilk işlemse uygulama çalışmaktadır. Lütfen Bekleyiniz");
                        return;
                    }
                }
                _backgroundWorker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true
                };
                _backgroundWorker.DoWork += (x, y) =>
                {
                    try
                    {
                        doWorkAction.Invoke();
                    }
                    catch (Exception ex)
                    {
                        y.Cancel = true;
                        XtraMessageBox.Show("Bilinmeyen Hata. Detay : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // throw;
                    }
                };
                if (progressAction != null)
                {
                    _backgroundWorker.ProgressChanged += (x, y) =>
                    {
                        progressAction.Invoke();
                    };
                }
                if (completedAction != null)
                {
                    _backgroundWorker.RunWorkerCompleted += (x, y) =>
                    {
                        completedAction.Invoke();
                    };
                }
                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception)
            {

            }

        }

        private void completeProgress()
        {
            try
            {
                _backgroundWorker.Dispose();
                _backgroundWorker = null;
                if (!this.Enabled)
                {
                    this.Enabled = true;
                }

            }
            finally
            {
                //this.Cursor = Cursors.Default;
                _workerCompletedEvent.Set();

            }
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
                case "13":
                    OpenForm(new frmStokToplu());
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

        int show = 0;

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (show == 0)
            {
                Point MousePosition = this.Location;
                MousePosition.Offset(this.Width / 2, this.Height / 2);
                radialMenu1.ShowPopup(MousePosition);
            }
            else
            {
                radialMenu1.HidePopup();
                show = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Kurzamanı;
            Kurzamanı = DateTime.Now.ToShortTimeString();
            if (Kurzamanı == "17:30")
            {
                
            }
            else
            {
                timer1.Stop();
            }
        }
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmDoviz());
        }

        private void barWorkspaceMenuItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
