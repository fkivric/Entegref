using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Entegref
{
    public partial class frmYapılandırma : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        public static string Key;
        public frmYapılandırma()
        {
            InitializeComponent();
        }

        private void frmYapılandırma_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> PRM = new Dictionary<string, string>();
            PRM.Add("@VKN", "39391097764");
            var connection = conn.NTBQuery("ConnectionString", PRM);
            Properties.Settings.Default.CoudServerLocal = connection.Rows[0][0].ToString();
            uncheck1.Visible = false;
            uncheck2.Visible = false;
            simpleButton2.Enabled = false;
            simpleButton1.Visible = false;

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
            var dt = conn.NTBQuerySpOnly("İl");
            comboIl.DataSource = dt;
        }
        void ilce(string _semt)
        {
            combosemt.DisplayMember = "Semt";
            combosemt.ValueMember = "sira";
            Dictionary<string, string> Semt = new Dictionary<string, string>();
            Semt.Add("@ilid", _semt);
            var dt = conn.NTBQuery("semt", Semt);
            combosemt.DataSource = dt;
            
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)
            {
                simpleButton1.Visible = true;
                navigationFrame1.SelectedPage = navigationPage2;
                bunifuCheckbox1.Checked = true;
            }
            else if (navigationFrame1.SelectedPage == navigationPage2)
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
                    simpleButton2.Enabled = false;
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
                simpleButton2.Enabled = false;
            }
            else if (navigationFrame1.SelectedPage == navigationPage5)
            {
                navigationFrame1.SelectedPage = navigationPage6;
                bunifuCheckbox5.Checked = true;
            }
            else if (navigationFrame1.SelectedPage == navigationPage6)
            {
                navigationFrame1.SelectedPage = navigationPage7;
                bunifuCheckbox6.Checked = true;
            }
            else if (navigationFrame1.SelectedPage == navigationPage7)
            {
                navigationFrame1.SelectedPage = navigationPage8;
                bunifuCheckbox7.Checked = true;

            }
            else if (navigationFrame1.SelectedPage == navigationPage8)
            {
                navigationFrame1.SelectedPage = navigationPage9;
                bunifuCheckbox8.Checked = true;

                var name = Properties.Settings.Default.ToString();
                simpleButton2.Text = "Bitir";

                var assembly = typeof(Program).Assembly;
                var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
                var id = attribute.Value;

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Entegref");
                key.SetValue("ApplicationSetupComplate", "true");
                key.SetValue("ApplicationGUID", id);
                key.Close();

                RegistryKey odbc = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ODBC\ODBC.INI\Entegref");
                key.SetValue("Driver", "C:\\WINDOWS\\system32\\SQLSRV32.dll");
                key.SetValue("Description", "Entegref");
                key.SetValue("Server", "185.184.26.206");
                key.SetValue("Database", txtVKN.Text);
                key.SetValue("Language" , "Türkçe");
                key.SetValue("LastUser", "fatih");

            }
            else
            {
                frmMain main = new frmMain();
                this.WindowState = FormWindowState.Minimized;
                main.ShowDialog();
                this.Close();
                this.Dispose();

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
            var database = conn.NTBQuery("DbList", keys);

            Properties.Settings.Default.VKN = txtVKN.Text;

            if (database.Rows[0][1].ToString() == "0")
            {
                Dictionary<string, string> db = new Dictionary<string, string>();
                db.Add("@name", "["+txtVKN.Text.ToString()+"]");
                var sonuc = conn.NTBQuery("create_databas", db);

            }

            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sFirmaAdi", txtFirmaAdi.Text);
            Prm.Add("@sVergiNumarasi", txtVKN.Text);
            Prm.Add("@sVergiDairesi", txtVergiDairesi.Text);
            Prm.Add("@sIl", comboIl.Text);
            Prm.Add("@sSemt", combosemt.Text);
            Prm.Add("@sFirmaAdresi", ultraTextEditor5.Text +" "+ ultraTextEditor6.Text+" " + ultraTextEditor7.Text);
            Prm.Add("@sTelefon1", txtMobil1.Text);
            Prm.Add("@sTelefon2", txtMobil2.Text);
            Prm.Add("@sTelefon3", txtMobil2.Text);
            Prm.Add("@sEmail", txtMail1.Text);
            if (checkBox1.Checked==true)
            {
                Prm.Add("@bHareketTipiVarmi", "1");
            }
            else
            {
                Prm.Add("@bHareketTipiVarmi", "0");
            }

            if (checkBox2.Checked == true)
            {
                Prm.Add("@bKurusKullanilacakmi", "1");
            }
            else
            {
                Prm.Add("@bKurusKullanilacakmi", "0");
            }
            if (checkBox3.Checked == true)
            {
                Prm.Add("@bBirimTldeKurusVarmi", "1");
            }
            else
            {
                Prm.Add("@bBirimTldeKurusVarmi", "0");
            }
            if (checkBox5.Checked == true)
            {
                Prm.Add("@bDepoVarmi", "1");
            }
            else
            {
                Prm.Add("@bDepoVarmi", "0");
            }
            if (checkBox6.Checked == true)
            {
                Prm.Add("@bEksiyeDusulebilirmi", "1");
            }
            else
            {
                Prm.Add("@bEksiyeDusulebilirmi", "0");
            }
            Prm.Add("@sFormatMiktar", comboBoxEdit1.SelectedText);
            conn.NTBLInsert("ParamGenelUpdate", Prm);

            SKGL.Generate generate = new SKGL.Generate();
            generate.secretPhase = txtVKN.Text;
            Properties.Settings.Default.SecretPhase = generate.doKey(Convert.ToInt32("365"));




            simpleButton1.Enabled = false;
            simpleButton2.Enabled = true;
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
            simpleButton4.Enabled = false;
            simpleButton1.Enabled = false;
            simpleButton2.Enabled = true;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked==true)
            {
                simpleButton2.Enabled = true;
            }
            else
            {
                simpleButton2.Enabled = false;
            }
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            //The below are optional, of course,

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;

            toolTip1.SetToolTip(label22, "Merkez & Depo veya Çoklu Sevk ve Stok tutulması durumunda seçiniz!");

        }

        private void label27_MouseHover(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            //The below are optional, of course,

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(label27, "Elinizde Olmayan Ürünün Satışına İzin Verir");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new System.Data.SqlClient.SqlConnection("Server=185.184.26.206;Database=Netbil_Connector; User ID=fatih;Password=05101981;");
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into "+txtVKN.Text+ ".dbo.tbWinnerKullanici(sKullaniciKodu, sAdi, sSoyadi, sEMail,parola) values(@sKullaniciKodu, @sAdi, @sSoyadi, @sEMail,@parola)");
            cmd.Parameters.AddWithValue("@sKullaniciKodu", txtsKullaniciKodu.Text);
            cmd.Parameters.AddWithValue("@parola", txtParola.Text);
            cmd.Parameters.AddWithValue("@sAdi", txtsKullaniciKodu.Text);
            cmd.Parameters.AddWithValue("@sSoyadi", txtsKullaniciKodu.Text);
            cmd.Parameters.AddWithValue("@sEMail", txtsKullaniciKodu.Text);
            cmd.ExecuteScalar();

        }
    }
}
