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
    public partial class frmBarkod : Form
    {
        public static string skodu = "";
        public static string nfirmaId = "";
        public frmBarkod(string _skodu)
        {
            InitializeComponent();
            skodu = _skodu;
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        private void fmBarkod_Load(object sender, EventArgs e)
        {
            Yenile();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                txtBarkod.MaxLength = 13;
            }
            else
            {
                txtBarkod.MaxLength = 20;
            }
        }
        void Yenile()
        {
            using (System.Data.SqlClient.SqlConnection sql = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.connectionstring))
            {
                string query = "select sBarkod,(select sKodu from tbfirma f where f.nFirmaID = b.nFirmaID) as sFirmaKodu,sKarsiStokKodu,sKarsiStokAciklama from [39391097764].dbo.tbStokBarkodu b ";
                query = query + " inner join [39391097764].dbo.tbStok s on s.nStokID = b.nStokID";
                query = query + " where s.sKodu = '"+ skodu.ToString() +"'";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, sql);
                sql.Open();
                System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataTable dr = new DataTable();
                ad.Fill(dr);
                sql.Close();
                gridBarkod.DataSource = dr;
            }
            //    Dictionary<string, string> Prm = new Dictionary<string, string>();
            //Prm.Add("@skodu", skodu.ToString().Replace(" ",""));
            //var dt = conn.Query2("Barkod", Prm);
            //gridBarkod.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmFirmaBul firmaBul = new frmFirmaBul();
            firmaBul.Show();
            txtFirma.Text = nfirmaId;

        }

        private void ViewBarkod_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtBarkod.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sBarkod").ToString();
            txtFirma.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sFirmaKodu").ToString();
            txtFirmaStokKod.Text= ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sKarsiStokKodu").ToString();
            txtFirmaStokAd.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sKarsiStokAciklama").ToString();
            btnBarkodIslem.Text = "SİL";
            Yenile();
        }

        private void btnBarkodSil_Click(object sender, EventArgs e)
        {
            txtBarkod.Text = "";
            txtFirma.Text = "";
            txtFirmaStokKod.Text = "";
            txtFirmaStokAd.Text = "";
            btnBarkodIslem.Text = "Ekle";
            Yenile();
        }

        private void btnBarkodIslem_Click(object sender, EventArgs e)
        {
            if (btnBarkodIslem.Text == "Ekle")
            {
                Dictionary<string, string> barkodekle = new Dictionary<string, string>();
                barkodekle.Add("@islem", "0");
                barkodekle.Add("@sStokKodu", skodu);
                barkodekle.Add("@sBarkod", txtBarkod.Text);
                barkodekle.Add("@sFirmaKodu", txtFirma.Text);
                barkodekle.Add("@sKarsiStokKodu", txtFirmaStokKod.Text);
                barkodekle.Add("@sKarsiStokAciklama", txtFirmaStokAd.Text);
                barkodekle.Add("@ReturnDesc", "");
                var sonuc = conn.Insert2("BarkodEkle", barkodekle);
                MessageBox.Show(sonuc);

                txtBarkod.Text = "";
                txtFirma.Text = "";
                txtFirmaStokKod.Text = "";
                txtFirmaStokAd.Text = "";
                btnBarkodIslem.Text = "Ekle";
                Yenile();
            }
            else
            {

                Dictionary<string, string> barkodekle = new Dictionary<string, string>();
                barkodekle.Add("@islem", "1");
                barkodekle.Add("@sStokKodu", skodu);
                barkodekle.Add("@sBarkod", txtBarkod.Text);
                barkodekle.Add("@sFirmaKodu", txtFirma.Text);
                barkodekle.Add("@sKarsiStokKodu", txtFirmaStokKod.Text);
                barkodekle.Add("@sKarsiStokAciklama", txtFirmaStokAd.Text);
                barkodekle.Add("@ReturnDesc", "");
                var sonuc = conn.Insert2("BarkodEkle", barkodekle);

                txtBarkod.Text = "";
                txtFirma.Text = "";
                txtFirmaStokKod.Text = "";
                txtFirmaStokAd.Text = "";
                btnBarkodIslem.Text = "Ekle";
                Yenile();
            }
        }
    }
}
