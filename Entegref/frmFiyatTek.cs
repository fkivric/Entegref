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
    public partial class frmFiyatTek : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);

        public static string sFiyatTipi = "";
        string nStokID;

        public frmFiyatTek()
        {
            InitializeComponent();
        }

        private void frmFiyatTek_Load(object sender, EventArgs e)
        {
            if (nStokID != null)
            {
                string q = "select nStokID,sFiyatTipi,lFiyat,dteFiyatTespitTarihi,sKullaniciAdi from tbStokFiyati where nStokID = '" + nStokID + "'";
                SqlCommand cmd = new SqlCommand(q, connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                ad.Fill(dt);
                gridFiyatlar.DataSource = dt;
                //gridTopluFiyat.DataSource = dt;
            }

        }

        private void grpFTipiSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grpFTipiSec.SelectedIndex.ToString() == "0")
            {
                pnlFiyatToplu.Visible = false;
                pnlTekfiyat.Visible = true;
                txtTipi.Text = null;
                gridFiyatlar.Visible = true;
                gridFiyatlar.Dock = DockStyle.Fill;
            }
            if (grpFTipiSec.SelectedIndex.ToString() == "1")
            {
                pnlFiyatToplu.Visible = true;
                pnlTekfiyat.Visible = false;
                txtTipi.Text = null;
                pnlFiyatToplu.Dock = DockStyle.Fill;
                gridFiyatlar.Visible = false;

                DataTable fiyat_yeni = new DataTable();
                string Fiyatsql = "select ff.nStokID,t.sFiyatTipi, t.sAciklama,dteFiyatTespitTarihi,lFiyat,0 from tbFiyatTipi t ";
                Fiyatsql = Fiyatsql + " left join(select f.nStokID,f.lFiyat, f.dteFiyatTespitTarihi, f.sFiyatTipi from tbStokFiyati f ";
                Fiyatsql = Fiyatsql + "inner join tbstok s on s.nStokID= f.nStokID where s.sKodu = isnull('" + txtStokKodu.Text + "','')";
                Fiyatsql = Fiyatsql + ") ff on ff.sFiyatTipi = t.sFiyatTipi";
                SqlCommand cmd = new SqlCommand(Fiyatsql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                da.Fill(fiyat_yeni);
                connection.Close();
                gridTopluFiyat.DataSource = fiyat_yeni;
            }
        }


        private void btnFiyatTipiAc_Click(object sender, EventArgs e)
        {
            sFiyatTipi = "";
            frmFiyatTipi fiyatTipi = new frmFiyatTipi(this.Name);
            fiyatTipi.ShowDialog();
            txtTipi.Text = sFiyatTipi;
        }

        private void btnFiyatTekSec_Click(object sender, EventArgs e)
        {
            pnlFiyatTek.Enabled = true;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string Queryable = "select nstokID from tbstok where skodu = '" + txtStokKodu.Text + "'";
            SqlCommand cmd = new SqlCommand(Queryable, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            connection.Close();
            nStokID = dt.Rows[0]["nstokID"].ToString();
        }
    }
}