using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Entegref
{

    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        decimal lMerkezBankasiAlisKuru;
        decimal lMerkezBankasiSatisKuru;
        decimal lAlis;
        decimal lSatis;
        string  DovizCinsi;

        private void frmMain_Load(object sender, EventArgs e)
        {
            //timer1.Start();
           if (frmLogin.loginok != true)
            {
                frmLogin frmLogin = new frmLogin(Properties.Settings.Default.VKN);
                frmLogin.ShowDialog();
                this.Close();
                this.Dispose();
            }
        }
        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            switch (e.Item.Key.ToString())
            {
                case "11":
                    OpenForm(new frmStokAc());
                    break;

                case "12":
                    //pnlfiyat.Dock = DockStyle.Fill;
                    //frmFiyat fyt = new frmFiyat();
                    //fyt.TopLevel = true;

                    //pnlfiyat.Controls.Add(fyt);
                    //fyt.Show();
                    OpenForm(new frmFiyat());
                    break;

                case "21":
                    OpenForm(new frmMusteri());
                    break;

                case "31":
                    OpenForm(new frmFirma());
                    break;

                case "81":
                    OpenForm(new frmReportView());
                    break;

                case "82":
                    Report frmreport = new Report();
                    frmreport.ShowDialog();
                    //OpenForm(new Report());
                    break;

                case "92":
                    OpenForm(new frmDepoAyarları());
                    break;
            }
        }
        public void OpenForm(Form toOpen)
        {
            int var = 0;
            foreach (Form child in MdiChildren)
            {
                if (child.Name == toOpen.Name)
                {
                    //child.Close();
                    var = 1;
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.Caption = "Uyarı";
                    args.Text = toOpen.Text.ToString() + "Açık.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    XtraMessageBox.Show(args).ToString();
                    toOpen.Close();
                    toOpen.Dispose();
                    toOpen.Focus();
                }
            }
            if (var == 0)
            {
                toOpen.MdiParent = this;
                toOpen.Show();
            }
        }

        int show = 0;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (show == 0)
            {
                Point MousePosition = this.Location;
                MousePosition.Offset(this.Width / 2, this.Height / 2);
                radialMenu1.ShowPopup(MousePosition);
            }
            else
            {
                radialMenu1.HidePopup();
                show = 1;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (show == 0)
            {
                Point MousePosition = this.Location;
                MousePosition.Offset(this.Width / 2, this.Height / 2);
                radialMenu1.ShowPopup(MousePosition);
            }
            else
            {
                radialMenu1.HidePopup();
                show = 1;
            }
        }
        public void Kurlar(string doviz)
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                lMerkezBankasiSatisKuru = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", doviz)).InnerText);
                lMerkezBankasiAlisKuru = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", doviz)).InnerText);
                lSatis = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", doviz)).InnerText);
                lAlis = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", doviz)).InnerText);
                return;
            }
            catch (XmlException xml)
            {
                MessageBox.Show(xml.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string Kurzamanı;
            Kurzamanı = DateTime.Now.ToShortTimeString();
            if (Kurzamanı == "17:30")
            {
                string q = "select sDovizCinsi,lMerkezBankasiAlisKuru,lMerkezBankasiSatisKuru,lAlisKuru,lSatisKuru from tbDovizKuru ";
                SqlCommand cmd = new SqlCommand(q, sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lMerkezBankasiAlisKuru=0;
                    lMerkezBankasiSatisKuru=0;
                    lAlis=0;
                    lSatis=0;
                    DovizCinsi = dt.Rows[i]["sDovizCinsi"].ToString();
                    Kurlar(DovizCinsi);

                    //Dictionary<string, string> Kurupdate = new Dictionary<string, string>();
                    //Kurupdate.Add("@DovizCinsi", DovizCinsi);
                    //Kurupdate.Add("@lMerkezBankasiAlisKuru", lMerkezBankasiAlisKuru.ToString());
                    //Kurupdate.Add("@lMerkezBankasiSatisKuru", lMerkezBankasiSatisKuru.ToString());
                    //Kurupdate.Add("@lAlis", lAlis.ToString());
                    //Kurupdate.Add("@lSatis", lSatis.ToString());
                    //conn.DfInsert("DovizUpdateMerkez", Kurupdate);
                }
            }
            else
            {
                timer1.Stop();
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new frmDoviz()); 
        }

        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (show == 0)
            {
                Point MousePosition = this.Location;
                MousePosition.Offset(this.Width / 2, this.Height / 2);
                radialMenu1.ShowPopup(MousePosition);
            }
            else
            {
                radialMenu1.HidePopup();
                show = 1;
            }
        }
    }
}
