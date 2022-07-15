using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entegref
{
    public partial class frmFiyatTipi : Form
    {
        public frmFiyatTipi()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        SqlConnectionObject conn = new SqlConnectionObject();

        private void frmFiyatTipi_Load(object sender, EventArgs e)
        {
            DataTable fiyattipi = new DataTable();
            DataTable doviz = new DataTable();

            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            string query = "select sDovizCinsi, sAciklama as dovizadi from tbDovizCinsi";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(doviz);
            repositoryItemLookUpEdit1.DisplayMember = "sAciklama";
            repositoryItemLookUpEdit1.ValueMember = "sDovizCinsi";
            repositoryItemLookUpEdit1.DataSource = doviz;

            fiyattipi = conn.Query3("FiyatTipi");
            gridFiyatTipi.DataSource = fiyattipi;

        }

        private void ViewFiyatTipi_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                frmStokAc.sFiyatTipi = ViewFiyatTipi.GetRowCellValue(e.RowHandle, "Fiyat Tipi").ToString();
                this.Close();
                this.Dispose();
            }
        }
    }
}
