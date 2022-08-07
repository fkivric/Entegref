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
    public partial class frmDoviz : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        public frmDoviz()
        {
            InitializeComponent();
        }

        private void frmDoviz_Load(object sender, EventArgs e)
        {
            string q = "select sDovizCinsi,lMerkezBankasiAlisKuru,lMerkezBankasiSatisKuru,lAlisKuru,lSatisKuru from tbDovizKuru ";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridDoviz.DataSource = dt;
        }
    }
}