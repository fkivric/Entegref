using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Entegref
{
    public partial class frmYapılandırma : Form
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        public frmYapılandırma()
        {
            InitializeComponent();
        }

        private void frmYapılandırma_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> PRM = new Dictionary<string, string>();
            PRM.Add("@VKN", "39391097764");
            var connection = conn.Query("ConnectionString", PRM);
            Properties.Settings.Default.connectionstring = connection.Rows[0][0].ToString();
            uncheck1.Visible = false;
            uncheck2.Visible = false;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage4)
            {
                if (grpErpSec.SelectedIndex.ToString() == "0")
                {
                    navigationFrame1.SelectedPage = navigationPage3;
                }
                else if (grpErpSec.SelectedIndex.ToString() == "1")
                {
                    navigationFrame1.SelectedPage = navigationPage2;
                }

            }
            else if (navigationFrame1.SelectedPage == navigationPage2)
            {
                navigationFrame1.SelectedPage = navigationPage1;
                //int index = checkedListBoxControl1.FindString("Ayarlar");
                //checkedListBoxControl1.SetItemChecked(index, false);
            }
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                navigationFrame1.SelectedPage = navigationPage2;
                bunifuCheckbox2.Checked = false;
            }
            else if (navigationFrame1.SelectedPage == navigationPage5)
            {
                navigationFrame1.SelectedPage = navigationPage4;
                bunifuCheckbox2.Checked = false;
            }
            else if (navigationFrame1.SelectedPage == navigationPage6)
            {
                navigationFrame1.SelectedPage = navigationPage5;
                bunifuCheckbox2.Checked = false;
            }
            else if (navigationFrame1.SelectedPage == navigationPage7)
            {
                navigationFrame1.SelectedPage = navigationPage6;
                bunifuCheckbox2.Checked = false;
            }
            else if (navigationFrame1.SelectedPage == navigationPage8)
            {
                navigationFrame1.SelectedPage = navigationPage7;
                bunifuCheckbox2.Checked = false;
            }
        }
        void IL()
        {
            comboIl.DisplayMember = "İl";
            comboIl.ValueMember = "sira";
            var dt = conn.Query1("İl");
            comboIl.DataSource = dt;
        }
        void ilce(string _semt)
        {
            combosemt.DisplayMember = "Semt";
            combosemt.ValueMember = "sira";
            Dictionary<string, string> Semt = new Dictionary<string, string>();
            Semt.Add("@ilid", _semt);
            var dt = conn.Query("semt", Semt);
            combosemt.DataSource = dt;
            
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)
            {
                navigationFrame1.SelectedPage = navigationPage2;
                bunifuCheckbox1.Checked = true;
            }
            else if (navigationFrame1.SelectedPage==navigationPage2)
            {
                if (grpErpSec.SelectedIndex.ToString() == "1")
                {
                    navigationFrame1.SelectedPage = navigationPage4;
                    simpleButton1.Visible = true;
                }
                else if (grpErpSec.SelectedIndex.ToString() == "0")
                {
                    navigationFrame1.SelectedPage = navigationPage3;
                    bunifuCheckbox2.Checked = true;
                    IL();
                    simpleButton1.Visible = true;
                    uncheck2.Visible = true;
                }

            }
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                navigationFrame1.SelectedPage = navigationPage5;
                bunifuCheckbox3.Checked = true;
                int index = checkedListBoxControl1.FindString("ERP");
                if (checkedListBoxControl1.Items[0].CheckState == CheckState.Checked)
                {
                    checkedListBoxControl1.SetItemChecked(index, true);
                }
            }
            else if (navigationFrame1.SelectedPage == navigationPage4)
            {
                navigationFrame1.SelectedPage = navigationPage5;
                bunifuCheckbox2.Checked = true;
                int index = checkedListBoxControl1.FindString("ERP");
                if (checkedListBoxControl1.Items[0].CheckState == CheckState.Checked)
                {
                    checkedListBoxControl1.SetItemChecked(index, true);
                }
            }
            else if (navigationFrame1.SelectedPage == navigationPage5)
            {
                navigationFrame1.SelectedPage = navigationPage6;
                bunifuCheckbox5.Checked = true;
            }
            else if (navigationFrame1.SelectedPage == navigationPage6)
            {
                navigationFrame1.SelectedPage = navigationPage7;
                bunifuCheckbox3.Checked = true;
            }
            else if (navigationFrame1.SelectedPage == navigationPage7)
            {
                navigationFrame1.SelectedPage = navigationPage8;
                bunifuCheckbox3.Checked = true;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ultraTextEditor4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilce(comboIl.SelectedValue.ToString());
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("@VKN", txtVKN.Text.ToString());
            var database = conn.Query("DbList", keys);

            if (database.Rows[0][1].ToString() == "0")
            {
                Dictionary<string, string> db = new Dictionary<string, string>();
                db.Add("@name", "["+txtVKN.Text.ToString()+"]");
                var sonuc = conn.Query("create_databas", db);

            }

            simpleButton1.Enabled = false;
            uncheck2.Visible = true;
            bunifuCheckbox4.Visible = false;
            bunifuCheckbox3.Checked = true;
            simpleButton3.Enabled = false;
        }
        public static string Pazaryeri;
        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxControl1.CheckedItems)
            {
                Pazaryeri = item.ToString();
            }
            if (Pazaryeri != "TRENDYOL")
            {
                checkedListBoxControl1.UnCheckAll();
                pnlTrendyol.Visible = false;
            }
            else
            {
                pnlTrendyol.Visible = true;
                pnlTrendyol.Dock = DockStyle.Fill;
            }
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            foreach (var item in checkedListBoxControl1.CheckedItems)
            {
                Pazaryeri = item.ToString();
            }
            if (Pazaryeri != "TRENDYOL" )
            {
                checkedListBoxControl1.UnCheckAll();
                pnlTrendyol.Visible = false;
            }
            else
            {
                pnlTrendyol.Visible = true;
                pnlTrendyol.Dock = DockStyle.Fill;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TrendyolApi = txttrendyolApi.Text;
            Properties.Settings.Default.TrendyolId = txttrendyolID.Text;
            Properties.Settings.Default.TrendyolSecretkey = txttrendyolSecret.Text;

        }

    }
}
