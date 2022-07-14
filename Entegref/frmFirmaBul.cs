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
    public partial class frmFirmaBul : Form
    {
        public frmFirmaBul()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        private void frmFirmaBul_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "select nFirmaID, sKodu, sAciklama from tbFirma where nFirmaID > 2";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            gridFirma.DataSource = dt;
        }

        private void ViewFirma_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            frmBarkod.nfirmaId = ViewFirma.GetRowCellValue(ViewFirma.FocusedRowHandle, "sKodu").ToString();
            this.Close();
            this.Dispose();
        }
    }
}
