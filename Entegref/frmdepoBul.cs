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
    public partial class frmdepoBul : DevExpress.XtraEditors.XtraForm
    {
        int formadı = 0;
        public frmdepoBul(int _Formadi)
        {
            InitializeComponent();
            formadı = _Formadi;
        }
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        private void frmFirmaBul_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "";
            if (formadı == 1)
            {
                query = "select distinct case when sDepo like 'B%' then SUBSTRING(sDepo,2,4) else sDepo end as sKodu, sAciklama from tbdepo where sdepo not like 'B%' and sDepo != ''";
            }
            else if (formadı == 2)
            {
                query = "select distinct sDepo as sKodu, sAciklama from tbdepo where sdepo like 'B%'";
            }
            else if (formadı == 3)
            {
                query = "select distinct sDepoTipi as sKodu, sAciklama from tbDepoTipi where sDepoTipi not in ('','0002')";
            }
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            gridDepo.DataSource = dt;
        }

        private void ViewDepo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                if (formadı == 1)
                {
                    frmFis_Transfer.depo1 = ViewDepo.GetRowCellValue(ViewDepo.FocusedRowHandle, "sKodu").ToString();
                    this.Close();
                    this.Dispose();
                }

                if (formadı == 2)
                {
                    frmFis_Transfer.depo2 = ViewDepo.GetRowCellValue(ViewDepo.FocusedRowHandle, "sKodu").ToString();
                    this.Close();
                    this.Dispose();
                }

                if (formadı == 3)
                {
                    frmDepoAc.DepoTipi = ViewDepo.GetRowCellValue(ViewDepo.FocusedRowHandle, "sKodu").ToString();
                    frmDepoAc.DepoTipiAdi = ViewDepo.GetRowCellValue(ViewDepo.FocusedRowHandle, "sAciklama").ToString();
                    this.Close();
                    this.Dispose();
                }
                //frmStokAc.sModel = ViewDepo.GetRowCellValue(ViewDepo.FocusedRowHandle, "sKodu").ToString();
                //this.Close();
                //this.Dispose();
            }

        }
    }
}
