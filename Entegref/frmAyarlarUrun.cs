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
    public partial class frmAyarlarUrun : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        int toplam;
        string YeniBedenTipi = "";
        public frmAyarlarUrun()
        {
            InitializeComponent();
        }

        private void frmUrunAyarları_Load(object sender, EventArgs e)
        {
        }
        void Beden()
        {
            string query = "select * from tbBedenTipi ";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            da.Fill(dt);
            sql.Close();
            gridBedenTumu.DataSource = dt;
            toplam = ViewBedenTumu.RowCount+1;
            YeniBedenTipi = "0" + toplam.ToString();
        }
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Key == "0")
            {

            }
            if (ultraTabControl1.SelectedTab.Key == "1")
            {
                Beden();
                cmbBedenTipi.DisplayMember = "sAciklama";
                cmbBedenTipi.ValueMember = "sBedenTipi";
                string query = "select '' as sBedenTipi,'Seçiniz...' as sAciklama union select sBedenTipi,sAciklama from tbBedenTipi where sBedenTipi != '' order by 1,2";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
                da.Fill(dt);
                sql.Close();
                cmbBedenTipi.DataSource = dt;


            }
        }

        private void cmbBedenTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridBeden.DataSource = null;
            string value;
            if (cmbBedenTipi.SelectedValue.ToString() == "")
            {
                value = " ";
            }
            else
            {
                value = cmbBedenTipi.SelectedValue.ToString();
            }
            string query = "select * from tbBedenTipi where sBedenTipi = '" +value+ "'";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tekbeden = new DataTable();
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            da.Fill(tekbeden);
            sql.Close();
            gridBeden.DataSource = tekbeden;


        }

        private void btnBedenYeni_Click(object sender, EventArgs e)
        {
            if (btnBedenAc.Enabled == false)
            {
                cmbBedenTipi.SelectedIndex = 0;
                cmbBedenTipi.Enabled = false;
                txtBedenAdı.Enabled = true;
                btnBedenAc.Enabled = true;
                btnBedenYeni.Text = "Vazgeç";
            }
            else
            {

                cmbBedenTipi.Enabled = true;
                txtBedenAdı.Enabled = false;
                btnBedenAc.Enabled = false;
                btnBedenYeni.Text = "Yeni Oluştur";
            }
        }

        private void btnBedenAc_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sBedenTipi", YeniBedenTipi);
            Prm.Add("@sAciklama", txtBedenAdı.Text);
            Prm.Add("@sBeden1", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[0]).ToString());
            Prm.Add("@sBeden2", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[1]).ToString());
            Prm.Add("@sBeden3", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[2]).ToString());
            Prm.Add("@sBeden4", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[3]).ToString());
            Prm.Add("@sBeden5", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[4]).ToString());
            Prm.Add("@sBeden6", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[5]).ToString());
            Prm.Add("@sBeden7", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[6]).ToString());
            Prm.Add("@sBeden8", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[7]).ToString());
            Prm.Add("@sBeden9", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[8]).ToString());
            Prm.Add("@sBeden10", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[9]).ToString());
            Prm.Add("@sBeden11", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[10]).ToString());
            Prm.Add("@sBeden12", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[11]).ToString());
            Prm.Add("@sBeden13", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[12]).ToString());
            Prm.Add("@sBeden14", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[13]).ToString());
            Prm.Add("@sBeden15", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[14]).ToString());

            cmbBedenTipi.SelectedIndex = 0;
            txtBedenAdı.Text = null;
            cmbBedenTipi.Enabled = true;
            txtBedenAdı.Enabled = false;
            btnBedenAc.Enabled = false;
            gridBeden.DataSource = null;
            btnBedenYeni.Text = "Yeni Oluştur";
            Beden();
        }
    }
}