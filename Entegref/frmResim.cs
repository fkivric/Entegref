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
    public partial class frmResim : DevExpress.XtraEditors.XtraForm
    {
        string sModel;
        public frmResim(string _sModel)
        {
            InitializeComponent();
            sModel = _sModel;
        }

        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);

        private void frmResim_Load(object sender, EventArgs e)
        {
            string q = "select distinct sKodu as [Ürün Adı],b.sAciklama as [Beden Adı],s.sBeden,k.sAciklama [Kavala],r.sRenkAdi as [Renk Adı],r.lRenkNo " +
                "from tbstok s " +
                "inner join tbRenk r on r.sRenk = s.sRenk " +
                "inner join tbBedenTipi b on b.sBedenTipi = s.sBedenTipi " +
                "inner join tbKavala k on k.sKavalaTipi = s.sKavalaTipi where sModel = '"+ sModel +"'";
            SqlCommand cmd = new SqlCommand(q, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gridResimler.DataSource = dt;
        }

        private void viewResimler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >=0 && e.Button == MouseButtons.Left && e.Clicks >= 2)
            {
                frmStokAc.sKodu = viewResimler.GetRowCellValue(viewResimler.FocusedRowHandle, "Ürün Adı").ToString();
                this.Close();
                this.Dispose();
            }
        }
    }
}