using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Entegref
{    
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring2);
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Aquamarine;
            this.TransparencyKey = Color.Aquamarine;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            string query = "SELECT [Company_VKN],[Company_Name],DATEADD(YEAR,1,ConnectionCreateDate),ConnectionComplate FROM [Netbil_Connector].[dbo].[DB_Company] c inner join DB_Connection_Settings s on s.ConnectionCompanyID = c.id";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows[0][3].ToString() == "0")
            {
                frmYapılandırma yapılandırma = new frmYapılandırma();
                yapılandırma.ShowDialog();
            }
            else
            {
                frmMain main = new frmMain();
                main.ShowDialog();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
            this.Close();
            this.Dispose();
        }
    }
}
