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
    public partial class frmRenk : DevExpress.XtraEditors.XtraForm
    {
        public frmRenk()
        {
            InitializeComponent();
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
        private void frmRenk_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Renk Kodu");
            listView1.Columns.Add("Renk Adı");
            string sRenk = "", sRenkAdi = "";
            string q = "select sRenk,sRenkAdi from tbRenk where sRenk != ''";
            SqlCommand cmd = new SqlCommand(q, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            DataTable dt = new DataTable();
            ad.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sRenk = dt.Rows[i][0].ToString();
                sRenkAdi = dt.Rows[i][1].ToString();
                string[] tamamı = { sRenk, sRenkAdi };
                ListViewItem item = new ListViewItem(tamamı);
                listView1.Items.Add(item);
            }

            
        }
    }
}