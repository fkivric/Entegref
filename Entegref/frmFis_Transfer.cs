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
using System.Threading;
using System.Data.SqlClient;

namespace Entegref
{
    public partial class frmFis_Transfer : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        public static string depo1;
        public static string depo2;
        public static string skodu;
        public static string sacikalam;
        public static string stokId = "";
        public frmFis_Transfer()
        {
            InitializeComponent();
        }

        private BackgroundWorker _backgroundWorker;
        private ManualResetEvent _workerCompletedEvent = new ManualResetEvent(false);
        private const string READY_TEXT = "Hazır";
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

        private void executeBackground(Action doWorkAction, Action progressAction = null, Action completedAction = null)
        {
            try
            {
                if (_backgroundWorker != null)
                {
                    if (_backgroundWorker.IsBusy)
                    {
                        XtraMessageBox.Show("Lütfen Bekleyiniz");
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
        private void frmTransferFisi_Load(object sender, EventArgs e)
        {
            dteFisTarihi.DateTime = DateTime.Now;
        }

        private void btnCikandepo_Click(object sender, EventArgs e)
        {
            frmdepoBul bul = new frmdepoBul(1);
            bul.ShowDialog();
            txtCikandepo.Text = depo1;
        }

        private void btnGirendepo_Click(object sender, EventArgs e)
        {
            frmdepoBul bul = new frmdepoBul(2);
            bul.ShowDialog();
            txtGirendepo.Text = depo2;
        }

        private void btnTamamlanmamis_Click(object sender, EventArgs e)
        {

        }

        private void btnFisno_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtCikandepo.Text == null && txtCikandepo.Text == "")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 5000;
                args.Caption = "İşlem Sırası Uyarı";
                args.Text = "Çıkan Depo Boş Olamaz. Bir Depo Seçin";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                XtraMessageBox.Show(args).ToString();
            }
            else if (txtGirendepo.Text == null && txtGirendepo.Text == "")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 5000;
                args.Caption = "İşlem Sırası Uyarı";
                args.Text = "Giren Depo Boş Olamaz. Bir Depo Seçin";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                XtraMessageBox.Show(args).ToString();

            }
            else if (txtFisNo.Text == null || txtFisNo.Text == "")
            {
                Dictionary<string, string> fis = new Dictionary<string, string>();
                fis.Add("@sfisTipi","MI");
                var sonuc = conn.DfQuery("Entegref_Yetki", fis);
                if (sonuc.Rows[0]["sonuc"].ToString() == "0")
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 5000;
                    args.Caption = "İşlem Sırası Uyarı";
                    args.Text = "Fiş No Elle verile ayarlı! Fiş Nosu giriniz";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    XtraMessageBox.Show(args).ToString();
                }
                else
                {
                    Dictionary<string, string> fisno = new Dictionary<string, string>();
                    fisno.Add("@sfisTipi", "MI");
                    fisno.Add("@sdepo", frmLogin.sdepo);
                    var No = conn.DfQuery("Entegref_FisNo", fisno);
                    txtFisNo.Text = No.Rows[0][0].ToString();
                    grpFisBilgisi.Enabled = false;
                    pnlEkleme.Enabled = true;
                    gridSevkFisi.Enabled = true;
                }
            }
            else
            {
                grpFisBilgisi.Enabled = false;
                pnlEkleme.Enabled = true;
                gridSevkFisi.Enabled = true;
            }
        }

        private void btnStokBul_Click(object sender, EventArgs e)
        {
            frmStokBul stokBul = new frmStokBul(2);
            stokBul.ShowDialog();
            txtKod.Text = skodu;
            txtAciklama.Text = sacikalam;
        }

        private void txtFisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public class Satir
        {

            public string stokid { get; set; }

            public string stokkodu { get; set; }

            public string stokadi { get; set; }

            public string adet { get; set; }

            public string fiyattipi { get; set; }

            public string fiyat { get; set; }

            public string fiyattoplam { get; set; }

            public string cikanraf { get; set; }

            public string girenraf { get; set; }

            public string aciklama { get; set; }

        }
        List<Satir> satirlar = new List<Satir>();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text != "")
            {


                string stokid = "", stokkodu = "", stokadi = "", adet = "", fiyattipi = "", fiyat = "", cikanraf = "", girenraf = "", aciklama = "";

                stokid = stokId;
                stokkodu = txtKod.Text;
                stokadi = txtAciklama.Text;
                adet = txtAdet.Text;
                fiyattipi = cmbFiyatTipi.Text.ToString();
                fiyat = txtFiyat.Text;
                cikanraf = txtraf1.Text;
                girenraf = txtraf2.Text;
                aciklama = txtricAciklama.Text;

                //var ss = (int.Parse(fiyat) * int.Parse(adet)).ToString();

                satirlar.Add(new Satir
                {
                    stokid = stokid,
                    adet = adet,
                    stokkodu = stokkodu,
                    stokadi = stokadi,
                    fiyattipi = fiyattipi,
                    fiyat = fiyat,
                    fiyattoplam = "",//(int.Parse(fiyat)*int.Parse(adet)).ToString(),
                    cikanraf = cikanraf,
                    girenraf = girenraf,
                    aciklama = aciklama
                });
                bool kontrol = false;

                for (int i = 0; i < viewSevkFisi.DataRowCount - 1; i++)
                {
                    if (viewSevkFisi.GetRowCellValue(i, "stokkodu").ToString() == txtKod.Text)
                    {
                        double adet1 = double.Parse(txtAdet.Text);
                        double adet2 = double.Parse(viewSevkFisi.GetRowCellValue(i, "adet").ToString());
                        var newvalue = adet1 + adet2;
                        viewSevkFisi.SetRowCellValue(i, "adet", newvalue);
                        kontrol = true;

                        XtraMessageBox.Show("Eklenmiş Olan Stok Tekrar Yeni Satır olarak Eklenemez...! Adet Güncellendi");
                        txtKod.Text = null;
                        txtAciklama.Text = null;
                        txtAdet.Text = null;
                        txtFiyat.Text = null;
                        txtraf1.Text = null;
                        txtraf2.Text = null;
                        txtricAciklama.Text = null;
                        return;
                    }
                }
                if (kontrol == false)
                {
                    gridSevkFisi.DataSource = null;
                    gridSevkFisi.DataSource = satirlar;
                }

                txtKod.Text = null;
                txtAciklama.Text = null;
                txtAdet.Text = null;
                txtFiyat.Text = null;
                txtraf1.Text = null;
                txtraf2.Text = null;
                txtricAciklama.Text = null;
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 5000;
                args.Caption = "İşlem Sırası Uyarı";
                args.Text = "Adet Giriniz..!";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                XtraMessageBox.Show(args).ToString();
            }
        }

        private void txtAciklama_TextChanged(object sender, EventArgs e)
        {
            cmbFiyatTipi.DisplayMember = "sFiyatTipi";
            cmbFiyatTipi.ValueMember = "lFiyat";
            DataTable fiyattipi = new DataTable();
            string q = "select sFiyatTipi, lFiyat from tbStokFiyati where nStokID = '" + stokId + "'";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(fiyattipi);
            cmbFiyatTipi.DataSource = fiyattipi;
        }

        private void cmbFiyatTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFiyat.Text != "" && txtAdet.Text != "")
            {
                txtFiyat.Text = cmbFiyatTipi.SelectedValue.ToString();
                decimal adet = decimal.Parse(txtAdet.Text);
                decimal fiyat = decimal.Parse(txtFiyat.Text);
                decimal toplam = adet * fiyat;
                txtToplamFiyat.Text = toplam.ToString();
            }
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            if (txtAdet.Text != "" && txtFiyat.Text != "")
            {
                decimal adet = decimal.Parse(txtAdet.Text);
                decimal fiyat = decimal.Parse(txtFiyat.Text);
                decimal toplam = adet * fiyat;
                txtToplamFiyat.Text = toplam.ToString();
            }
        }
    }                         
}