using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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

            try
            {
                FluentSplashScreenOptions splashScreen = new FluentSplashScreenOptions();
                splashScreen.Title = "ENTEGREF";
                splashScreen.Subtitle = "Entegref ERP & Pazaryeri";
                splashScreen.RightFooter = "Başlıyor...";
                splashScreen.LeftFooter = $"CopyRight ® 2022 {Environment.NewLine} Tüm Hahkları Saklıdır.";
                splashScreen.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
                splashScreen.OpacityColor = System.Drawing.Color.FromArgb(16, 110, 190);
                splashScreen.Opacity = 90;
                splashScreen.AppearanceLeftFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowFluentSplashScreen(splashScreen, parentForm: this, useFadeIn: true, useFadeOut: true);
                InitializeComponent();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false, 300, this);
            }

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
                    OpenForm(new frmDepo());
                    break;
                case "23":
                    OpenForm(new frmFis_Transfer());
                    break;
                case "31":
                    OpenForm(new frmFirma());
                    break;
                case "61":
                    OpenForm(new frmKargo());
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
        public static int cicektimer = 0;
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

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmTrendyol_MusteriSorları());
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmTrendyol_Ürün_Aktif());
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmTrendyol_Create_Item());
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmTrendyol_Siparis());
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool sonuc = true;
            OpenForm(new frmTrendyol_Finans(sonuc));
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool sonuc = false;
            OpenForm(new frmTrendyol_Finans(sonuc));
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmTrendyol_FirmaAdresBilgisi());
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmCicekSepeti_Category cicekSepeti_Category = new frmCicekSepeti_Category();
            //cicekSepeti_Category.ShowDialog();
            OpenForm(new frmCicekSepeti_Category());
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FrmTicimax_Ayarlar());
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            timer2.Start();
            OpenForm(new frmCicekSepeti_Ürün_Aktif());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            frmMain.cicektimer = frmMain.cicektimer + 1;
            frmCicekSepeti_Ürün_Aktif.sure = (600 - frmMain.cicektimer).ToString() + " Yeni Sorgu için kalan süre";
            if (frmMain.cicektimer == 600)
            {
                frmMain.cicektimer = 0;
                timer1.Stop();
            }
        }
    }
}