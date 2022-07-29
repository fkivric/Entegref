using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MetroFramework.Forms;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data.Sql;

namespace Entegref
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        string VKN = null;
        public frmLogin(string _VKN)
        {
            InitializeComponent();
            Init_Data();
            if (VKN == null)
            {
                VKN = "39391097764";

                SKGL.Generate generate = new SKGL.Generate();
                generate.secretPhase = VKN;
                Properties.Settings.Default.SecretPhase = generate.doKey(Convert.ToInt32("365"));
            }
            else
            {
                VKN = _VKN;
            }
        }

        SqlConnectionObject conn = new SqlConnectionObject();
        SystemGuid SystemGuid= new SystemGuid();
        public string id;
        public string MachineName;
        public string UserName;
        public string TEMPFolder;
        public string pcname;


        string version;
        public static bool loginok = false;
        private string pcModeli;
        private string pcİsmi;
        private string ipAdresi;


        private void frmLogin_Load(object sender, EventArgs e)
        {

            SKGL.Validate validate = new SKGL.Validate();
            validate.secretPhase = VKN;
            validate.Key = Properties.Settings.Default.SecretPhase;
            txtLisansing.Text = "Başlanğıç Tarihi:" + validate.CreationDate + "\r\n" + "Sona Erme Tarihi:" + validate.ExpireDate + "\r\n" + "Kalan Gün:" + validate.DaysLeft;
            

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                lblversion.Text = "Version : " + ad.CurrentVersion.Major + "." + ad.CurrentVersion.Minor + "." + ad.CurrentVersion.Build + "." + ad.CurrentVersion.Revision;
                version = ad.CurrentVersion.Revision.ToString();
            }
            else
            {
                string _s1 = Application.ProductVersion; // versiyon
                lblversion.Text = "Version : " + _s1;
            }

            txtSecretPhease.Text = Properties.Settings.Default.SecretPhase;


            SystemGuid.ToString();
            var assembly = typeof(Program).Assembly;
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            id = attribute.Value;

            RegistryKey key2 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Entegref");
            var sonuc = key2.GetValue("ApplicationGUID");

            MachineName = Environment.MachineName;
            UserName = Environment.UserName;
            TEMPFolder = Environment.GetEnvironmentVariable("TEMP");
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry de in environmentVariables)
            {
                if (de.Key.ToString() == "VSLOGGER_UNIQUEID")
                {
                    pcname = de.Value.ToString();
                }
            }

            if (VKN != null)
            {
                txtDatabase.Text = VKN;
                txtDatabase.Enabled = false;
            }
            else
            {
                txtDatabase.Enabled = true;
            }
            SQLComboBox.Text = "Entegref Server";
            SQLComboBox.Enabled = false;

            if (sonuc.ToString() != id)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Entegref");
                key.SetValue("ApplicationSetupComplate", "true");
                key.SetValue("ApplicationGUID", id);
                key.SetValue("MachineUNIQUEID", pcname);
                key.Close();
            }

            string _s4 = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); // versiyon
            string _s5 = System.Reflection.Assembly.GetExecutingAssembly().GetName().CultureInfo.ToString(); // kültür bilgisi
            string _s6 = System.Reflection.Assembly.GetEntryAssembly().GetName().Name.ToString(); // proje adı
            string _s7 = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company; // şirket
            string _s8 = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute), false)).Copyright; // Copyright
            ManagementObjectSearcher query = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (var item in queryCollection)
            {
                pcModeli = item["model"].ToString();
                pcİsmi = item["name"].ToString();
            }
            ipAdresi = GetLocalIPAddress();
            GetMachineNameFromIPAddress(ipAdresi);
            //var webClient = new WebClient();

            ////dnsString = webClient.DownloadString("http://checkip.dyndns.org");
            ////dnsString = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(dnsString).Value;

            //webClient.Dispose();
            bunifupassword.ForeColor = SystemColors.GrayText;
            bunifupassword.Text = "Parola";
            this.bunifupassword.Leave += new System.EventHandler(this.ultraTextEditor1_Leave);
            this.bunifupassword.Enter += new System.EventHandler(this.ultraTextEditor1_Enter);
        }
        private static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);

                machineName = hostEntry.HostName;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            return machineName;
        }
        DataTable database;
        void Datasource()
        {
            //RegistryKey reg = (Registry.CurrentUser).OpenSubKey("Software");
            //reg = reg.OpenSubKey("ODBC");
            //reg = reg.OpenSubKey("ODBC.INI");
            //reg = reg.OpenSubKey("ODBC Data Sources");

            //RegistryKey key2 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources");
            //if (reg != null)
            //{

            //    foreach (string name in reg.GetValueNames())
            //    {

            //        string registrykey = reg.GetValue(name, "").ToString();
            //        if (registrykey == "SQL Server")
            //        {
            //            SQLComboBox.Items.Add(name);
            //        }

            //    }
            //}
            if (database != null)
            {
                if (database.Rows.Count > 0)
                {

                }
            }
            else
            {
                database = SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach (DataRow serverRow in database.Rows)
                {
                    if (serverRow[database.Columns["InstanceName"]].ToString() == "")
                    {
                        SQLComboBox.Items.Add(serverRow[database.Columns["ServerName"]].ToString());
                    }
                    else
                    {
                        SQLComboBox.Items.Add(serverRow[database.Columns["ServerName"]].ToString() + "\\" +
                                            (serverRow[database.Columns["InstanceName"]].ToString()));
                    }
                }
            }
            
        }
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
            button1.Visible = false;
            button2.Visible = true;
            txtGUID.Text = id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
            button1.Visible = true;
            button2.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save_data();


            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@user", bunifuUserName.Text);
            param.Add("@Parola", bunifupassword.Text);
            var dt = conn.DfQuery("Login", param);
            loginok = true;
            if (dt.Rows.Count == 0)
            {
                XtraMessageBox.Show("Kullanıcı bilgilerini kontrol edip tekar deneyiniz.");
                return;
            }
            else
            {

                //if (loginok == true)
                //{
                //    this.Hide();
                //}
                this.Hide();
                frmMain form = new frmMain();
                form.ShowDialog();
            }

        }

        private string GetIPAddres()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            sb.Append("The Local Machine Host Name: " + strHostName);
            sb.AppendLine();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] address = ipHostEntry.AddressList;
            sb.Append("The Local IP Address: " + address[2].ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void Init_Data()
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    bunifuUserName.Text = Properties.Settings.Default.username;
                    bunifuCheckbox1.Checked = true;
                }
                else
                {
                    bunifuUserName.Text = Properties.Settings.Default.username;
                }
            }
        }
        private void Save_data()
        {
            if (bunifuCheckbox1.Checked)
            {
                Properties.Settings.Default.username = bunifuUserName.Text.Trim();
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }

        }
        private void ultraTextEditor1_Leave(object sender, EventArgs e)
        {
            if (bunifupassword.Text.Length == 0)
            {
                bunifupassword.Text = "Parola";
                bunifupassword.ForeColor = SystemColors.GrayText;
            }
        }
        private void ultraTextEditor1_Enter(object sender, EventArgs e)
        {
            if (bunifupassword.Text == "Parola")
            {
                bunifupassword.Text = "";
                bunifupassword.ForeColor = SystemColors.WindowText;
            }
        }

        private void SQLComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        bool dbchange = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (dbchange == false)
            {
                SQLComboBox.Enabled = true;
                dbchange = true;
                SQLComboBox.Text = "Seciniz.......!";
                Datasource();
                button3.Text = "Entegreg'e Ayarla";
            }
            else
            {
                SQLComboBox.Text = "Entegref Server";
                SQLComboBox.Enabled = false;
                dbchange = false;
                button3.Text = "Database Değiştir";

            }
        }
    }
}
