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
    public partial class frmStokBul : DevExpress.XtraEditors.XtraForm
    {
        public frmStokBul()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        private void frmFirmaBul_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "select nStokID, sKodu, sAciklama from tbstok where skodu != ''";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            gridStok.DataSource = dt;
        }

        private void ViewFirma_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                frmStokAc.sKodu = ViewStok.GetRowCellValue(ViewStok.FocusedRowHandle, "sKodu").ToString();
                this.Close();
                this.Dispose();
            }
        }
    }
}
