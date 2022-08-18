using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using DevExpress.XtraEditors;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static Entegref.frmKargo;
using System.Net.Http;

namespace Entegref
{
    public partial class frmStokAc : XtraForm
    {
        public class Brand
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class Marka
        {
            public List<Brand> brands { get; set; }
        }
        public class Attribute
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class AttributeValue
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class CategoryAttribute
        {
            public bool allowCustom { get; set; }
            public Attribute attribute { get; set; }
            public List<AttributeValue> attributeValues { get; set; }
            public int categoryId { get; set; }
            public bool required { get; set; }
            public bool varianter { get; set; }
            public bool slicer { get; set; }
        }
        public class Root
        {
            public int id { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public List<CategoryAttribute> categoryAttributes { get; set; }
        }
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);


        string nStokID;

        DataTable kdv = new DataTable();
        DataTable birim1 = new DataTable();
        DataTable birim2 = new DataTable();
        DataTable Otv = new DataTable();
        DataTable Barkod = new DataTable();
        DataTable Urun = new DataTable();
        DataTable Fiyat = new DataTable();

        DataTable sinif1 = new DataTable();
        DataTable sinif2 = new DataTable();
        DataTable sinif3 = new DataTable();
        DataTable sinif4 = new DataTable();
        DataTable sinif5 = new DataTable();
        DataTable sinif6 = new DataTable();



        public static string sRenkKodu = "";
        public static string sModel = "";
        public static string sFiyatTipi = "";

        public static string sinifsira1;
        public static string sinifsira2;
        public static string sinifsira3;
        public static string sinifsira4;
        public static string sinifsira5;
        public static string sinifsira6;


        public static string Fiyatlandirma;
        public static string nFiyatlandirma;
        public static string nStokTipi;
        public static string Beden;
        public static string Kavala;
        public static string BedenTipi;
        public static string KavalaTipi;
        public static bool Renk = false;
        public frmStokAc()
        {
            InitializeComponent();
        }

        private void frmStokAc_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            cmbBirim1.DisplayMember = "sAciklama";
            cmbBirim1.ValueMember = "sBirimCinsi";
            cmbBirim2.DisplayMember = "sAciklama";
            cmbBirim2.ValueMember = "sBirimCinsi";
            cmbKDV.DisplayMember = "nKdvOrani";
            cmbKDV.ValueMember = "sKdvTipi";
            cmbOTV.DisplayMember = "sOTVTipi";
            cmbOTV.ValueMember = "nOTVOrani";

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string query1 = "select * from tbBirimCinsi";
            string query2 = "select sKdvTipi,sKdvTipi + convert(char(5),nKdvOrani) as nKdvOrani from tbKdv where sKdvTipi != ''";
            string query3 = "select sOTVTipi,sOTVTipi+' ' + convert(char(6),nOTVOrani) as nOTVOrani from tbOTV  where sOTVTipi != ''";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            SqlCommand cmd3 = new SqlCommand(query3, connection);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            SqlDataAdapter adp3 = new SqlDataAdapter(cmd3);
            adp1.Fill(birim1);
            adp1.Fill(birim2);
            adp2.Fill(kdv);
            adp3.Fill(Otv);
            connection.Close();
            adp1.Dispose();
            adp2.Dispose();
            cmbBirim1.DataSource = birim1;
            cmbBirim2.DataSource = birim2;
            cmbKDV.DataSource = kdv;

            if (nStokID == null)
            {
                //ultraTabControl1.VisibleTabs[1].Visible = false;
                //ultraTabControl1.VisibleTabs[2].Visible = false;
                //ultraTabControl1.VisibleTabs[3].Visible = false;
                ultraTabControl1.VisibleTabs[4].Visible = false;
                //ultraTabControl1.VisibleTabs[5].Visible = false;
                ultraTabControl1.VisibleTabs[6].Visible = false;
            }
        }
        public void sinif_1()
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "1");
            Prm.Add("@parentid", "");
            sinif1 = conn.DfQuery("Sinif", Prm);
        }
        public void sinif_2()
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "2");
            Prm.Add("@parentid", "");
            sinif2 = conn.DfQuery("Sinif", Prm);
        }
        public void sinif_3()
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "3");
            Prm.Add("@parentid", "");
            sinif3 = conn.DfQuery("Sinif", Prm);
        }
        public void sinif_4()
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "4");
            Prm.Add("@parentid", "");
            sinif4 = conn.DfQuery("Sinif", Prm);
        }
        public void sinif_5()
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "5");
            Prm.Add("@parentid", "");
            sinif5 = conn.DfQuery("Sinif", Prm);
        }
        public void sinif_6()
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "6");
            Prm.Add("@parentid", "");
            sinif6 = conn.DfQuery("Sinif", Prm);
        }
        DataTable renkolanlar = new DataTable();
        //Stok Aç
        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (txtStokKodu != null && txtStokKodu.Text != "")
            {
                Markalar();
                btnbarkod();
                panel2.Enabled = true;
                Dictionary<string, string> Stk = new Dictionary<string, string>();
                Stk.Add("@smodel",txtStokKodu.Text);
                Urun = conn.DfQuery("Entegref_Stok_Sec", Stk);
                connection.Close();
                renkolanlar.Clear();
                renkolanlar.Columns.Clear();
                renkolanlar.Columns.Add("sBedenTipi");
                renkolanlar.Columns.Add("sKavalaTipi");
                renkolanlar.Columns.Add("sRenk");
                renkolanlar.Columns.Add("sBeden");
                renkolanlar.Columns.Add("sKavala");
                renkolanlar.Columns.Add("sRenkAdi");
                DataRow _ravi = renkolanlar.NewRow();
                nStokID = null;
                if (Urun.Rows.Count > 1)
                {
                    for (int i = 0; i < Urun.Rows.Count; i++)
                    {
                        if (nStokID != null)
                        {
                            nStokID = nStokID + "-" + Urun.Rows[i]["nStokID"].ToString();
                        }
                        else
                        {
                            nStokID = Urun.Rows[i]["nStokID"].ToString();
                        }
                        renkolanlar.Rows.Add(new object[] { Urun.Rows[i]["sBedenTipi"].ToString(), Urun.Rows[i]["sKavalaTipi"].ToString(), Urun.Rows[i]["sRenk"].ToString(), Urun.Rows[i]["sBeden"].ToString(), Urun.Rows[i]["sKavala"].ToString(), Urun.Rows[i]["sRenkAdi"].ToString() });
                    }

                    KavalaTipi = Urun.Rows[0]["sKavalaTipi"].ToString();
                    BedenTipi = Urun.Rows[0]["sBedenTipi"].ToString();
                    bunifuCustomTextbox1.Text = Urun.Rows[0]["sAciklama"].ToString();
                    cmbBirim1.Text = Urun.Rows[0]["sBirimCinsi1"].ToString();
                    cmbBirim2.Text = Urun.Rows[0]["sBirimCinsi2"].ToString();
                    cmbKDV.Text = Urun.Rows[0]["sKdvTipi"].ToString();
                    bunifuCustomTextbox1.Text = Urun.Rows[0]["sAciklama"].ToString();
                    sinifsira1 = Urun.Rows[0]["sSinifKodu20"].ToString().Replace(" ","");
                    sinifsira2 = Urun.Rows[0]["sSinifKodu21"].ToString().Replace(" ","");
                    sinifsira3 = Urun.Rows[0]["sSinifKodu22"].ToString().Replace(" ","");
                    sinifsira4 = Urun.Rows[0]["sSinifKodu23"].ToString().Replace(" ","");
                    sinifsira5 = Urun.Rows[0]["sSinifKodu24"].ToString().Replace(" ","");
                    sinifsira6 = Urun.Rows[0]["sSinifKodu25"].ToString().Replace(" ","");
                    if (sinifsira1 != null)
                    {
                        if (cmbSinif1.SelectedValue == null)
                        {
                            cmbSinif1.DisplayMember = "sAciklama";
                            cmbSinif1.ValueMember = "sSinifKodu";
                            Dictionary<string, string> Prm = new Dictionary<string, string>();
                            Prm.Add("@sira", "1");
                            Prm.Add("@parentid", "0");
                            sinif1 = conn.DfQuery("Sinif", Prm);
                            cmbSinif1.DataSource = sinif1;
                            cmbSinif1.SelectedValue = sinifsira1;
                        }
                    }
                }
                else if (Urun.Rows.Count == 1)
                {
                    nStokID = Urun.Rows[0]["nStokID"].ToString();
                }
                else
                {
                    int sira = 0;
                    for (int i = 0; i < sRenkKodu.Length/3; i++)
                    {
                        if (i!=0)
                        {
                            sira += 4;
                        }
                        renkolanlar.Rows.Add(new object[] { "","",sRenkKodu.Substring(sira, 3),"","" });
                    }
                    //renkolanlar.Clear();
                    //renkolanlar.Rows.Add(new object[] { sRenkKodu.Substring(0, 3), sRenkKodu.Substring(4, 3), sRenkKodu.Substring(8, 3) });
                }
                btnStokBul.Enabled = false;
                ultraButton1.Enabled = false;
                ultraButton2.Enabled = false;
                simpleButton3.Enabled = false;
                ultraTabControl1.VisibleTabs[1].Visible = true;
                ultraTabControl1.VisibleTabs[2].Visible = true;
                ultraTabControl1.VisibleTabs[3].Visible = true;
                ultraTabControl1.VisibleTabs[4].Visible = true;
                ultraTabControl1.VisibleTabs[5].Visible = true;

                if (nStokID != null && nStokID != "")
                {
                    ultraTabControl1.VisibleTabs[6].Visible = true;
                    //btnKaydet.Text = "Güncelle";
                }
                txtStokKodu.Enabled = false;

                if (sinifsira6 != null && sinifsira6 != "" && sinifsira6 != "00-0")
                {
                    UrunOzellikAc(sinifsira6.Substring(sinifsira6.ToString().IndexOf("-") + 1));
                }
                else if (sinifsira5 != null && sinifsira5 != "" && sinifsira5 != "00-0")
                {
                    UrunOzellikAc(sinifsira5.Substring(sinifsira5.ToString().IndexOf("-") + 1));
                }
                else if (sinifsira4 != null && sinifsira4 != "" && sinifsira4 != "00-0")
                {
                    UrunOzellikAc(sinifsira4.Substring(sinifsira4.ToString().IndexOf("-") + 1));
                }
                else if (sinifsira3 != null && sinifsira3 != "" && sinifsira3 != "00-0")
                {
                    UrunOzellikAc(sinifsira3.Substring(sinifsira3.ToString().IndexOf("-")+1));
                }
                else if (sinifsira2 != null && sinifsira2 != "" && sinifsira2 != "00-0")
                {
                    UrunOzellikAc(sinifsira2.Substring(sinifsira2.ToString().IndexOf("-") + 1));
                }
            }

        }
        //Tab control Tuş işlemleri
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab.Text == "Resimler")
            {
                Resimler();
            }
            else if (e.Tab.Text == "Fiyatlandırma")
            {
                if (nStokID != null)
                {
                    FiyatCek(txtStokKodu.Text, "");
                }
            }
            else if (e.Tab.Text == "Sınıflar")
            {
                if (cmbSinif1.SelectedValue == null)
                {
                    cmbSinif1.DisplayMember = "sAciklama";
                    cmbSinif1.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "1");
                    Prm.Add("@parentid", "0");
                    sinif1 = conn.DfQuery("Sinif", Prm);
                    cmbSinif1.DataSource = sinif1;
                }
            }
            else if (e.Tab.Text == "Renk Beden Kavala")
            {
                if (nStokID != null)
                {
                    dataGridView1.DataSource = null;
                    pnlRenkBedenOlan.Dock = DockStyle.Fill;
                    pnlRenkBeden.Visible = false;
                    string renk = "";
                    for (int i = 0; i < renkolanlar.Rows.Count; i++)
                    {
                        if (renk == "")
                        {
                            renk = renkolanlar.Rows[i][2].ToString();
                        }
                        else if (renk != renkolanlar.Rows[i][2].ToString())
                        {
                            renk = renk.ToString() + "," + renkolanlar.Rows[i][2].ToString();
                        }
                    }
                    Dictionary<string, string> MM = new Dictionary<string, string>();
                    MM.Add("@smodel", txtStokKodu.Text.Substring(0, 12));
                    if (string.IsNullOrEmpty(KavalaTipi) == true)
                    {
                        MM.Add("@sKavalaTipi", "");
                    }
                    else
                    {
                        MM.Add("@sKavalaTipi", KavalaTipi.ToString());
                    }
                    if (string.IsNullOrEmpty(KavalaTipi) == true)
                    {
                        MM.Add("@sBedenTipi", "");
                    }
                    else
                    {
                        MM.Add("@sBedenTipi", BedenTipi);
                    }
                    MM.Add("@sRenkKodu", renk);
                    var dt = conn.DfQuery("Entegref_Urun_Renk_Beden_Kavala_Sec", MM);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();

                }
                else
                {
                    //dataGridView1.DataSource = null;
                    //dataGridView1.Visible = false;
                    //pnlRenkBedenOlan.Visible = false;
                    //pnlRenkBeden.Controls.Clear();
                    //pnlRenkBeden.Dock = DockStyle.Fill;
                    //frmRenk frmRenk = new frmRenk(Kavala, BedenTipi);
                    //frmRenk.TopLevel = false;
                    //pnlRenkBeden.Controls.Add(frmRenk);
                    //frmRenk.Show();
                }
            }
            else if (e.Tab.Text == "Barkod")
            {
                btnbarkod();
            }
            else
            {

            }
        }
        private void btnbarkod()
        {
            string query = "select sBarkod,(select sKodu from tbfirma f where f.nFirmaID = b.nFirmaID) as sFirmaKodu,sKarsiStokKodu,sKarsiStokAciklama from [39391097764].dbo.tbStokBarkodu b ";
            query = query + " inner join [39391097764].dbo.tbStok s on s.nStokID = b.nStokID";
            query = query + " where s.sKodu = '" + txtStokKodu.Text.ToString() + "'";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connection);
            connection.Open();
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            ad.Fill(Barkod);
            connection.Close();
            gridBarkod.DataSource = Barkod;
        }
        private void viewTrendyol_marka_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                cmbMarka.SelectedValue = viewTrendyol_marka.GetRowCellValue(viewTrendyol_marka.FocusedRowHandle, "id");
                txtMarkaAra.Text = viewTrendyol_marka.GetRowCellValue(viewTrendyol_marka.FocusedRowHandle, "name").ToString();
            }
        }
        //Trendyol Yeni Stok Aç
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            sinifsira1 = null;
            sinifsira2 = null;
            sinifsira3 = null;
            sinifsira4 = null;
            sinifsira5 = null;
            sinifsira6 = null;
            Renk = false;
            frmStokSinifi sinifi = new frmStokSinifi();
            sinifi.TopLevel = true;
            sinifi.ShowDialog();
            NewStok();
        }
        public void NewStok()
        { 
            sinif1.Clear();
            sinif2.Clear();
            sinif3.Clear();
            sinif4.Clear();
            sinif5.Clear();
            sinif6.Clear();

            if (sinifsira1 != null)
            {
                if (cmbSinif1.SelectedValue == null)
                {
                    cmbSinif1.DisplayMember = "sAciklama";
                    cmbSinif1.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "1");
                    Prm.Add("@parentid", "0");
                    sinif1 = conn.DfQuery("Sinif", Prm);
                    cmbSinif1.DataSource = sinif1;
                    cmbSinif1.SelectedValue = sinifsira1;
                }
            }
            if (cmbSinif1.SelectedValue != null)
            {
                cmbSinif2.DisplayMember = "sAciklama";
                cmbSinif2.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "2");
                Prm.Add("@parentid", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-")+1,4));
                sinif2 = conn.DfQuery("Sinif", Prm);
                cmbSinif2.DataSource = sinif2;
                cmbSinif2.SelectedValue = sinifsira2;
            }

            if (sinifsira3 != null && sinifsira3 != "00-0")
            {
                if (cmbSinif2.SelectedValue != null)
                {
                    cmbSinif3.DisplayMember = "sAciklama";
                    cmbSinif3.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "3");
                    Prm.Add("@parentid", cmbSinif2.SelectedValue.ToString().Substring(cmbSinif2.SelectedValue.ToString().IndexOf("-") + 1, 4));
                    sinif3 = conn.DfQuery("Sinif", Prm);
                    cmbSinif3.DataSource = sinif3;
                    cmbSinif3.SelectedValue = sinifsira3.Replace("00-0", null);
                }

            }
            if (sinifsira4 != null && sinifsira4 != "00-0")
            {
                if (cmbSinif3.SelectedValue != null)
                {
                    cmbSinif4.DisplayMember = "sAciklama";
                    cmbSinif4.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "4");
                    Prm.Add("@parentid", cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1, 4));
                    sinif4 = conn.DfQuery("Sinif", Prm);
                    cmbSinif4.DataSource = sinif4;
                    cmbSinif4.SelectedValue = sinifsira4.Replace("00-0", null);
                }
            }
            if (sinifsira5 != null && sinifsira5 != "00-0")
            {
                if (cmbSinif4.SelectedValue != null)
                {
                    cmbSinif5.DisplayMember = "sAciklama";
                    cmbSinif5.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "4");
                    Prm.Add("@parentid", cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1, 4));
                    sinif5 = conn.DfQuery("Sinif", Prm);
                    cmbSinif5.DataSource = sinif5;
                    cmbSinif5.SelectedValue = sinifsira5.Replace("00-0", null);
                }
            }
            if (sinifsira6 != null && sinifsira6 != "00-0")
            {
                cmbSinif6.SelectedValue = sinifsira6.Replace("00-0", null);
            }
            if (nFiyatlandirma != null )
            {
                lblFiyattipi.Visible = true;
                lblFiyattipi.Text = Fiyatlandirma;
            }
            if (BedenTipi != null && BedenTipi != "")
            {
                lblBeden.Text = Beden;
                lblBeden.Visible = true;
            }
            if (KavalaTipi != null && KavalaTipi != "")
            {
                lblKavala.Text = Kavala;
                lblKavala.Visible = true;
            }
            txtStokKodu.Text = sModel;
            if (Renk == true)
            {
            }
            if (sinifsira6 != null && sinifsira6 != "00-0")
            {
                UrunOzellikAc(sinifsira6.Substring(sinifsira6.ToString().IndexOf("-") + 1));
            }
            else if (sinifsira5 != null && sinifsira5 != "00-0")
            {
                UrunOzellikAc(sinifsira5.Substring(sinifsira5.ToString().IndexOf("-") + 1));
            }
            else if (sinifsira4 != null && sinifsira4 != "00-0")
            {
                UrunOzellikAc(sinifsira4.Substring(sinifsira4.ToString().IndexOf("-") + 1));
            }
            else if (sinifsira3 != null && sinifsira3 != "00-0")
            {
                UrunOzellikAc(sinifsira3.Substring(sinifsira3.ToString().IndexOf("-")+1));
            }
            else if (sinifsira2 != null && sinifsira2 != "00-0")
            {
                UrunOzellikAc(sinifsira2.Substring(sinifsira2.ToString().IndexOf("-") + 1));
            }
        }
        //Trendyol Ürün Özellikleri
        DataTable markalar = new DataTable();
        public void Markalar()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.trendyol.com/sapigw/brands");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            var MRK = new List<Brand>();
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Marka myDeserializedClass = JsonConvert.DeserializeObject<Marka>(result);
                foreach (var item in myDeserializedClass.brands)
                {
                    var dt = new Brand();
                    dt.id = item.id;
                    dt.name = item.name;
                    MRK.Add(dt);
                }
                //ListtoDataTableConverter converter = new ListtoDataTableConverter();
                //markalar = converter.ToDataTable(MRK);
                gridTrendyol_marka.DataSource = MRK;
                cmbMarka.DisplayMember = "name";
                cmbMarka.ValueMember = "id";
                cmbMarka.DataSource = MRK;
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            var url = "https://api.trendyol.com/sapigw/brands/by-name?name=" + txtMarkaAra.Text;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<User>>(result);
                gridTrendyol_marka.DataSource = null;
                gridTrendyol_marka.DataSource = items;
                cmbMarka.DataSource = null;
                cmbMarka.DisplayMember = "name";
                cmbMarka.ValueMember = "id";
                cmbMarka.DataSource = items;
            }
        }
        DataTable attribute = new DataTable();
        public void UrunOzellikAc(string CatagoryID)
        {
            string url = "https://api.trendyol.com/sapigw/product-categories/" + CatagoryID.Substring(CatagoryID.IndexOf("-") + 1).Replace(" ", "") + "/attributes";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                var CategoryAttributes = new List<CategoryAttribute>();
                var AttributeValues = new List<AttributeValue>();
                var CategoryAttribute = new CategoryAttribute();
                foreach (var item in myDeserializedClass.categoryAttributes)
                {
                    if (item.allowCustom == false)
                    {
                        if (lblOzellik1.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik1.Tag = item.attribute.id;
                                lblOzellik1.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk2.Checked = true;
                            }
                            else
                            {
                                lblOzellik1.Tag = item.attribute.id;
                                lblOzellik1.Text = item.attribute.name;
                                chk2.Checked = false;
                            }
                            cmbOzellik1.DisplayMember = "name";
                            cmbOzellik1.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik1.DataSource = persons;
                        }
                        else
                        if (lblOzellik2.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik2.Tag = item.attribute.id;
                                lblOzellik2.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk3.Checked = true;
                            }
                            else
                            {
                                lblOzellik2.Tag = item.attribute.id;
                                lblOzellik2.Text = item.attribute.name;
                                chk3.Checked = false;
                            }
                            cmbOzellik2.DisplayMember = "name";
                            cmbOzellik2.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik2.DataSource = persons;
                        }
                        else
                        if (lblOzellik3.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik3.Tag = item.attribute.id;
                                lblOzellik3.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk4.Checked = true;
                            }
                            else
                            {
                                lblOzellik3.Tag = item.attribute.id;
                                lblOzellik3.Text = item.attribute.name;
                                chk4.Checked = false;
                            }
                            cmbOzellik3.DisplayMember = "name";
                            cmbOzellik3.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik3.DataSource = persons;
                        }
                        else
                        if (lblOzellik4.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik4.Tag = item.attribute.id;
                                lblOzellik4.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk5.Checked = true;
                            }
                            else
                            {
                                lblOzellik4.Tag = item.attribute.id;
                                lblOzellik4.Text = item.attribute.name;
                                chk5.Checked = false;
                            }
                            cmbOzellik4.DisplayMember = "name";
                            cmbOzellik4.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik4.DataSource = persons;
                        }
                        else
                        if (lblOzellik5.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik5.Tag = item.attribute.id;
                                lblOzellik5.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk6.Checked = true;
                            }
                            else
                            {
                                lblOzellik5.Tag = item.attribute.id;
                                lblOzellik5.Text = item.attribute.name;
                                chk6.Checked = false;
                            }
                            cmbOzellik5.DisplayMember = "name";
                            cmbOzellik5.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik5.DataSource = persons;
                        }
                        else
                        if (lblOzellik6.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik6.Tag = item.attribute.id;
                                lblOzellik6.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk7.Checked = true;
                            }
                            else
                            {
                                lblOzellik6.Tag = item.attribute.id;
                                lblOzellik6.Text = item.attribute.name;
                                chk7.Checked = false;
                            }
                            cmbOzellik6.DisplayMember = "name";
                            cmbOzellik6.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik6.DataSource = persons;
                        }
                        else
                        if (lblOzellik7.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik7.Tag = item.attribute.id;
                                lblOzellik7.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk8.Checked = true;
                            }
                            else
                            {
                                lblOzellik7.Tag = item.attribute.id;
                                lblOzellik7.Text = item.attribute.name;
                                chk8.Checked = false;
                            }
                            cmbOzellik7.DisplayMember = "name";
                            cmbOzellik7.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik7.DataSource = persons;
                        }
                        else
                        if (lblOzellik8.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik8.Tag = item.attribute.id;
                                lblOzellik8.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk9.Checked = true;
                            }
                            else
                            {
                                lblOzellik8.Tag = item.attribute.id;
                                lblOzellik8.Text = item.attribute.name;
                                chk9.Checked = false;
                            }
                            cmbOzellik8.DisplayMember = "name";
                            cmbOzellik8.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik8.DataSource = persons;
                        }
                        else
                        if (lblOzellik9.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik9.Tag = item.attribute.id;
                                lblOzellik9.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk10.Checked = true;
                            }
                            else
                            {
                                lblOzellik9.Tag = item.attribute.id;
                                lblOzellik9.Text = item.attribute.name;
                                chk10.Checked = false;
                            }
                            cmbOzellik9.DisplayMember = "name";
                            cmbOzellik9.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik9.DataSource = persons;
                        }
                        else
                        if (lblOzellik10.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik10.Tag = item.attribute.id;
                                lblOzellik10.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk11.Checked = true;
                            }
                            else
                            {
                                lblOzellik10.Tag = item.attribute.id;
                                lblOzellik10.Text = item.attribute.name;
                                chk11.Checked = false;
                            }
                            cmbOzellik10.DisplayMember = "name";
                            cmbOzellik10.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik10.DataSource = persons;
                        }
                        else
                        if (lblOzellik11.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik11.Tag = item.attribute.id;
                                lblOzellik11.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk12.Checked = true;
                            }
                            else
                            {
                                lblOzellik11.Tag = item.attribute.id;
                                lblOzellik11.Text = item.attribute.name;
                                chk12.Checked = false;
                            }
                            cmbOzellik11.DisplayMember = "name";
                            cmbOzellik11.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik11.DataSource = persons;
                        }
                        else
                        if (lblOzellik12.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik12.Tag = item.attribute.id;
                                lblOzellik12.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk13.Checked = true;
                            }
                            else
                            {
                                lblOzellik12.Tag = item.attribute.id;
                                lblOzellik12.Text = item.attribute.name;
                                chk13.Checked = false;
                            }
                            cmbOzellik12.DisplayMember = "name";
                            cmbOzellik12.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik12.DataSource = persons;
                        }
                        else
                        if (lblOzellik13.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik13.Tag = item.attribute.id;
                                lblOzellik13.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk14.Checked = true;
                            }
                            else
                            {
                                lblOzellik13.Tag = item.attribute.id;
                                lblOzellik13.Text = item.attribute.name;
                                chk14.Checked = false;
                            }
                            cmbOzellik13.DisplayMember = "name";
                            cmbOzellik13.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik13.DataSource = persons;
                        }
                        else
                        if (lblOzellik14.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik14.Tag = item.attribute.id;
                                lblOzellik14.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk15.Checked = true;
                            }
                            else
                            {
                                lblOzellik14.Tag = item.attribute.id;
                                lblOzellik14.Text = item.attribute.name;
                                chk15.Checked = false;
                            }
                            cmbOzellik14.DisplayMember = "name";
                            cmbOzellik14.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik14.DataSource = persons;
                        }
                        else
                        if (lblOzellik15.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik15.Tag = item.attribute.id;
                                lblOzellik15.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk16.Checked = true;
                            }
                            else
                            {
                                lblOzellik15.Tag = item.attribute.id;
                                lblOzellik15.Text = item.attribute.name;
                                chk16.Checked = false;
                            }
                            cmbOzellik15.DisplayMember = "name";
                            cmbOzellik15.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik15.DataSource = persons;
                        }
                        else
                        if (lblOzellik16.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik16.Tag = item.attribute.id;
                                lblOzellik16.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk17.Checked = true;
                            }
                            else
                            {
                                lblOzellik16.Tag = item.attribute.id;
                                lblOzellik16.Text = item.attribute.name;
                                chk17.Checked = false;
                            }
                            cmbOzellik16.DisplayMember = "name";
                            cmbOzellik16.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik16.DataSource = persons;
                        }
                        else
                        if (lblOzellik17.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik17.Tag = item.attribute.id;
                                lblOzellik17.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk18.Checked = true;
                            }
                            else
                            {
                                lblOzellik17.Tag = item.attribute.id;
                                lblOzellik17.Text = item.attribute.name;
                                chk18.Checked = false;
                            }
                            cmbOzellik17.DisplayMember = "name";
                            cmbOzellik17.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik17.DataSource = persons;
                        }
                        else
                        if (lblOzellik18.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik18.Tag = item.attribute.id;
                                lblOzellik18.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk19.Checked = true;
                            }
                            else
                            {
                                lblOzellik18.Tag = item.attribute.id;
                                lblOzellik18.Text = item.attribute.name;
                                chk19.Checked = false;
                            }
                            cmbOzellik18.DisplayMember = "name";
                            cmbOzellik18.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik18.DataSource = persons;
                        }
                        else
                        if (lblOzellik19.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik19.Tag = item.attribute.id;
                                lblOzellik19.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk20.Checked = true;
                            }
                            else
                            {
                                lblOzellik19.Tag = item.attribute.id;
                                lblOzellik19.Text = item.attribute.name;
                                chk20.Checked = false;
                            }
                            cmbOzellik19.DisplayMember = "name";
                            cmbOzellik19.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik19.DataSource = persons;
                        }
                        else
                        if (lblOzellik20.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik20.Tag = item.attribute.id;
                                lblOzellik20.Text = item.attribute.name + " ZORUNLU ALAN";
                                chk20.Checked = true;
                            }
                            else
                            {
                                lblOzellik20.Tag = item.attribute.id;
                                lblOzellik20.Text = item.attribute.name;
                                chk20.Checked = false;
                            }
                            cmbOzellik20.DisplayMember = "name";
                            cmbOzellik20.ValueMember = "id";
                            var persons = new List<Attribute>();
                            var dd = new Attribute();
                            dd.id = 0;
                            dd.name = "Seçiniz....!";
                            persons.Add(dd);
                            foreach (var attributeValues in item.attributeValues)
                            {
                                var d = new Attribute();
                                d.id = attributeValues.id;
                                d.name = attributeValues.name;
                                persons.Add(d);
                            }
                            cmbOzellik20.DataSource = persons;
                        }
                    }
                    else
                    {
                        if (item.required == true)
                        {
                            lblRenk.Text = item.attribute.name + " ZORUNLU ALAN";
                            lblRenk.Tag = item.attribute.id;
                            chk1.Checked = true;
                        }
                        else
                        {
                            lblRenk.Text = item.attribute.name;
                            lblRenk.Tag = item.attribute.id;
                            chk1.Checked = false;
                        }
                        for (int i = 0; i < renkolanlar.Rows.Count; i++)
                        {
                            if (txtRenk.Text == "")
                            {
                                txtRenk.Text = renkolanlar.Rows[i][5].ToString();
                            }
                            else
                            {
                                txtRenk.Text = txtRenk.Text + "," + renkolanlar.Rows[i][5].ToString();
                            }
                        }
                    }
                    var deger = myDeserializedClass.categoryAttributes.Count;
                    if (deger < 20)
                    {
                        lblOzellik20.Visible = false;
                        cmbOzellik20.Visible = false;
                        chk21.Visible = false;
                    }
                    if (deger < 19)
                    {
                        lblOzellik19.Visible = false;
                        cmbOzellik19.Visible = false;
                        chk20.Visible = false;
                    }
                    if (deger < 18)
                    {
                        lblOzellik18.Visible = false;
                        cmbOzellik18.Visible = false;
                        chk19.Visible = false;
                    }
                    if (deger < 17)
                    {
                        lblOzellik17.Visible = false;
                        cmbOzellik17.Visible = false;
                        chk18.Visible = false;
                    }
                    if (deger < 16)
                    {
                        lblOzellik16.Visible = false;
                        cmbOzellik16.Visible = false;
                        chk17.Visible = false;
                    }
                    if (deger < 15)
                    {
                        lblOzellik15.Visible = false;
                        cmbOzellik15.Visible = false;
                        chk16.Visible = false;
                    }
                    if (deger < 14)
                    {
                        lblOzellik14.Visible = false;
                        cmbOzellik14.Visible = false;
                        chk15.Visible = false;
                    }
                    if (deger < 13)
                    {
                        lblOzellik13.Visible = false;
                        cmbOzellik13.Visible = false;
                        chk14.Visible = false;
                    }
                    if (deger < 12)
                    {
                        lblOzellik12.Visible = false;
                        cmbOzellik12.Visible = false;
                        chk13.Visible = false;
                    }
                    if (deger < 11)
                    {
                        lblOzellik11.Visible = false;
                        cmbOzellik11.Visible = false;
                        chk12.Visible = false;
                    }
                    if (deger < 10)
                    {
                        lblOzellik10.Visible = false;
                        cmbOzellik10.Visible = false;
                        chk11.Visible = false;
                    }
                    if (deger < 9)
                    {
                        lblOzellik9.Visible = false;
                        cmbOzellik9.Visible = false;
                        chk10.Visible = false;
                    }
                    if (deger < 8)
                    {
                        lblOzellik8.Visible = false;
                        cmbOzellik8.Visible = false;
                        chk9.Visible = false;
                    }
                    if (deger < 7)
                    {
                        lblOzellik7.Visible = false;
                        cmbOzellik7.Visible = false;
                        chk8.Visible = false;
                    }
                    if (deger < 6)
                    {
                        lblOzellik6.Visible = false;
                        cmbOzellik6.Visible = false;
                        chk7.Visible = false;
                    }
                    if (deger < 5)
                    {
                        lblOzellik5.Visible = false;
                        cmbOzellik5.Visible = false;
                        chk6.Visible = false;
                    }
                    
                    
                }
            }
        }
        private void vewAttribute_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }
        public void UrunOzellikAc3(string CatagoryID)
        {
            string url = "https://api.trendyol.com/sapigw/product-categories/" + CatagoryID.Substring(CatagoryID.IndexOf("-")+1).Replace(" ","") + "/attributes";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                int sira = 0;
                int x1 = 10;
                int y1 = -20;
                int x2 = 200;
                int y2 = -20;
                string name1 = "lblbaslik";
                string name2 = "txt";
                string name3 = "cmb";
                if (attribute.Columns.Count <2)
                {
                    attribute.Columns.Add("Name");
                    attribute.Columns.Add("Tur");
                }
                foreach (var item in myDeserializedClass.categoryAttributes)
                {
                    sira += 1;

                    if (item.allowCustom == false)
                    {
                        y1 += 30;
                        Label lbl = new Label()
                        {
                            Location = new Point(x1, y1),
                            Name = name1 + sira.ToString(),
                            Text = item.attribute.name

                        };
                        y2 += 30;
                        System.Windows.Forms.ComboBox cmb1 = new System.Windows.Forms.ComboBox()
                        {
                            Location = new Point(x2, y2),
                            Size = new Size(300, 20),
                            Name = name3 + item.attribute.name + sira.ToString()

                        };
                        if (item.required == true)
                        {
                            lbl.Text = lbl.Text + "* Zorunlu Alan";
                        }
                        panel9.Controls.Add(lbl);
                        panel9.Controls.Add(cmb1);
                        cmb1.DisplayMember = "name";
                        cmb1.ValueMember = "id";

                        var persons = new List<Attribute>();
                        var dd = new Attribute();
                        dd.id = 0;
                        dd.name = "Seçiniz....!";
                        persons.Add(dd);
                        foreach (var attributeValues in item.attributeValues)
                        {
                            var d = new Attribute();
                            d.id = attributeValues.id;
                            d.name = attributeValues.name;
                            persons.Add(d);
                        }
                        cmb1.DataSource = persons;
                        if (item.required == true)
                        {
                            attribute.Rows.Add(new object[] { cmb1.Name, "ComboBox" });
                        }

                    }
                    else
                    {
                        y1 += 30;
                        Label label1 = new Label()
                        {
                            Location = new Point(x1, y1),
                            Name = name1 + sira.ToString(),
                            Text = item.attribute.name
                        };
                        y2 += 30;
                        TextBox Renk = new TextBox()
                        {
                            Location = new Point(x2, y2),
                            Size = new Size(300, 20),
                            Name = name2 + item.attribute.name + sira.ToString()
                        };
                        if (item.required == true)
                        {
                            label1.Text = label1.Text + "* Zorunlu Alan";
                        }
                        panel9.Controls.Add(label1);
                        panel9.Controls.Add(Renk);
                        for (int i = 0; i < renkolanlar.Rows.Count; i++)
                        {
                            if (Renk.Text == "")
                            {
                                Renk.Text = renkolanlar.Rows[i][5].ToString();
                            }
                            else
                            {
                                Renk.Text = Renk.Text + "," + renkolanlar.Rows[i][5].ToString();
                            }
                        }

                        if (item.required == true)
                        {
                            attribute.Rows.Add(new object[] { Renk.Name, "TextBox" });
                        }
                    }
                }
            }
        }
        private void ultraButton2_Click(object sender, EventArgs e)
        {

        }

        //Resim Seç
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

            dlg.DefaultExt = ".png";
            dlg.ShowDialog();
            txtFileAdress.Text = dlg.FileName;
            filename = dlg.SafeFileName.ToString();
        }
        public void Resimler()
        {
            listBox1.DataSource = null;
            listBox1.DisplayMember = "Resim Adı";
            listBox1.ValueMember = "Resim Yolu";

            DataTable resim = new DataTable();
            resim.Clear();
            resim.Columns.Add("Resim Adı");
            resim.Columns.Add("Resim Yolu");
            DataRow _ravi = resim.NewRow();


            if (txtStokKodu.Text != "" || txtStokKodu.Text == null)
            {

                DirectoryInfo d = new DirectoryInfo(@"..\..\Pictures\");

                FileInfo[] Files = d.GetFiles(txtStokKodu.Text.Replace(" ", "") + "*.png");
                FileInfo[] Files2 = d.GetFiles(txtStokKodu.Text.Replace(" ", "") + "*.jpg");
                FileInfo[] Files3 = d.GetFiles(txtStokKodu.Text.Replace(" ", "") + "*.gif");
                FileInfo[] Files4 = d.GetFiles(txtStokKodu.Text.Replace(" ", "") + "*.jpeg");

                foreach (FileInfo file in Files)
                {
                    resim.Rows.Add(new object[] { file.Name, file.FullName });
                }
                foreach (FileInfo file2 in Files2)
                {
                    resim.Rows.Add(new object[] { file2.Name, file2.FullName });
                }
                foreach (FileInfo file3 in Files3)
                {
                    resim.Rows.Add(new object[] { file3.Name, file3.FullName });
                }
                foreach (FileInfo file4 in Files4)
                {
                    resim.Rows.Add(new object[] { file4.Name, file4.FullName });
                }
                listBox1.DataSource = resim;
                label20.Text = "Toplam Resim : " + listBox1.Items.Count.ToString();
            }
            else
            {
                label20.Text = "Toplam Resim : 0";
            }
        }


        public void cmbSinif()
        {
            if (cmbSinif1.SelectedValue == null)
            {
                cmbSinif1.DisplayMember = "sAciklama";
                cmbSinif1.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "1");
                Prm.Add("@parentid", "0");
                sinif1 = conn.DfQuery("Sinif", Prm);
                cmbSinif1.DataSource = sinif1;
            }
        }
        DataTable fiyatlar = new DataTable();
        public void FiyatCek(string _sModel, string _tipi)
        {
            Dictionary<string, string> fiyat = new Dictionary<string, string>();
            fiyat.Add("@sModel", _sModel);
            fiyat.Add("@sFiyatTipi",_tipi);
            fiyatlar = conn.DfQuery("entegre_Fiyat_Cek", fiyat);
            gridFiyatlar.DataSource = fiyatlar;
        }
        public string filename = "";
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index >= 0)
            {

                var lst = listBox1.Items[index].ToString();

                string file = @"..\..\Pictures\" + txtStokKodu.Text.ToString();
                string dosya = listBox1.SelectedValue.ToString();
                int satirno = listBox1.SelectedIndex;
                pictureBox1.Image = Image.FromFile(dosya);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtFileAdress.Text != "")
            {
                //frmResim frmResim = new frmResim(sModel);
                //frmResim.ShowDialog();

                string fileLocation = txtFileAdress.Text;

                Dictionary<string, string> Rsm = new Dictionary<string, string>();
                Rsm.Add("@sModel", txtStokKodu.Text.Replace(" ", ""));
                var fileCount = conn.DfQuery("Entegref_Resim", Rsm);

                string sira = fileCount.Rows.Count.ToString();
                int sub1 = filename.IndexOf(@".");
                int sub2 = filename.Length - filename.IndexOf(@".");


                string pictureName = txtStokKodu.Text.Replace(" ", "") + "_" + sira + filename.Substring(sub1, sub2);
                string fileLocation2 = Path.Combine(@"..\..\Pictures\", Path.GetFileName(pictureName));

                DirectoryInfo d = new DirectoryInfo(@"..\..\Pictures\");
                var sonuc = d.GetFiles("*.*");
                bool var = false;
                for (int i = 0; i < sonuc.Length; i++)
                {
                    if (sonuc[i].Name.ToString() == pictureName)
                    {
                        var = true;
                    }
                }
                if (var == false)
                {
                    File.Copy(txtFileAdress.Text, Path.Combine(@"..\..\Pictures\", Path.GetFileName(pictureName)), true);
                }
                var = false;
                DirectoryInfo d2 = new DirectoryInfo(@"..\..\Pictures\");
                var sonuc2 = d2.GetFiles("*.*");

                for (int i = 0; i < sonuc2.Length; i++)
                {
                    if (sonuc2[i].Name.ToString() == pictureName)
                    {
                        var = true;
                    }
                }

                if (var == true)
                {
                    Dictionary<string, string> Rsm2 = new Dictionary<string, string>();
                    Rsm2.Add("@sModel", txtStokKodu.Text.Replace(" ", ""));
                    Rsm2.Add("sLocation", fileLocation2);
                    Rsm2.Add("@sResimAdi", pictureName);
                    Rsm2.Add("@sKullaniciAdi", frmLogin.username);
                    conn.DfInsert("Entegref_Resim_insert", Rsm2);
                }
                else
                {
                }

                txtFileAdress.Text = null;
            }
            Resimler();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cmbOTV.Enabled = true;
            }
            else
            {
                cmbOTV.Enabled = false;
            }
        }

        private void btnStokBul_Click(object sender, EventArgs e)
        {
            frmStokBul stokBul = new frmStokBul();
            stokBul.ShowDialog();
            txtStokKodu.Text = sModel;
        }
        //Fiyat Girişi
        private void grpFTipiSec_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (grpFTipiSec.SelectedIndex.ToString() == "0")
            {
                simpleButton4.Text = "Fiyat Gir";
                pnlTopluFiyat.Visible = false;
                pnlTekfiyat.Visible = true;
                txtTipi.Text = null;
                gridFiyatlar.Visible = true;
                gridFiyatlar.Dock = DockStyle.Fill;
            }
            if (grpFTipiSec.SelectedIndex.ToString() == "1")
            {
                simpleButton4.Text = "Fiyatları Güncelle";
                pnlTopluFiyat.Visible = true;
                pnlTekfiyat.Visible = false;
                pnlTopluFiyat.Dock = DockStyle.Fill;
                gridFiyatlar.Visible = false;


                DataTable fiyat_yeni = new DataTable();
                Dictionary<string, string> fiyat = new Dictionary<string, string>();
                fiyat.Add("@sModel", txtStokKodu.Text);
                fiyat.Add("@sFiyatTipi", "T");
                fiyat_yeni = conn.DfQuery("entegre_Fiyat_Cek", fiyat);

                //string Fiyatsql = "select ff.nStokID,t.sFiyatTipi, t.sAciklama,dteFiyatTespitTarihi,lFiyat,0 from tbFiyatTipi t ";
                //Fiyatsql = Fiyatsql + " left join(select f.nStokID,f.lFiyat, f.dteFiyatTespitTarihi, f.sFiyatTipi from tbStokFiyati f ";
                //Fiyatsql = Fiyatsql + "inner join tbstok s on s.nStokID= f.nStokID where s.sModel = isnull('" + txtStokKodu.Text + "','')";
                //Fiyatsql = Fiyatsql + ") ff on ff.sFiyatTipi = t.sFiyatTipi";
                //SqlCommand cmd = new SqlCommand(Fiyatsql, connection);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //if (connection.State == ConnectionState.Closed)
                //{
                //    connection.Open();
                //}
                //da.Fill(fiyat_yeni);
                //connection.Close();
                gridTopluFiyat.DataSource = fiyat_yeni;
            }
        }
        private void grpFTipiSec_Click(object sender, EventArgs e)
        {

            if (grpFTipiSec.SelectedIndex.ToString() == "0")
            {
                pnlTopluFiyat.Visible = false;
                pnlTekfiyat.Visible = true;
                txtTipi.Text = null;
            }
            if (grpFTipiSec.SelectedIndex.ToString() == "1")
            {
                pnlTopluFiyat.Visible = true;
                pnlTekfiyat.Visible = false;
                txtTipi.Text = null;


                DataTable fiyat_yeni = new DataTable();
                string Fiyatsql = "select ff.nStokID,t.sFiyatTipi, t.sAciklama,dteFiyatTespitTarihi,lFiyat from tbFiyatTipi t ";
                Fiyatsql = Fiyatsql + " left join(select f.nStokID,f.lFiyat, f.dteFiyatTespitTarihi, f.sFiyatTipi from tbStokFiyati f ";
                Fiyatsql = Fiyatsql + "inner join tbstok s on s.nStokID= f.nStokID where s.sModel = isnull('" + txtStokKodu.Text + "','')";
                Fiyatsql = Fiyatsql + ") ff on ff.sFiyatTipi = t.sFiyatTipi";
                SqlCommand cmd = new SqlCommand(Fiyatsql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                da.Fill(fiyat_yeni);
                connection.Close();
                gridTopluFiyat.DataSource = fiyat_yeni;
            }
        }
        private void btnFiyatTipiAc_Click(object sender, EventArgs e)
        {
            sFiyatTipi = "";
            frmFiyatTipi fiyatTipi = new frmFiyatTipi(this.Name.ToString());
            fiyatTipi.ShowDialog();
            txtTipi.Text = sFiyatTipi;
            Fiyatbul(txtStokKodu.Text);

        }
        string lfiyat = "";
        public void Fiyatbul(string _sModel)
        {
            string q =  "select tbFiyatTipi.sFiyatTipi ,  isnull(lFiyat,0) , isnull(convert(char(10), dteFiyatTespitTarihi, 103), '01/01/1900') "+
                        "from tbFiyatTipi "+
                        "left outer join "+
                        "( select distinct(sFiyatTipi) as sFiyatTipi, lFiyat, dteFiyatTespitTarihi "+
                        "from tbStokFiyati,tbStok "+
                        "Where tbStokFiyati.nStokID = tbStok.nStokID "+
                        "and tbStok.sModel = '"+ _sModel + "' ) as Fiyat on tbFiyatTipi.sFiyatTipi = Fiyat.sFiyatTipi "+
                        "order by tbFiyatTipi.sFiyatTipi";
            SqlCommand cmd = new SqlCommand(q, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][1].ToString() == txtTipi.Text)
            {
                txtYeniFiyat.Text = dt.Rows[0][0].ToString();
                dteYeniFiyat.DateTime = Convert.ToDateTime(dt.Rows[0]["dteFiyatTespitTarihi"].ToString());
            }
            else
            {

                txtYeniFiyat.Text = "0";
                dteYeniFiyat.DateTime = DateTime.Now;
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (grpFTipiSec.SelectedIndex.ToString() == "0")
            {
                Dictionary<string, string> FiyatGir = new Dictionary<string, string>();
                FiyatGir.Add("@sModel", txtStokKodu.Text);
                FiyatGir.Add("@sFiyatTipi", txtTipi.Text);
                FiyatGir.Add("@lFiyat", txtYeniFiyat.Text);
                FiyatGir.Add("@User", frmLogin.username);
                FiyatGir.Add("@tarih", Convert.ToDateTime(dteYeniFiyat.EditValue).ToString("dd/MM/yyyy"));
                FiyatGir.Add("@ReturnDesc", "");
                var dt = conn.DfInsertBack("entegref_Fiyat_Gir", FiyatGir);
                XtraMessageBox.Show(Fiyat.ToString() + " Adet Renk / Beden / Kavala olarak Fiyat oluştu");
                FiyatCek(txtStokKodu.Text, "");
                txtTipi.Text = null;
                txtYeniFiyat.Text = null;
                dteYeniFiyat.DateTime = DateTime.Now;


            }
            if (grpFTipiSec.SelectedIndex.ToString() == "1")
            {
                for (int i = 0; i < ViewTopluFiyat.RowCount; i++)
                {
                    Dictionary<string, string> FiyatGir = new Dictionary<string, string>();
                    FiyatGir.Add("@sModel", txtStokKodu.Text);
                    FiyatGir.Add("@sFiyatTipi", ViewTopluFiyat.GetRowCellValue(i, "sFiyatTipi").ToString());
                    FiyatGir.Add("@lFiyat", ViewTopluFiyat.GetRowCellValue(i, "YeniFiyat").ToString());
                    FiyatGir.Add("@User", frmLogin.username);
                    FiyatGir.Add("@tarih", ViewTopluFiyat.GetRowCellValue(i, "dteFiyatTespitTarihi").ToString());
                    FiyatGir.Add("@ReturnDesc", "");
                    var dt = conn.DfInsertBack("entegref_Fiyat_Gir", FiyatGir);
                }
            }

        }
        private void txtTipi_TextChanged(object sender, EventArgs e)
        {
            if (txtTipi.Text.Count() >= 2)
            {
                txtYeniFiyat.Enabled = true;
                dteYeniFiyat.Enabled = true;
            }
            else
            {
                txtYeniFiyat.Enabled = false;
                dteYeniFiyat.Enabled = false;

            }
        }
        //Ürün Sınıfları
        private void cmbSinif1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif1.SelectedValue != null) 
            {
                cmbSinif2.DisplayMember = "sAciklama";
                cmbSinif2.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "2");
                Prm.Add("@parentid", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif2 = conn.DfQuery("Sinif", Prm);                
                if (sinif2.Rows.Count > 1)
                {
                    cmbSinif2.DataSource = sinif2;
                    cmbSinif2.Enabled = true;
                }
                else
                {
                    sinif2.Clear();
                    cmbSinif2.Enabled = false;
                    cmbSinif2.DataSource = null;
                }

            }
            else
            {
                sinif2.Clear();
                cmbSinif2.Enabled = false;
                cmbSinif2.DataSource = null;
                sinif3.Clear();
                cmbSinif3.Enabled = false;
                cmbSinif3.DataSource = null;
                sinif4.Clear();
                cmbSinif4.Enabled = false;
                cmbSinif4.DataSource = null;
                sinif5.Clear();
                cmbSinif5.Enabled = false;
                cmbSinif5.DataSource = null;
                sinif6.Clear();
                cmbSinif6.Enabled = false;
                cmbSinif6.DataSource = null;
            }

        }
        private void cmbSinif2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif2.SelectedValue.ToString() != "00-0")
            {
                cmbSinif3.DisplayMember = "sAciklama";
                cmbSinif3.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "3");
                Prm.Add("@parentid", cmbSinif2.SelectedValue.ToString().Substring(cmbSinif2.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif3 = conn.DfQuery("Sinif", Prm);
                cmbSinif3.DataSource = sinif3;
                if (sinif3.Rows.Count > 1)
                {
                    cmbSinif3.SelectedValue = sinifsira3;
                    cmbSinif3.Enabled = true;
                }
                else
                {
                    sinif3.Clear();
                    cmbSinif3.Enabled = false;
                    cmbSinif3.DataSource = null;
                }

            }
            else if (sinifsira2 != "")
            {
                cmbSinif2.SelectedValue = sinifsira2;
                cmbSinif3.DisplayMember = "sAciklama";
                cmbSinif3.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "3");
                Prm.Add("@parentid", cmbSinif2.SelectedValue.ToString().Substring(cmbSinif2.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif3 = conn.DfQuery("Sinif", Prm);
                cmbSinif3.DataSource = sinif3;
                if (sinif3.Rows.Count > 1)
                {
                    cmbSinif3.SelectedValue = sinifsira3;
                    cmbSinif3.Enabled = true;
                }

            }
            else
            {
                if (sinif3.Rows.Count > 1)
                {
                    cmbSinif3.Enabled = true;
                }
                else
                {
                    sinif3.Clear();
                    cmbSinif3.Enabled = false;
                    cmbSinif3.DataSource = null;
                    sinif4.Clear();
                    cmbSinif4.Enabled = false;
                    cmbSinif4.DataSource = null;
                    sinif5.Clear();
                    cmbSinif5.Enabled = false;
                    cmbSinif5.DataSource = null;
                    sinif6.Clear();
                    cmbSinif6.Enabled = false;
                    cmbSinif6.DataSource = null;
                }
            }

        }
        private void cmbSinif3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif3.SelectedValue.ToString() != "00-0")
            {
                cmbSinif4.DisplayMember = "sAciklama";
                cmbSinif4.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "4");
                Prm.Add("@parentid", cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif4 = conn.DfQuery("Sinif", Prm);
                cmbSinif4.DataSource = sinif4;
                if (sinif4.Rows.Count > 1)
                {
                    cmbSinif4.Enabled = true;
                }
                else
                {
                    sinif4.Clear();
                    cmbSinif4.Enabled = false;
                    cmbSinif4.DataSource = null;
                }

            }
            else if (sinifsira3 != "")
            {
                cmbSinif3.SelectedValue = sinifsira3;
                cmbSinif4.DisplayMember = "sAciklama";
                cmbSinif4.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "4");
                Prm.Add("@parentid", cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif4 = conn.DfQuery("Sinif", Prm);
                cmbSinif4.DataSource = sinif4;
                if (sinif4.Rows.Count > 1)
                {
                    cmbSinif4.Enabled = true;
                }
                else
                {
                    sinif4.Clear();
                    cmbSinif4.Enabled = false;
                    cmbSinif4.DataSource = null;
                }
            }
            else
            {
                sinif4.Clear();
                cmbSinif4.Enabled = false;
                cmbSinif4.DataSource = null;
                sinif5.Clear();
                cmbSinif5.Enabled = false;
                cmbSinif5.DataSource = null;
                sinif6.Clear();
                cmbSinif6.Enabled = false;
                cmbSinif6.DataSource = null;
            }

        }
        private void cmbSinif4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif4.SelectedValue.ToString() != "00-0")
            {
                cmbSinif5.DisplayMember = "sAciklama";
                cmbSinif5.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "5");
                Prm.Add("@parentid", cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif5 = conn.DfQuery("Sinif", Prm);
                cmbSinif5.DataSource = sinif5;
                if (sinif5.Rows.Count > 1)
                {
                    cmbSinif5.Enabled = true;
                }
                else
                {
                    cmbSinif5.Enabled = false;
                    cmbSinif5.DataSource = null;
                    sinif5.Clear();
                }

            }
            else
            {
                sinif5.Clear();
                cmbSinif5.Enabled = false;
                cmbSinif5.DataSource = null;
                sinif6.Clear();
                cmbSinif6.Enabled = false;
                cmbSinif6.DataSource = null;
            }

        }
        private void cmbSinif5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif5.SelectedValue.ToString() != "00-0")
            {
                cmbSinif6.DisplayMember = "sAciklama";
                cmbSinif6.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "6");
                Prm.Add("@parentid", cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif6 = conn.DfQuery("Sinif", Prm);
                cmbSinif6.DataSource = sinif6;
                cmbSinif6.Enabled = true;

            }
            else
            {
                sinif6.Clear();
                cmbSinif6.Enabled = false;
                cmbSinif6.DataSource = null;
            }

        }

        renkbeden rnb;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmRenk frm = new frmRenk(KavalaTipi, BedenTipi);
            frm.ShowDialog();

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            new Root();
            txtRenk.Text = null;
            lblRenk.Text = "Renk";

            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            chk4.Checked = false;
            chk5.Checked = false;
            chk6.Checked = false;
            chk7.Checked = false;
            chk8.Checked = false;
            chk9.Checked = false;
            chk10.Checked = false;
            chk11.Checked = false;
            chk12.Checked = false;
            chk13.Checked = false;
            chk14.Checked = false;
            chk15.Checked = false;
            chk16.Checked = false;
            chk17.Checked = false;
            chk18.Checked = false;
            chk19.Checked = false;
            chk20.Checked = false;
            chk1.Visible = true;
            chk2.Visible = true;
            chk3.Visible = true;
            chk4.Visible = true;
            chk5.Visible = true;
            chk6.Visible = true;
            chk7.Visible = true;
            chk8.Visible = true;
            chk9.Visible = true;
            chk10.Visible = true;
            chk11.Visible = true;
            chk12.Visible = true;
            chk13.Visible = true;
            chk14.Visible = true;
            chk15.Visible = true;
            chk16.Visible = true;
            chk17.Visible = true;
            chk18.Visible = true;
            chk19.Visible = true;
            chk20.Visible = true;
            cmbOzellik1.Visible = true;
            cmbOzellik2.Visible = true;
            cmbOzellik3.Visible = true;
            cmbOzellik4.Visible = true;
            cmbOzellik5.Visible = true;
            cmbOzellik6.Visible = true;
            cmbOzellik7.Visible = true;
            cmbOzellik8.Visible = true;
            cmbOzellik9.Visible = true;
            cmbOzellik10.Visible = true;
            cmbOzellik11.Visible = true;
            cmbOzellik12.Visible = true;
            cmbOzellik13.Visible = true;
            cmbOzellik14.Visible = true;
            cmbOzellik15.Visible = true;
            cmbOzellik16.Visible = true;
            cmbOzellik17.Visible = true;
            cmbOzellik18.Visible = true;
            cmbOzellik19.Visible = true;
            cmbOzellik20.Visible = true;
            lblOzellik1.Visible = true;
            lblOzellik2.Visible = true;
            lblOzellik3.Visible = true;
            lblOzellik4.Visible = true;
            lblOzellik5.Visible = true;
            lblOzellik6.Visible = true;
            lblOzellik7.Visible = true;
            lblOzellik8.Visible = true;
            lblOzellik9.Visible = true;
            lblOzellik10.Visible = true;
            lblOzellik11.Visible = true;
            lblOzellik12.Visible = true;
            lblOzellik13.Visible = true;
            lblOzellik14.Visible = true;
            lblOzellik15.Visible = true;
            lblOzellik16.Visible = true;
            lblOzellik17.Visible = true;
            lblOzellik18.Visible = true;
            lblOzellik19.Visible = true;
            lblOzellik20.Visible = true;
            cmbOzellik1.DataSource = null;
            cmbOzellik2.DataSource = null;
            cmbOzellik3.DataSource = null;
            cmbOzellik4.DataSource = null;
            cmbOzellik5.DataSource = null;
            cmbOzellik6.DataSource = null;
            cmbOzellik7.DataSource = null;
            cmbOzellik8.DataSource = null;
            cmbOzellik9.DataSource = null;
            cmbOzellik10.DataSource = null;
            cmbOzellik11.DataSource = null;
            cmbOzellik12.DataSource = null;
            cmbOzellik13.DataSource = null;
            cmbOzellik14.DataSource = null;
            cmbOzellik15.DataSource = null;
            cmbOzellik16.DataSource = null;
            cmbOzellik17.DataSource = null;
            cmbOzellik18.DataSource = null;
            cmbOzellik19.DataSource = null;
            cmbOzellik20.DataSource = null;
            lblOzellik1.Text= "OZellik";
            lblOzellik2.Text= "OZellik";
            lblOzellik3.Text= "OZellik";
            lblOzellik4.Text= "OZellik";
            lblOzellik5.Text= "OZellik";
            lblOzellik6.Text= "OZellik";
            lblOzellik7.Text= "OZellik";
            lblOzellik8.Text= "OZellik";
            lblOzellik9.Text= "OZellik";
            lblOzellik10.Text = "OZellik";
            lblOzellik11.Text = "OZellik";
            lblOzellik12.Text = "OZellik";
            lblOzellik13.Text = "OZellik";
            lblOzellik14.Text = "OZellik";
            lblOzellik15.Text = "OZellik";
            lblOzellik16.Text = "OZellik";
            lblOzellik17.Text = "OZellik";
            lblOzellik18.Text = "OZellik";
            lblOzellik19.Text = "OZellik";
            lblOzellik20.Text = "OZellik";
            lblOzellik1.Tag = null;
            lblOzellik2.Tag = null;
            lblOzellik3.Tag = null;
            lblOzellik4.Tag = null;
            lblOzellik5.Tag = null;
            lblOzellik6.Tag = null;
            lblOzellik7.Tag = null;
            lblOzellik8.Tag = null;
            lblOzellik9.Tag = null;
            lblOzellik10.Tag = null;
            lblOzellik11.Tag = null;
            lblOzellik12.Tag = null;
            lblOzellik13.Tag = null;
            lblOzellik14.Tag = null;
            lblOzellik15.Tag = null;
            lblOzellik16.Tag = null;
            lblOzellik17.Tag = null;
            lblOzellik18.Tag = null;
            lblOzellik19.Tag = null;
            lblOzellik20.Tag = null;
            txtBarkod.Text = "";
            txtFirma.Text = "";
            txtFirmaStokKod.Text = "";
            txtFirmaStokAd.Text = "";
            renkolanlar.Clear();
            renkolanlar.Columns.Clear();
            txtStokKodu.Text = null;
            sRenkKodu = null;
            bunifuCustomTextbox1.Text = null;
            bunifuCustomTextbox2.Text = null;
            bunifuCustomTextbox3.Text = null;
            lblFiyattipi.Visible = false;
            nStokID = null;
            //ultraTabControl1.VisibleTabs[1].Visible = false;
            //ultraTabControl1.VisibleTabs[2].Visible = false;
            //ultraTabControl1.VisibleTabs[3].Visible = false;
            btnStokBul.Enabled = true;
            ultraButton1.Enabled = true;
            ultraButton2.Enabled = true;
            simpleButton3.Enabled = true;
            frmStokAc_Load(null, null);
            sModel = null;
            sFiyatTipi = null;
            sinifsira1 = null;
            sinifsira2 = null;
            sinifsira3 = null;
            sinifsira4 = null;
            sinifsira5 = null;
            sinifsira6 = null;
            Fiyatlandirma = null;
            Beden = null;
            Kavala = null;
            sinif1.Clear();
            sinif2.Clear();
            sinif3.Clear();
            sinif4.Clear();
            sinif5.Clear();
            sinif6.Clear();
            txtFileAdress.Text = null;
            txtStokKodu.Enabled = true;
            pictureBox1.InitialImage = null;
            pictureBox1.Image = null;
            gridTrendyol_marka.DataSource = null;
            cmbMarka.DataSource = null;
            txtMarkaAra.Text = null;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DataTable attribute_avp = new DataTable();
            attribute_avp.Columns.Add("Selected");
            attribute_avp.Columns.Add("Values");
            for (int i = 0; i < attribute.Rows.Count; i++)
            {
                var dt = attribute.Rows[i][0].ToString();
                for (int ii = 0; ii < panel9.Controls.Count; ii++)
                {
                    if (panel9.Controls[ii].Name == dt)
                    {
                        if (attribute.Rows[i][1].ToString()=="TextBox")
                        {
                            attribute_avp.Rows.Add(new object[] { panel9.Controls[ii - 1].Text.Replace("* Zorunlu Alan",""), panel9.Controls[ii].Text });
                        }
                        else
                        {
                            attribute_avp.Rows.Add(new object[] { panel9.Controls[ii - 1].Text.Replace("* Zorunlu Alan", ""), panel9.Controls[ii].Text });
                        }
                    }
                    
                }
            }
            for (int i = 0; i < renkolanlar.Rows.Count; i++)
            {
                Dictionary<string, string> Stok = new Dictionary<string, string>();
                Stok.Add("@sKodu", txtStokKodu.Text);
                Stok.Add("@sAciklama", bunifuCustomTextbox1.Text);
                Stok.Add("@sKisaAdi", cmbMarka.SelectedValue.ToString());
                Stok.Add("@nStokTipi", nStokTipi);
                Stok.Add("@sBedenTipi", renkolanlar.Rows[i]["sBedenTipi"].ToString());
                Stok.Add("@sKavalaTipi", renkolanlar.Rows[i]["sKavalaTipi"].ToString());
                Stok.Add("@sRenk", renkolanlar.Rows[i]["sRenk"].ToString());
                Stok.Add("@sBeden", renkolanlar.Rows[i]["sBeden"].ToString());
                Stok.Add("@sKavala", renkolanlar.Rows[i]["sKavala"].ToString());
                Stok.Add("@sBirimCinsi1", cmbBirim1.SelectedValue.ToString());
                Stok.Add("@sBirimCinsi2", cmbBirim2.SelectedValue.ToString());
                if (bunifuCustomTextbox5.Text == "")
                {
                    Stok.Add("@nIskontoYuzdesi", "0");
                }
                else
                {
                Stok.Add("@nIskontoYuzdesi", bunifuCustomTextbox5.Text);
                }
                Stok.Add("@sKdvTipi", cmbKDV.SelectedValue.ToString());

                Stok.Add("@nTeminSuresi", "0");
                Stok.Add("@lAsgariMiktar", "0");
                Stok.Add("@lAzamiMiktar", "0");
                Stok.Add("@sOzelNot", bunifuCustomTextbox2.Text);
                Stok.Add("@nFiyatlandirma", nFiyatlandirma);
                Stok.Add("@sModel", txtStokKodu.Text);
                Stok.Add("@sKullaniciAdi", frmLogin.username);
                if (checkBox2.Checked == true)
                {
                    Stok.Add("@bEksiyeDusulebilirmi", "1");
                    Stok.Add("@bEksideUyarsinmi", "1");
                }
                else
                {
                    Stok.Add("@bEksiyeDusulebilirmi", "0");
                    Stok.Add("@bEksideUyarsinmi", "0");
                }
                if (checkBox1.Checked == true)
                {
                    Stok.Add("@bOTVVar", "1");
                    Stok.Add("@sOTVTipi", cmbOTV.SelectedValue.ToString());
                }
                else
                {
                    Stok.Add("@bOTVVar", "0");
                    Stok.Add("@sOTVTipi", "");
                }
                Stok.Add("@sUzunNote", miniHTMLTextBox1.Text);
                Stok.Add("@sSinifKodu20", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-") + 1));
                Stok.Add("@sSinifKodu21", cmbSinif2.SelectedValue.ToString().Substring(cmbSinif2.SelectedValue.ToString().IndexOf("-") + 1));
                if (cmbSinif3.SelectedValue.ToString() == "00-0")
                {
                    Stok.Add("@sSinifKodu22", "");
                }
                else
                {
                    Stok.Add("@sSinifKodu22", cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1));
                }
                if (cmbSinif4.SelectedValue==null)
                {
                    Stok.Add("@sSinifKodu23", "");
                }
                else
                {
                    Stok.Add("@sSinifKodu23", cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1));
                }
                if (cmbSinif5.SelectedValue == null)
                {
                    Stok.Add("@sSinifKodu24", "");
                }
                else
                {
                    Stok.Add("@sSinifKodu24", cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1));
                }
                if (cmbSinif6.SelectedValue == null)
                {
                    Stok.Add("@sSinifKodu25", "");
                }
                else
                {
                    Stok.Add("@sSinifKodu25", cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1));
                }
                //Stok.Add("@attribute1",panel9.Controls.Count);
                conn.DfInsert("Entegref_Create_Item", Stok);


            }

            //if (nStokID != null)
            //{  var dd = miniHTMLTextBox1.Text;
            //    Dictionary<string, string> guncelle = new Dictionary<string, string>();
            //}
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnBarkodSil_Click(object sender, EventArgs e)
        {
            txtBarkod.Text = "";
            txtFirma.Text = "";
            txtFirmaStokKod.Text = "";
            txtFirmaStokAd.Text = "";
            btnBarkodIslem.Text = "Ekle";
        }

        public static string nfirmaId = "";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmFirmaBul firmaBul = new frmFirmaBul();
            firmaBul.Show();
            txtFirma.Text = nfirmaId;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                txtBarkod.MaxLength = 13;
            }
            else
            {
                txtBarkod.MaxLength = 20;
            }
        }

        private void btnBarkodIslem_Click(object sender, EventArgs e)
        {
            Barkod.Rows.Add(new object[] { txtBarkod.Text, txtFirma.Text, txtFirmaStokKod.Text, txtFirmaStokAd.Text });
        }

        private void ViewBarkod_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                txtBarkod.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sBarkod").ToString();
                txtFirma.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sFirmaKodu").ToString();
                txtFirmaStokKod.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sKarsiStokKodu").ToString();
                txtFirmaStokAd.Text = ViewBarkod.GetRowCellValue(ViewBarkod.FocusedRowHandle, "sKarsiStokAciklama").ToString();
                btnBarkodIslem.Text = "SİL";
            }
        }
    }
}
