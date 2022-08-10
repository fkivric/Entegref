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
using System.Xml;
using System.Data.Odbc;
using System.Threading;

namespace Entegref
{
    public partial class frmDoviz : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        SqlConnectionObject conn = new SqlConnectionObject(); 
        decimal lMerkezBankasiAlisKuru;
        decimal lMerkezBankasiSatisKuru;
        decimal lAlis;
        decimal lSatis;
        string DovizCinsi;
        int row=0;
        public frmDoviz()
        {
            InitializeComponent();
        }
        private void frmDoviz_Load(object sender, EventArgs e)
        {
            string q = "select sDovizCinsi,dteKurTarihi,lMerkezBankasiAlisKuru,lMerkezBankasiSatisKuru,lAlisKuru,lSatisKuru from tbDovizKuru ";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridDoviz.DataSource = dt;
            row = gridDoviz.Rows.Count;
            gridDoviz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDoviz.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        public void Kurlar(string doviz)
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                lMerkezBankasiSatisKuru = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", doviz)).InnerText);
                lMerkezBankasiAlisKuru = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", doviz)).InnerText);
                lSatis = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", doviz)).InnerText);
                lAlis = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", doviz)).InnerText);
                return;
            }
            catch (XmlException xml)
            {
                MessageBox.Show(xml.ToString());
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
        private void btnDovizMerkez_Click(object sender, EventArgs e)
        {
            frmProgresBr progressForm = new frmProgresBr()
            {
                Start = 0,
                Finish = row,
                Position = 0,
            };

            int success = 0;
            int error = 0;
            this.Enabled = false;

            executeBackground(
       () =>
       {
           progressForm.Show(this);
           row = gridDoviz.Rows.Count;
           for (int i = 0; i < gridDoviz.Rows.Count; i++)
           {
               if (row >= 1)
               {


                   lMerkezBankasiAlisKuru = 0;
                   lMerkezBankasiSatisKuru = 0;
                   lAlis = 0;
                   lSatis = 0;
                   DovizCinsi = gridDoviz.Rows[i].Cells["sDovizCinsi"].Value.ToString();
                   Kurlar(DovizCinsi);

                   Dictionary<string, string> Kurupdate = new Dictionary<string, string>();
                   Kurupdate.Add("@sDovizCinsi", DovizCinsi.ToString());
                   Kurupdate.Add("@lMerkezBankasiAlisKuru", lMerkezBankasiAlisKuru.ToString());
                   Kurupdate.Add("@lMerkezBankasiSatisKuru", lMerkezBankasiSatisKuru.ToString());
                   Kurupdate.Add("@lAlisKuru", lAlis.ToString());
                   Kurupdate.Add("@lSatisKuru", lSatis.ToString());
                   Kurupdate.Add("@sKullanici", frmLogin.username);
                   conn.DfQuery("DovizUpdateMerkez", Kurupdate);
                   row--;
               }
           }
       },
                    null,
                     () =>
                     {
                         completeProgress();
                         progressForm.Hide(this);                        
                     });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}