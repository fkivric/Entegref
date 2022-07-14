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
    public partial class frmStokSinifi : Form
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
        DataTable sf1 = new DataTable();
        DataTable sf2 = new DataTable();
        DataTable sf3 = new DataTable();
        DataTable sf4 = new DataTable();
        DataTable sf5 = new DataTable();
        DataTable sf6 = new DataTable();
        public frmStokSinifi()
        {
            InitializeComponent();
        }

        private void frmStokSinifi_Load(object sender, EventArgs e)
        {
            ultraComboEditor1.DisplayMember = "sAciklama";
            ultraComboEditor1.ValueMember = "sSinifKodu";

            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@id", "0");
            Param.Add("@sira", "1");
            sf1 = conn.Query2("TrendYol", Param);
            ultraComboEditor1.DataSource = sf1;

        }
    }
}
