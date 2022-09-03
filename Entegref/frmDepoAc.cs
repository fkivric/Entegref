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
    public partial class frmDepoAc : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        SqlConnectionObject conn = new SqlConnectionObject();
        public static string DepoTipi = "";
        public static string DepoTipiAdi ="";
        public frmDepoAc()
        {
            InitializeComponent();
        }

        private void frmDepoAc_Load(object sender, EventArgs e)
        {
            Depolar();
            DepoKodu("");
        }

        public void DepoKodu(string _depokodu)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            dp.Add("@depotipi", _depokodu);            
            var dpsonuc = conn.DfQuery("Entegref_New_WareHouse", dp);
            txtDepoKodu.Text = dpsonuc.Rows[0][0].ToString();
        }
        public void Depolar()
        {
            gridDepo.DataSource = null;
            string q = "select sDepo,d.sAciklama as depoadi,f.sAciklama as firma,t.sAciklama as depotipi, f.sAdres1 + ' ' + f.sAdres2 as adress,f.sVergiDairesi,sVergiNo from tbDepo d "
            + "inner join tbFirma f on f.nFirmaID = d.nFirmaID "
            + "inner join tbDepoTipi t on t.sDepoTipi = d.sDepoTipi where sDepo !='' order by replace(d.sAciklama,'B','') ";
            SqlCommand cmd = new SqlCommand(q, sql);
            DataTable depo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(depo);
            gridDepo.DataSource = depo;

        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            //The below are optional, of course,

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;

            toolTip1.SetToolTip(linkLabel1, "Mevcut Firma Carisi ile otomatik açılır. Franchise olarak açılacaksa değiştirin");
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            //The below are optional, of course,

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;

            toolTip1.SetToolTip(linkLabel2, "Eğer Sevk veya Satış Depo / Mağaza dışında açılacak ise değiştirn");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toolTip1 = new ToolTip();
            //The below are optional, of course,

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;

            toolTip1.SetToolTip(linkLabel1, "Mevcut Firma Carisi ile otomatik açılır. Franchise olarak açılacaksa değiştirin");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toolTip1 = new ToolTip();
            //The below are optional, of course,

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;

            toolTip1.SetToolTip(linkLabel2, "Eğer Sevk veya Satış Depo / Mağaza dışında açılacak ise değiştirn");

        }

        private void ultraMaskedEdit1_MaskChanged(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs e)
        {

        }

        private void btnDepoTipi_Click(object sender, EventArgs e)
        {
            frmdepoBul frmdepoBul = new frmdepoBul(3);
            frmdepoBul.ShowDialog();
            txtDepoTipi.Tag = DepoTipi;
            txtDepoTipi.Text = DepoTipiAdi;

        }

        private void btnDepoDoviz_Click(object sender, EventArgs e)
        {
            
        }
    }
}