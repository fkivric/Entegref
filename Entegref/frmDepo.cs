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
    public partial class frmDepo : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        public frmDepo()
        {
            InitializeComponent();
        }

        private void frmDepo_Load(object sender, EventArgs e)
        {
            string q = "select sDepo,d.sAciklama as depoadi,f.sAciklama as firma,t.sAciklama as depotipi, f.sAdres1 + ' ' + f.sAdres2 as adress,f.sVergiDairesi,sVergiNo from tbDepo d "
            + "inner join tbFirma f on f.nFirmaID = d.nFirmaID "
            + "inner join tbDepoTipi t on t.sDepoTipi = d.sDepoTipi where sDepo !='' order by replace(d.sAciklama,'B','') ";
            SqlCommand cmd = new SqlCommand(q, sql);
            DataTable depo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(depo);
            gridDepo.DataSource = depo;
        }
    }
}