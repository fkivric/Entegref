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

        //Trendyol Siniflar
        DataTable sinif1 = new DataTable();
        DataTable sinif2 = new DataTable();
        DataTable sinif3 = new DataTable();
        DataTable sinif4 = new DataTable();
        DataTable sinif5 = new DataTable();
        DataTable sinif6 = new DataTable();
        //Ciceksepeti Siniflar
        DataTable sinif7 = new DataTable();
        DataTable sinif8 = new DataTable();
        DataTable sinif9 = new DataTable();
        DataTable sinif10 = new DataTable();
        DataTable sinif11 = new DataTable();
        DataTable sinif12 = new DataTable();


        DataTable attribute_avp = new DataTable();



        public static string sRenkKodu = "";
        public static string sModel = "";
        public static string sFiyatTipi = "";

        public static string sinifsira1;
        public static string sinifsira2;
        public static string sinifsira3;
        public static string sinifsira4;
        public static string sinifsira5;
        public static string sinifsira6;
        public static string sinifsira7;
        public static string sinifsira8;
        public static string sinifsira9;
        public static string sinifsira10;
        public static string sinifsira11;
        public static string sinifsira12;


        public static string Fiyatlandirma;
        public static string nFiyatlandirma;
        public static string nStokTipi;
        public static string Beden;
        public static string Kavala;
        public static string BedenTipi;
        public static string KavalaTipi;
        public static bool Renk = false;
        public static int Atturubite;
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
                ultraTabControl1.VisibleTabs[1].Visible = false;
                ultraTabControl1.VisibleTabs[2].Visible = false;
                ultraTabControl1.VisibleTabs[3].Visible = false;
                ultraTabControl1.VisibleTabs[4].Visible = false;
                ultraTabControl1.VisibleTabs[5].Visible = false;
                ultraTabControl1.VisibleTabs[6].Visible = false;
                ultraTabControl1.VisibleTabs[7].Visible = false;
                ultraTabControl1.VisibleTabs[8].Visible = false;
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
            attribute_avp.Rows.Clear();
            if (txtStokKodu != null && txtStokKodu.Text != "")
            {
                Markalar();
                btnbarkod();
                panel2.Enabled = true;
                Dictionary<string, string> Stk = new Dictionary<string, string>();
                Stk.Add("@smodel", txtStokKodu.Text);
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
                    txtsAciklama.Text = Urun.Rows[0]["sAciklama"].ToString();
                    cmbBirim1.Text = Urun.Rows[0]["sBirimCinsi1"].ToString();
                    cmbBirim2.Text = Urun.Rows[0]["sBirimCinsi2"].ToString();
                    cmbKDV.Text = Urun.Rows[0]["sKdvTipi"].ToString();
                    txtMarka.Text = Urun.Rows[0]["sKisaAdi"].ToString().Substring(Urun.Rows[0]["sKisaAdi"].ToString().IndexOf("-") + 1);
                    txtMarkaAra.Text = Urun.Rows[0]["sKisaAdi"].ToString().Substring(Urun.Rows[0]["sKisaAdi"].ToString().IndexOf("-") + 1);
                    txtsAciklama.Text = Urun.Rows[0]["sAciklama"].ToString();
                    miniHTMLTextBox1.Text = Urun.Rows[0]["sUzunNot"].ToString();
                    sinifsira1 = Urun.Rows[0]["sSinifKodu1"].ToString().Replace(" ", "");
                    sinifsira2 = Urun.Rows[0]["sSinifKodu2"].ToString().Replace(" ", "");
                    sinifsira3 = Urun.Rows[0]["sSinifKodu3"].ToString().Replace(" ", "");
                    sinifsira4 = Urun.Rows[0]["sSinifKodu4"].ToString().Replace(" ", "");
                    sinifsira5 = Urun.Rows[0]["sSinifKodu5"].ToString().Replace(" ", "");
                    sinifsira6 = Urun.Rows[0]["sSinifKodu6"].ToString().Replace(" ", "");
                    sinifsira7 = Urun.Rows[0]["sSinifKodu7"].ToString().Replace(" ", "");
                    sinifsira8 = Urun.Rows[0]["sSinifKodu8"].ToString().Replace(" ", "");
                    sinifsira9 = Urun.Rows[0]["sSinifKodu9"].ToString().Replace(" ", "");
                    sinifsira10 = Urun.Rows[0]["sSinifKodu10"].ToString().Replace(" ", "");
                    sinifsira11 = Urun.Rows[0]["sSinifKodu11"].ToString().Replace(" ", "");
                    sinifsira12 = Urun.Rows[0]["sSinifKodu12"].ToString().Replace(" ", "");

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
                    var st = Urun.Rows[0]["sKisaAdi"].ToString().Substring(Urun.Rows[0]["sKisaAdi"].ToString().IndexOf("-") + 1);
                    nStokID = Urun.Rows[0]["nStokID"].ToString();
                    KavalaTipi = Urun.Rows[0]["sKavalaTipi"].ToString();
                    BedenTipi = Urun.Rows[0]["sBedenTipi"].ToString();
                    txtsAciklama.Text = Urun.Rows[0]["sAciklama"].ToString();
                    cmbBirim1.Text = Urun.Rows[0]["sBirimCinsi1"].ToString();
                    cmbBirim2.Text = Urun.Rows[0]["sBirimCinsi2"].ToString();
                    cmbKDV.Text = Urun.Rows[0]["sKdvTipi"].ToString();
                    txtMarka.Text = Urun.Rows[0]["sKisaAdi"].ToString().Substring(Urun.Rows[0]["sKisaAdi"].ToString().IndexOf("-") + 1);
                    txtMarkaAra.Text = Urun.Rows[0]["sKisaAdi"].ToString().Substring(Urun.Rows[0]["sKisaAdi"].ToString().IndexOf("-") + 1);
                    miniHTMLTextBox1.Text = Urun.Rows[0]["sUzunNot"].ToString();
                    sinifsira1 = Urun.Rows[0]["sSinifKodu1"].ToString().Replace(" ", "");
                    sinifsira2 = Urun.Rows[0]["sSinifKodu2"].ToString().Replace(" ", "");
                    sinifsira3 = Urun.Rows[0]["sSinifKodu3"].ToString().Replace(" ", "");
                    sinifsira4 = Urun.Rows[0]["sSinifKodu4"].ToString().Replace(" ", "");
                    sinifsira5 = Urun.Rows[0]["sSinifKodu5"].ToString().Replace(" ", "");
                    sinifsira6 = Urun.Rows[0]["sSinifKodu6"].ToString().Replace(" ", "");
                    sinifsira7 = Urun.Rows[0]["sSinifKodu7"].ToString().Replace(" ", "");
                    sinifsira8 = Urun.Rows[0]["sSinifKodu8"].ToString().Replace(" ", "");
                    sinifsira9 = Urun.Rows[0]["sSinifKodu9"].ToString().Replace(" ", "");
                    sinifsira10 = Urun.Rows[0]["sSinifKodu10"].ToString().Replace(" ", "");
                    sinifsira11 = Urun.Rows[0]["sSinifKodu11"].ToString().Replace(" ", "");
                    sinifsira12 = Urun.Rows[0]["sSinifKodu12"].ToString().Replace(" ", "");
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
                    if (sinifsira7 != null)
                    {
                        if (cmbSinif7.SelectedValue == null)
                        {
                            cmbSinif7.DisplayMember = "sAciklama";
                            cmbSinif7.ValueMember = "sSinifKodu";
                            Dictionary<string, string> Prm = new Dictionary<string, string>();
                            Prm.Add("@sira", "7");
                            Prm.Add("@parentid", "0");
                            sinif1 = conn.DfQuery("Sinif2", Prm);
                            cmbSinif7.DataSource = sinif1;
                            cmbSinif7.SelectedValue = sinifsira7;
                        }

                    }


                }
                else
                {
                    if (frmStokAc.sRenkKodu != null)
                    {
                        int sira = 0;
                        for (int i = 0; i < sRenkKodu.Length / 3; i++)
                        {
                            if (i != 0)
                            {
                                sira += 4;
                            }
                            renkolanlar.Rows.Add(new object[] { "", "", sRenkKodu.Substring(sira, 3), "", "" });
                        }
                        //renkolanlar.Clear();
                        //renkolanlar.Rows.Add(new object[] { sRenkKodu.Substring(0, 3), sRenkKodu.Substring(4, 3), sRenkKodu.Substring(8, 3) });
                    }
                }
                btnStokBul.Enabled = false;
                ultraButton1.Enabled = false;
                ultraButton2.Enabled = false;
                simpleButton3.Enabled = false;
                ultraTabControl1.VisibleTabs[2].Visible = true;
                ultraTabControl1.VisibleTabs[3].Visible = true;
                ultraTabControl1.VisibleTabs[4].Visible = true;
                ultraTabControl1.VisibleTabs[5].Visible = true;
                ultraTabControl1.VisibleTabs[7].Visible = true;
                ultraTabControl1.VisibleTabs[8].Visible = true;

                if (nStokID != null && nStokID != "")
                {
                    //ultraTabControl1.VisibleTabs[6].Visible = true;
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
                if (cmbSinif7.SelectedValue == null)
                {
                    cmbSinif7.DisplayMember = "sAciklama";
                    cmbSinif7.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "7");
                    Prm.Add("@parentid", "0");
                    sinif7 = conn.DfQuery("Sinif2", Prm);
                    cmbSinif7.DataSource = sinif7;
                }
            }
            else if (e.Tab.Text == "Renk Beden Kavala")
            {
                if (nStokID != null)
                {
                    RenkBedenTablo();
                    //dataGridView1.DataSource = null;
                    //pnlRenkBedenOlan.Dock = DockStyle.Fill;
                    //pnlRenkBeden.Visible = false;
                    //string renk = "";
                    //for (int i = 0; i < renkolanlar.Rows.Count; i++)
                    //{
                    //    if (renk == "")
                    //    {
                    //        renk = renkolanlar.Rows[i][2].ToString();
                    //    }
                    //    else if (renk != renkolanlar.Rows[i][2].ToString())
                    //    {
                    //        renk = renk.ToString() + "," + renkolanlar.Rows[i][2].ToString();
                    //    }
                    //}
                    //Dictionary<string, string> MM = new Dictionary<string, string>();
                    //MM.Add("@smodel", txtStokKodu.Text.Substring(0, 12));
                    //if (string.IsNullOrEmpty(KavalaTipi) == true)
                    //{
                    //    MM.Add("@sKavalaTipi", "");
                    //}
                    //else
                    //{
                    //    MM.Add("@sKavalaTipi", KavalaTipi.ToString());
                    //}
                    //if (string.IsNullOrEmpty(KavalaTipi) == true)
                    //{
                    //    MM.Add("@sBedenTipi", "");
                    //}
                    //else
                    //{
                    //    MM.Add("@sBedenTipi", BedenTipi);
                    //}
                    //MM.Add("@sRenkKodu", renk);
                    //var dt = conn.DfQuery("Entegref_Urun_Renk_Beden_Kavala_Sec", MM);
                    //dataGridView1.DataSource = dt;
                    //dataGridView1.AutoResizeColumns();

                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Visible = false;
                    pnlRenkBedenOlan.Visible = false;
                    pnlRenkBeden.Controls.Clear();
                    pnlRenkBeden.Dock = DockStyle.Fill;
                    frmRenk frmRenk = new frmRenk(Kavala, BedenTipi);
                    frmRenk.TopLevel = false;
                    pnlRenkBeden.Controls.Add(frmRenk);
                    frmRenk.Show();
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
            Barkod.Clear();
            string query = "select sBarkod,(select sKodu from tbfirma f where f.nFirmaID = b.nFirmaID) as sFirmaKodu,sKarsiStokKodu,sKarsiStokAciklama from [" + Properties.Settings.Default.VKN + "].dbo.tbStokBarkodu b ";
            query = query + " inner join ["+Properties.Settings.Default.VKN+"].dbo.tbStok s on s.nStokID = b.nStokID";
            query = query + " where s.sModel = '" + txtStokKodu.Text.ToString() + "'";
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
            frmTrendyol_Sinif sinifi = new frmTrendyol_Sinif();
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
            sinif7.Clear();
            sinif8.Clear();
            sinif9.Clear();
            sinif10.Clear();
            sinif11.Clear();
            sinif12.Clear();

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

            if (sinifsira7 != null)
            {
                if (cmbSinif1.SelectedValue == null)
                {
                    cmbSinif7.DisplayMember = "sAciklama";
                    cmbSinif7.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "7");
                    Prm.Add("@parentid", "0");
                    sinif1 = conn.DfQuery("Sinif2", Prm);
                    cmbSinif7.DataSource = sinif1;
                    cmbSinif7.SelectedValue = sinifsira1;
                }
            }
            if (cmbSinif8.SelectedValue != null)
            {
                cmbSinif8.DisplayMember = "sAciklama";
                cmbSinif8.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "8");
                Prm.Add("@parentid", cmbSinif7.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-") + 1, 4));
                sinif8 = conn.DfQuery("Sinif2", Prm);
                cmbSinif8.DataSource = sinif8;
                cmbSinif8.SelectedValue = sinifsira8;
            }

            if (sinifsira9 != null && sinifsira9 != "00-0")
            {
                if (cmbSinif8.SelectedValue != null)
                {
                    cmbSinif9.DisplayMember = "sAciklama";
                    cmbSinif9.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "9");
                    Prm.Add("@parentid", cmbSinif8.SelectedValue.ToString().Substring(cmbSinif8.SelectedValue.ToString().IndexOf("-") + 1, 4));
                    sinif9 = conn.DfQuery("Sinif2", Prm);
                    cmbSinif9.DataSource = sinif9;
                    cmbSinif9.SelectedValue = sinifsira9.Replace("00-0", null);
                }

            }
            if (sinifsira10 != null && sinifsira10 != "00-0")
            {
                if (cmbSinif9.SelectedValue != null)
                {
                    cmbSinif10.DisplayMember = "sAciklama";
                    cmbSinif10.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "10");
                    Prm.Add("@parentid", cmbSinif9.SelectedValue.ToString().Substring(cmbSinif9.SelectedValue.ToString().IndexOf("-") + 1, 4));
                    sinif10 = conn.DfQuery("Sinif2", Prm);
                    cmbSinif10.DataSource = sinif10;
                    cmbSinif10.SelectedValue = sinifsira10.Replace("00-0", null);
                }
            }
            if (sinifsira11 != null && sinifsira11 != "00-0")
            {
                if (cmbSinif10.SelectedValue != null)
                {
                    cmbSinif11.DisplayMember = "sAciklama";
                    cmbSinif11.ValueMember = "sSinifKodu";
                    Dictionary<string, string> Prm = new Dictionary<string, string>();
                    Prm.Add("@sira", "11");
                    Prm.Add("@parentid", cmbSinif10.SelectedValue.ToString().Substring(cmbSinif10.SelectedValue.ToString().IndexOf("-") + 1, 4));
                    sinif11 = conn.DfQuery("Sinif2", Prm);
                    cmbSinif11.DataSource = sinif11;
                    cmbSinif11.SelectedValue = sinifsira11.Replace("00-0", null);
                }
            }
            if (sinifsira12 != null && sinifsira12 != "00-0")
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
        public void RenkBedenTablo()
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
        //Attribute2
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
                if (attribute_avp.Columns.Count > 1)
                {
                    attribute_avp.Columns.Clear();
                    attribute_avp.Rows.Clear();
                }
                //attribute_avp.Columns.Add("nAttributeID");
                //attribute_avp.Columns.Add("sName");
                //attribute_avp.Columns.Add("bRequired");
                //attribute_avp.Columns.Add("bVarianter");
                //attribute_avp.Columns.Add("nValueID");
                //attribute_avp.Columns.Add("sValueName");

                string q = "select nAttributeID,sName,bRequired,bVarianter,nValueID,sValueName from tbAttribute where sModel = '" + txtStokKodu.Text + "' order by 1,5";
                SqlCommand cmd = new SqlCommand(q, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                da.Fill(attribute_avp);
                connection.Close();

                foreach (var item in myDeserializedClass.categoryAttributes)
                {
                    Dictionary<string, string> Attval = new Dictionary<string, string>();
                    if (item.allowCustom == false)
                    {
                        if (lblOzellik1.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik1.Tag = item.attribute.id;
                                lblOzellik1.Text = item.attribute.name + " *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik1.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik2.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik2.Tag = item.attribute.id;
                                lblOzellik2.Text = item.attribute.name;
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik2.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik3.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik3.Tag = item.attribute.id;
                                lblOzellik3.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik3.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik4.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik4.Tag = item.attribute.id;
                                lblOzellik4.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik4.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik5.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik5.Tag = item.attribute.id;
                                lblOzellik5.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik5.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik6.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik6.Tag = item.attribute.id;
                                lblOzellik6.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik6.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik7.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik7.Tag = item.attribute.id;
                                lblOzellik7.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik7.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik8.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik8.Tag = item.attribute.id;
                                lblOzellik8.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik8.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik9.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik9.Tag = item.attribute.id;
                                lblOzellik9.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik9.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik10.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik10.Tag = item.attribute.id;
                                lblOzellik10.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik10.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik11.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik11.Tag = item.attribute.id;
                                lblOzellik11.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik11.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik12.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik12.Tag = item.attribute.id;
                                lblOzellik12.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik12.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik13.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik13.Tag = item.attribute.id;
                                lblOzellik13.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik13.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik14.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik14.Tag = item.attribute.id;
                                lblOzellik14.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik14.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik15.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik15.Tag = item.attribute.id;
                                lblOzellik15.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik15.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik16.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik16.Tag = item.attribute.id;
                                lblOzellik16.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik16.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik17.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik17.Tag = item.attribute.id;
                                lblOzellik17.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik17.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik18.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik18.Tag = item.attribute.id;
                                lblOzellik18.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik18.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik19.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik19.Tag = item.attribute.id;
                                lblOzellik19.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik19.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik20.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik20.Tag = item.attribute.id;
                                lblOzellik20.Text = item.attribute.name + "  *";
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
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik20.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik21.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik21.Tag = item.attribute.id;
                                lblOzellik21.Text = item.attribute.name + "  *";
                                chk22.Checked = true;
                            }
                            else
                            {
                                lblOzellik21.Tag = item.attribute.id;
                                lblOzellik21.Text = item.attribute.name;
                                chk22.Checked = false;
                            }
                            cmbOzellik21.DisplayMember = "name";
                            cmbOzellik21.ValueMember = "id";
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
                            cmbOzellik21.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik21.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik22.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik22.Tag = item.attribute.id;
                                lblOzellik22.Text = item.attribute.name + "  *";
                                chk23.Checked = true;
                            }
                            else
                            {
                                lblOzellik22.Tag = item.attribute.id;
                                lblOzellik22.Text = item.attribute.name;
                                chk23.Checked = false;
                            }
                            cmbOzellik22.DisplayMember = "name";
                            cmbOzellik22.ValueMember = "id";
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
                            cmbOzellik22.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik22.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik23.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik23.Tag = item.attribute.id;
                                lblOzellik23.Text = item.attribute.name + "  *";
                                chk24.Checked = true;
                            }
                            else
                            {
                                lblOzellik23.Tag = item.attribute.id;
                                lblOzellik23.Text = item.attribute.name;
                                chk24.Checked = false;
                            }
                            cmbOzellik23.DisplayMember = "name";
                            cmbOzellik23.ValueMember = "id";
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
                            cmbOzellik23.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik23.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }
                        }
                        else if (lblOzellik24.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik24.Tag = item.attribute.id;
                                lblOzellik24.Text = item.attribute.name + "  *";
                                chk25.Checked = true;
                            }
                            else
                            {
                                lblOzellik24.Tag = item.attribute.id;
                                lblOzellik24.Text = item.attribute.name;
                                chk25.Checked = false;
                            }
                            cmbOzellik24.DisplayMember = "name";
                            cmbOzellik24.ValueMember = "id";
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
                            cmbOzellik24.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik24.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik25.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik25.Tag = item.attribute.id;
                                lblOzellik25.Text = item.attribute.name + "  *";
                                chk26.Checked = true;
                            }
                            else
                            {
                                lblOzellik25.Tag = item.attribute.id;
                                lblOzellik25.Text = item.attribute.name;
                                chk26.Checked = false;
                            }
                            cmbOzellik25.DisplayMember = "name";
                            cmbOzellik25.ValueMember = "id";
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
                            cmbOzellik25.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik25.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik26.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik26.Tag = item.attribute.id;
                                lblOzellik26.Text = item.attribute.name + "  *";
                                chk27.Checked = true;
                            }
                            else
                            {
                                lblOzellik26.Tag = item.attribute.id;
                                lblOzellik26.Text = item.attribute.name;
                                chk27.Checked = false;
                            }
                            cmbOzellik26.DisplayMember = "name";
                            cmbOzellik26.ValueMember = "id";
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
                            cmbOzellik26.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik26.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik27.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik27.Tag = item.attribute.id;
                                lblOzellik27.Text = item.attribute.name + "  *";
                                chk28.Checked = true;
                            }
                            else
                            {
                                lblOzellik27.Tag = item.attribute.id;
                                lblOzellik27.Text = item.attribute.name;
                                chk28.Checked = false;
                            }
                            cmbOzellik27.DisplayMember = "name";
                            cmbOzellik27.ValueMember = "id";
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
                            cmbOzellik27.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik27.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik28.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik28.Tag = item.attribute.id;
                                lblOzellik28.Text = item.attribute.name + "  *";
                                chk29.Checked = true;
                            }
                            else
                            {
                                lblOzellik28.Tag = item.attribute.id;
                                lblOzellik28.Text = item.attribute.name;
                                chk29.Checked = false;
                            }
                            cmbOzellik28.DisplayMember = "name";
                            cmbOzellik28.ValueMember = "id";
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
                            cmbOzellik28.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik28.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik29.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik29.Tag = item.attribute.id;
                                lblOzellik29.Text = item.attribute.name + "  *";
                                chk30.Checked = true;
                            }
                            else
                            {
                                lblOzellik29.Tag = item.attribute.id;
                                lblOzellik29.Text = item.attribute.name;
                                chk30.Checked = false;
                            }
                            cmbOzellik29.DisplayMember = "name";
                            cmbOzellik29.ValueMember = "id";
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
                            cmbOzellik29.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik29.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik30.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik30.Tag = item.attribute.id;
                                lblOzellik30.Text = item.attribute.name + "  *";
                                chk31.Checked = true;
                            }
                            else
                            {
                                lblOzellik30.Tag = item.attribute.id;
                                lblOzellik30.Text = item.attribute.name;
                                chk31.Checked = false;
                            }
                            cmbOzellik30.DisplayMember = "name";
                            cmbOzellik30.ValueMember = "id";
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
                            cmbOzellik30.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik30.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik31.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik31.Tag = item.attribute.id;
                                lblOzellik31.Text = item.attribute.name + "  *";
                                chk32.Checked = true;
                            }
                            else
                            {
                                lblOzellik31.Tag = item.attribute.id;
                                lblOzellik31.Text = item.attribute.name;
                                chk32.Checked = false;
                            }
                            cmbOzellik31.DisplayMember = "name";
                            cmbOzellik31.ValueMember = "id";
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
                            cmbOzellik31.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik31.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik32.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik32.Tag = item.attribute.id;
                                lblOzellik32.Text = item.attribute.name + "  *";
                                chk33.Checked = true;
                            }
                            else
                            {
                                lblOzellik32.Tag = item.attribute.id;
                                lblOzellik32.Text = item.attribute.name;
                                chk33.Checked = false;
                            }
                            cmbOzellik32.DisplayMember = "name";
                            cmbOzellik32.ValueMember = "id";
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
                            cmbOzellik32.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik32.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik33.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik33.Tag = item.attribute.id;
                                lblOzellik33.Text = item.attribute.name + "  *";
                                chk34.Checked = true;
                            }
                            else
                            {
                                lblOzellik33.Tag = item.attribute.id;
                                lblOzellik33.Text = item.attribute.name;
                                chk34.Checked = false;
                            }
                            cmbOzellik33.DisplayMember = "name";
                            cmbOzellik33.ValueMember = "id";
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
                            cmbOzellik33.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik33.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }
                        else if (lblOzellik34.Tag == null)
                        {
                            if (item.required == true)
                            {
                                lblOzellik34.Tag = item.attribute.id;
                                lblOzellik34.Text = item.attribute.name + "  *";
                                chk35.Checked = true;
                            }
                            else
                            {
                                lblOzellik34.Tag = item.attribute.id;
                                lblOzellik34.Text = item.attribute.name;
                                chk35.Checked = false;
                            }
                            cmbOzellik34.DisplayMember = "name";
                            cmbOzellik34.ValueMember = "id";
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
                            cmbOzellik34.DataSource = persons;
                            for (int i = 0; i < attribute_avp.Rows.Count; i++)
                            {
                                if (attribute_avp.Rows[i]["nAttributeID"].ToString() == item.attribute.id.ToString())
                                {
                                    cmbOzellik34.SelectedValue = attribute_avp.Rows[i]["nValueID"];
                                }
                            }

                        }

                        int required = 0;
                        if (item.required == true)
                        {
                            required = 1;
                        }
                        else
                        {
                            required = 0;
                        }
                        Attval.Add("@Model", txtStokKodu.Text.ToString());
                        Attval.Add("@CategoryID", CatagoryID.ToString());
                        Attval.Add("@Required", required.ToString());
                        Attval.Add("@Varianter", "0");
                        Attval.Add("@AttributeID", item.attribute.id.ToString());
                        Attval.Add("@Name", item.attribute.name.ToString());
                        Attval.Add("@ValueID", "0");
                        Attval.Add("@ValueName", "");
                        conn.DfInsert("Entegref_Create_Item_Attribute", Attval);
                    }
                    else
                    {
                        if (item.required == true)
                        {
                            lblRenk.Text = item.attribute.name;
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
                        foreach (var Value in item.attributeValues)
                        {
                            var val = new AttributeValue();
                            val.id = Value.id;
                            val.name = Value.name;
                        }

                        int required = 0;
                        if (item.required == true)
                        {
                            required = 1;
                        }
                        else
                        {
                            required = 0;
                        }

                        Attval.Add("@Model", txtStokKodu.Text.ToString());
                        Attval.Add("@CategoryID", CatagoryID.ToString());
                        Attval.Add("@Required", required.ToString());
                        Attval.Add("@Varianter", "0");
                        Attval.Add("@AttributeID", item.attribute.id.ToString());
                        Attval.Add("@Name", item.attribute.name.ToString());
                        Attval.Add("@ValueID", "0");
                        Attval.Add("@ValueName", txtRenk.Text);
                        conn.DfInsert("Entegref_Create_Item_Attribute", Attval);


                        //attribute_avp.Rows.Add(new object[] { item.attribute.id, item.attribute.name, required ,0,0, txtRenk.Text });
                    }
                    if (myDeserializedClass.categoryAttributes[0].attribute.name == "Renk")
                    {
                        Atturubite = myDeserializedClass.categoryAttributes.Count - 1;
                    }
                    else
                    {

                        Atturubite = myDeserializedClass.categoryAttributes.Count;
                    }

                }
                if (Atturubite < 33)
                {
                    lblOzellik33.Visible = false;
                    cmbOzellik33.Visible = false;
                    chk34.Visible = false;
                }
                if (Atturubite < 32)
                {
                    lblOzellik32.Visible = false;
                    cmbOzellik32.Visible = false;
                    chk33.Visible = false;
                }
                if (Atturubite < 31)
                {
                    lblOzellik31.Visible = false;
                    cmbOzellik31.Visible = false;
                    chk32.Visible = false;
                }
                if (Atturubite < 30)
                {
                    lblOzellik30.Visible = false;
                    cmbOzellik30.Visible = false;
                    chk31.Visible = false;
                }
                if (Atturubite < 29)
                {
                    lblOzellik29.Visible = false;
                    cmbOzellik29.Visible = false;
                    chk30.Visible = false;
                }
                if (Atturubite < 28)
                {
                    lblOzellik28.Visible = false;
                    cmbOzellik28.Visible = false;
                    chk29.Visible = false;
                }
                if (Atturubite < 27)
                {
                    lblOzellik27.Visible = false;
                    cmbOzellik27.Visible = false;
                    chk28.Visible = false;
                }
                if (Atturubite < 26)
                {
                    lblOzellik26.Visible = false;
                    cmbOzellik26.Visible = false;
                    chk27.Visible = false;
                }
                if (Atturubite < 25)
                {
                    lblOzellik25.Visible = false;
                    cmbOzellik25.Visible = false;
                    chk26.Visible = false;
                }
                if (Atturubite < 24)
                {
                    lblOzellik24.Visible = false;
                    cmbOzellik24.Visible = false;
                    chk25.Visible = false;
                }
                if (Atturubite < 23)
                {
                    lblOzellik23.Visible = false;
                    cmbOzellik23.Visible = false;
                    chk24.Visible = false;
                }
                if (Atturubite < 22)
                {
                    lblOzellik22.Visible = false;
                    cmbOzellik22.Visible = false;
                    chk23.Visible = false;
                }
                if (Atturubite < 21)
                {
                    lblOzellik21.Visible = false;
                    cmbOzellik21.Visible = false;
                    chk22.Visible = false;
                }
                if (Atturubite < 20)
                {
                    PnlAttr3.Visible = false;
                    lblOzellik20.Visible = false;
                    cmbOzellik20.Visible = false;
                    chk21.Visible = false;
                }
                if (Atturubite < 19)
                {
                    lblOzellik19.Visible = false;
                    cmbOzellik19.Visible = false;
                    chk20.Visible = false;
                }
                if (Atturubite < 18)
                {
                    lblOzellik18.Visible = false;
                    cmbOzellik18.Visible = false;
                    chk19.Visible = false;
                }
                if (Atturubite < 17)
                {
                    lblOzellik17.Visible = false;
                    cmbOzellik17.Visible = false;
                    chk18.Visible = false;
                }
                if (Atturubite < 16)
                {
                    lblOzellik16.Visible = false;
                    cmbOzellik16.Visible = false;
                    chk17.Visible = false;
                }
                if (Atturubite < 15)
                {
                    lblOzellik15.Visible = false;
                    cmbOzellik15.Visible = false;
                    chk16.Visible = false;
                }
                if (Atturubite < 14)
                {
                    lblOzellik14.Visible = false;
                    cmbOzellik14.Visible = false;
                    chk15.Visible = false;
                }
                if (Atturubite < 13)
                {
                    lblOzellik13.Visible = false;
                    cmbOzellik13.Visible = false;
                    chk14.Visible = false;
                }
                if (Atturubite < 12)
                {
                    lblOzellik12.Visible = false;
                    cmbOzellik12.Visible = false;
                    chk13.Visible = false;
                }
                if (Atturubite < 11)
                {
                    lblOzellik11.Visible = false;
                    cmbOzellik11.Visible = false;
                    chk12.Visible = false;
                }
                if (Atturubite < 10)
                {
                    PnlAttr2.Visible = false;
                    PnlAttr3.Visible = false;
                    lblOzellik10.Visible = false;
                    cmbOzellik10.Visible = false;
                    chk11.Visible = false;
                }
                if (Atturubite < 9)
                {
                    lblOzellik9.Visible = false;
                    cmbOzellik9.Visible = false;
                    chk10.Visible = false;
                }
                if (Atturubite < 8)
                {
                    lblOzellik8.Visible = false;
                    cmbOzellik8.Visible = false;
                    chk9.Visible = false;
                }
                if (Atturubite < 7)
                {
                    lblOzellik7.Visible = false;
                    cmbOzellik7.Visible = false;
                    chk8.Visible = false;
                }
                if (Atturubite < 6)
                {
                    lblOzellik6.Visible = false;
                    cmbOzellik6.Visible = false;
                    chk7.Visible = false;
                }
                if (Atturubite < 5)
                {
                    lblOzellik5.Visible = false;
                    cmbOzellik5.Visible = false;
                    chk6.Visible = false;
                }
                if (Atturubite < 4)
                {
                    lblOzellik4.Visible = false;
                    cmbOzellik4.Visible = false;
                    chk5.Visible = false;
                }
                if (Atturubite < 3)
                {
                    lblOzellik3.Visible = false;
                    cmbOzellik3.Visible = false;
                    chk3.Visible = false;
                }
                if (Atturubite < 2)
                {
                    lblOzellik2.Visible = false;
                    cmbOzellik2.Visible = false;
                    chk3.Visible = false;
                }
                if (Atturubite < 1)
                {
                    lblOzellik1.Visible = false;
                    cmbOzellik1.Visible = false;
                    chk1.Visible = false;
                }
            }
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
                            lbl.Text = lbl.Text + "*  *";
                        }
                        PnlAttr1.Controls.Add(lbl);
                        PnlAttr1.Controls.Add(cmb1);
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
                            label1.Text = label1.Text + "*  *";
                        }
                        PnlAttr1.Controls.Add(label1);
                        PnlAttr1.Controls.Add(Renk);
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

            bool dosyadan = false;

            Dictionary<string, string> Rsm = new Dictionary<string, string>();
            Rsm.Add("@sModel", txtStokKodu.Text);
            var resimler = conn.DfQuery("Entegref_Resim", Rsm);

            for (int i = 0; i < resimler.Rows.Count; i++)
            {
                if (resimler.Rows[i]["sLocation"].ToString() != "WEB")
                {
                    dosyadan = true;
                }
                else
                {
                    resim.Rows.Add(new object[] { resimler.Rows[i]["sResimAdi"].ToString(), resimler.Rows[i]["sLocation"].ToString() });
                }

                listBox1.DataSource = resim;
                label20.Text = "Toplam Resim : " + listBox1.Items.Count.ToString();
            }
            if (dosyadan == true)
            {


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
                if (listBox1.SelectedValue.ToString() != "WEB")
                {
                    var lst = listBox1.Items[index].ToString();
                    string file = @"..\..\Pictures\" + txtStokKodu.Text.ToString();
                    string dosya = listBox1.SelectedValue.ToString();
                    int satirno = listBox1.SelectedIndex;
                    pictureBox1.Image = Image.FromFile(dosya);
                }
                else
                {
                    pictureBox1.Load(listBox1.GetItemText(listBox1.SelectedItem));
                }
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
            frmStokBul stokBul = new frmStokBul(1);
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


        private void cmbSinif7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif7.SelectedValue != null)
            {
                cmbSinif8.DisplayMember = "sAciklama";
                cmbSinif8.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "8");
                Prm.Add("@parentid", cmbSinif7.SelectedValue.ToString().Substring(cmbSinif7.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif8 = conn.DfQuery("Sinif2", Prm);
                if (sinif8.Rows.Count > 1)
                {
                    cmbSinif8.DataSource = sinif8;
                    cmbSinif8.Enabled = true;
                }
                else
                {
                    sinif8.Clear();
                    cmbSinif8.Enabled = false;
                    cmbSinif8.DataSource = null;
                }

            }
            else
            {
                sinif8.Clear();
                cmbSinif8.Enabled = false;
                cmbSinif8.DataSource = null;
                sinif9.Clear();
                cmbSinif9.Enabled = false;
                cmbSinif9.DataSource = null;
                sinif10.Clear();
                cmbSinif10.Enabled = false;
                cmbSinif10.DataSource = null;
                sinif11.Clear();
                cmbSinif11.Enabled = false;
                cmbSinif11.DataSource = null;
                sinif12.Clear();
                cmbSinif12.Enabled = false;
                cmbSinif12.DataSource = null;
            }

        }

        private void cmbSinif8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif8.SelectedValue != null)
            {
                cmbSinif9.DisplayMember = "sAciklama";
                cmbSinif9.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "9");
                Prm.Add("@parentid", cmbSinif8.SelectedValue.ToString().Substring(cmbSinif8.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif9 = conn.DfQuery("Sinif2", Prm);
                if (sinif9.Rows.Count > 1)
                {
                    cmbSinif9.DataSource = sinif9;
                    cmbSinif9.Enabled = true;
                }
                else
                {
                    sinif9.Clear();
                    cmbSinif9.Enabled = false;
                    cmbSinif9.DataSource = null;
                }

            }
            else
            {
                sinif9.Clear();
                cmbSinif9.Enabled = false;
                cmbSinif9.DataSource = null;
                sinif10.Clear();
                cmbSinif10.Enabled = false;
                cmbSinif10.DataSource = null;
                sinif11.Clear();
                cmbSinif11.Enabled = false;
                cmbSinif11.DataSource = null;
                sinif12.Clear();
                cmbSinif12.Enabled = false;
                cmbSinif12.DataSource = null;
            }
        }

        private void cmbSinif9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif9.SelectedValue != null)
            {
                cmbSinif10.DisplayMember = "sAciklama";
                cmbSinif10.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "10");
                Prm.Add("@parentid", cmbSinif9.SelectedValue.ToString().Substring(cmbSinif9.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif10 = conn.DfQuery("Sinif2", Prm);
                if (sinif10.Rows.Count > 1)
                {
                    cmbSinif10.DataSource = sinif10;
                    cmbSinif10.Enabled = true;
                }
                else
                {
                    sinif10.Clear();
                    cmbSinif10.Enabled = false;
                    cmbSinif10.DataSource = null;
                }

            }
            else
            {
                sinif10.Clear();
                cmbSinif10.Enabled = false;
                cmbSinif10.DataSource = null;
                sinif11.Clear();
                cmbSinif11.Enabled = false;
                cmbSinif11.DataSource = null;
                sinif12.Clear();
                cmbSinif12.Enabled = false;
                cmbSinif12.DataSource = null;
            }

        }

        private void cmbSinif10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif11.SelectedValue != null)
            {
                cmbSinif11.DisplayMember = "sAciklama";
                cmbSinif11.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "11");
                Prm.Add("@parentid", cmbSinif10.SelectedValue.ToString().Substring(cmbSinif10.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif11 = conn.DfQuery("Sinif2", Prm);
                if (sinif11.Rows.Count > 1)
                {
                    cmbSinif11.DataSource = sinif11;
                    cmbSinif11.Enabled = true;
                }
                else
                {
                    sinif11.Clear();
                    cmbSinif11.Enabled = false;
                    cmbSinif11.DataSource = null;
                }

            }
            else
            {
                sinif11.Clear();
                cmbSinif11.Enabled = false;
                cmbSinif11.DataSource = null;
                sinif12.Clear();
                cmbSinif12.Enabled = false;
                cmbSinif12.DataSource = null;
            }

        }

        private void cmbSinif11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif11.SelectedValue != null)
            {
                cmbSinif12.DisplayMember = "sAciklama";
                cmbSinif12.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "12");
                Prm.Add("@parentid", cmbSinif11.SelectedValue.ToString().Substring(cmbSinif11.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif12 = conn.DfQuery("Sinif2", Prm);
                if (sinif12.Rows.Count > 1)
                {
                    cmbSinif12.DataSource = sinif8;
                    cmbSinif12.Enabled = true;
                }
                else
                {
                    sinif12.Clear();
                    cmbSinif12.Enabled = false;
                    cmbSinif12.DataSource = null;
                }

            }
            else
            {
                sinif12.Clear();
                cmbSinif12.Enabled = false;
                cmbSinif12.DataSource = null;
            }

        }
        renkbeden rnb;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmRenk frm = new frmRenk(KavalaTipi, BedenTipi);
            frm.ShowDialog();
            RenkBedenTablo();

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            new Root();
            label20.Text = "Toplam Resim :";
            txtRenk.Text = null;
            lblRenk.Text = "Renk";
            dataGridView1.DataSource = null;
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
            txtsAciklama.Text = null;
            bunifuCustomTextbox2.Text = null;
            txtMarka.Text = null;
            lblFiyattipi.Visible = false;
            nStokID = null;
            ultraTabControl1.VisibleTabs[1].Visible = false;
            ultraTabControl1.VisibleTabs[2].Visible = false;
            ultraTabControl1.VisibleTabs[3].Visible = false;
            ultraTabControl1.VisibleTabs[4].Visible = false;
            ultraTabControl1.VisibleTabs[5].Visible = false;
            ultraTabControl1.VisibleTabs[6].Visible = false;
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
            string CatogryID = "";
            if (nStokID == null)
            {
                if (renkolanlar.Rows.Count > 0)
                {
                    for (int i = 0; i < renkolanlar.Rows.Count; i++)
                    {
                        Dictionary<string, string> Stok = new Dictionary<string, string>();
                        Stok.Add("@sKodu", txtStokKodu.Text);
                        Stok.Add("@sAciklama", txtsAciklama.Text);
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
                            CatogryID = cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        if (cmbSinif4.SelectedValue == null)
                        {
                            Stok.Add("@sSinifKodu23", "");
                        }
                        else
                        {
                            Stok.Add("@sSinifKodu23", cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        if (cmbSinif5.SelectedValue == null)
                        {
                            Stok.Add("@sSinifKodu24", "");
                        }
                        else
                        {
                            Stok.Add("@sSinifKodu24", cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        if (cmbSinif6.SelectedValue == null)
                        {
                            Stok.Add("@sSinifKodu25", "");
                        }
                        else
                        {
                            Stok.Add("@sSinifKodu25", cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1);
                        }

                        Stok.Add("@ReturnDesc", "");
                        var newstk = conn.DfInsertBack("Entegref_Create_Item", Stok);
                        if (nStokID != null)
                        {
                            nStokID = newstk.ToString();
                        }
                        else
                        {
                            nStokID = newstk.ToString();
                        }

                        for (int ii = 0; ii < attribute_avp.Rows.Count; ii++)
                        {
                            Dictionary<string, string> Attr = new Dictionary<string, string>();
                            Attr.Add("@Model", txtStokKodu.Text.ToString());
                            Attr.Add("@CategoryID", CatogryID.ToString());
                            Attr.Add("@Required", attribute_avp.Rows[ii]["bRequired"].ToString());
                            Attr.Add("@Varianter", attribute_avp.Rows[ii]["bVarianter"].ToString());
                            Attr.Add("@AttributeID", attribute_avp.Rows[ii]["nAttributeID"].ToString());
                            Attr.Add("@Name", attribute_avp.Rows[ii]["sName"].ToString());
                            Attr.Add("@ValueID", attribute_avp.Rows[ii]["nValueID"].ToString());
                            Attr.Add("@ValueName", attribute_avp.Rows[ii]["sValueName"].ToString());
                            conn.DfInsert("Entegref_Create_Item_Attribute", Attr);
                        }

                    }
                }
                else
                {
                    Dictionary<string, string> Stok1 = new Dictionary<string, string>();
                    Stok1.Add("@sKodu", txtStokKodu.Text);
                    Stok1.Add("@sAciklama", txtsAciklama.Text);
                    Stok1.Add("@sKisaAdi", cmbMarka.SelectedValue.ToString());
                    Stok1.Add("@nStokTipi", nStokTipi);
                    Stok1.Add("@sBedenTipi", "");
                    Stok1.Add("@sKavalaTipi", "");
                    Stok1.Add("@sRenk", "");
                    Stok1.Add("@sBeden", "");
                    Stok1.Add("@sKavala", "");
                    Stok1.Add("@sBirimCinsi1", cmbBirim1.SelectedValue.ToString());
                    Stok1.Add("@sBirimCinsi2", cmbBirim2.SelectedValue.ToString());
                    if (bunifuCustomTextbox5.Text == "")
                    {
                        Stok1.Add("@nIskontoYuzdesi", "0");
                    }
                    else
                    {
                        Stok1.Add("@nIskontoYuzdesi", bunifuCustomTextbox5.Text);
                    }
                    Stok1.Add("@sKdvTipi", cmbKDV.SelectedValue.ToString());

                    Stok1.Add("@nTeminSuresi", "0");
                    Stok1.Add("@lAsgariMiktar", "0");
                    Stok1.Add("@lAzamiMiktar", "0");
                    Stok1.Add("@sOzelNot", bunifuCustomTextbox2.Text);
                    Stok1.Add("@nFiyatlandirma", nFiyatlandirma);
                    Stok1.Add("@sModel", txtStokKodu.Text);
                    Stok1.Add("@sKullaniciAdi", frmLogin.username);
                    if (checkBox2.Checked == true)
                    {
                        Stok1.Add("@bEksiyeDusulebilirmi", "1");
                        Stok1.Add("@bEksideUyarsinmi", "1");
                    }
                    else
                    {
                        Stok1.Add("@bEksiyeDusulebilirmi", "0");
                        Stok1.Add("@bEksideUyarsinmi", "0");
                    }
                    if (checkBox1.Checked == true)
                    {
                        Stok1.Add("@bOTVVar", "1");
                        Stok1.Add("@sOTVTipi", cmbOTV.SelectedValue.ToString());
                    }
                    else
                    {
                        Stok1.Add("@bOTVVar", "0");
                        Stok1.Add("@sOTVTipi", "");
                    }
                    Stok1.Add("@sUzunNote", miniHTMLTextBox1.Text);
                    Stok1.Add("@sSinifKodu20", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-") + 1));
                    Stok1.Add("@sSinifKodu21", cmbSinif2.SelectedValue.ToString().Substring(cmbSinif2.SelectedValue.ToString().IndexOf("-") + 1));
                    if (cmbSinif3.SelectedValue.ToString() == "00-0")
                    {
                        Stok1.Add("@sSinifKodu22", "");
                    }
                    else
                    {
                        Stok1.Add("@sSinifKodu22", cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1));
                        CatogryID = cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1);
                    }
                    if (cmbSinif4.SelectedValue == null)
                    {
                        Stok1.Add("@sSinifKodu23", "");
                    }
                    else
                    {
                        Stok1.Add("@sSinifKodu23", cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1));
                        CatogryID = cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1);
                    }
                    if (cmbSinif5.SelectedValue == null)
                    {
                        Stok1.Add("@sSinifKodu24", "");
                    }
                    else
                    {
                        Stok1.Add("@sSinifKodu24", cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1));
                        CatogryID = cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1);
                    }
                    if (cmbSinif6.SelectedValue == null)
                    {
                        Stok1.Add("@sSinifKodu25", "");
                    }
                    else
                    {
                        Stok1.Add("@sSinifKodu25", cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1));
                        CatogryID = cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1);
                    }
                    Stok1.Add("@ReturnDesc", "");
                    var newstk = conn.DfInsertBack("Entegref_Create_Item", Stok1);
                    if (nStokID != null)
                    {
                        nStokID = newstk.ToString();
                    }
                    else
                    {
                        nStokID = newstk.ToString();
                    }
                    for (int ii = 0; ii < attribute_avp.Rows.Count; ii++)
                    {
                        Dictionary<string, string> Attr = new Dictionary<string, string>();
                        Attr.Add("@Model", txtStokKodu.Text.ToString());
                        Attr.Add("@CategoryID", CatogryID.ToString());
                        Attr.Add("@Required", attribute_avp.Rows[ii]["bRequired"].ToString());
                        Attr.Add("@Varianter", attribute_avp.Rows[ii]["bVarianter"].ToString());
                        Attr.Add("@AttributeID", attribute_avp.Rows[ii]["nAttributeID"].ToString());
                        Attr.Add("@Name", attribute_avp.Rows[ii]["sName"].ToString());
                        Attr.Add("@ValueID", attribute_avp.Rows[ii]["nValueID"].ToString());
                        Attr.Add("@ValueName", attribute_avp.Rows[ii]["sValueName"].ToString());
                        conn.DfInsert("Entegref_Create_Item_Attribute", Attr);
                    }
                }
            }
            else
            {
                if (renkolanlar.Rows.Count > 0)
                {
                    for (int i = 0; i < renkolanlar.Rows.Count; i++)
                    {
                        Dictionary<string, string> Stok1 = new Dictionary<string, string>();
                        Stok1.Add("@sKodu", txtStokKodu.Text.Replace(" ", ""));
                        Stok1.Add("@sAciklama", txtsAciklama.Text);
                        Stok1.Add("@sKisaAdi", cmbMarka.SelectedValue.ToString() + "-" + txtMarkaAra.Text);
                        Stok1.Add("@nStokTipi", nStokTipi);
                        Stok1.Add("@sBedenTipi", renkolanlar.Rows[i]["sBedenTipi"].ToString());
                        Stok1.Add("@sKavalaTipi", renkolanlar.Rows[i]["sKavalaTipi"].ToString());
                        Stok1.Add("@sRenk", renkolanlar.Rows[i]["sRenk"].ToString());
                        Stok1.Add("@sBeden", renkolanlar.Rows[i]["sBeden"].ToString());
                        Stok1.Add("@sKavala", renkolanlar.Rows[i]["sKavala"].ToString());
                        Stok1.Add("@sBirimCinsi1", cmbBirim1.SelectedValue.ToString());
                        Stok1.Add("@sBirimCinsi2", cmbBirim2.SelectedValue.ToString());
                        if (bunifuCustomTextbox5.Text == "")
                        {
                            Stok1.Add("@nIskontoYuzdesi", "0");
                        }
                        else
                        {
                            Stok1.Add("@nIskontoYuzdesi", bunifuCustomTextbox5.Text);
                        }
                        Stok1.Add("@sKdvTipi", cmbKDV.SelectedValue.ToString());

                        Stok1.Add("@nTeminSuresi", bunifuCustomTextbox4.Text);
                        Stok1.Add("@lAsgariMiktar", bunifuCustomTextbox5.Text);
                        Stok1.Add("@lAzamiMiktar", bunifuCustomTextbox6.Text);
                        Stok1.Add("@sOzelNot", bunifuCustomTextbox2.Text);
                        Stok1.Add("@nFiyatlandirma", nFiyatlandirma);
                        Stok1.Add("@sModel", txtStokKodu.Text.Replace(" ", ""));
                        Stok1.Add("@sKullaniciAdi", frmLogin.username);
                        if (checkBox2.Checked == true)
                        {
                            Stok1.Add("@bEksiyeDusulebilirmi", "1");
                            Stok1.Add("@bEksideUyarsinmi", "1");
                        }
                        else
                        {
                            Stok1.Add("@bEksiyeDusulebilirmi", "0");
                            Stok1.Add("@bEksideUyarsinmi", "0");
                        }
                        if (checkBox1.Checked == true)
                        {
                            Stok1.Add("@bOTVVar", "1");
                            Stok1.Add("@sOTVTipi", cmbOTV.SelectedValue.ToString());
                        }
                        else
                        {
                            Stok1.Add("@bOTVVar", "0");
                            Stok1.Add("@sOTVTipi", "");
                        }
                        Stok1.Add("@sUzunNote", miniHTMLTextBox1.Text);
                        Stok1.Add("@sSinifKodu20", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-") + 1));
                        Stok1.Add("@sSinifKodu21", cmbSinif2.SelectedValue.ToString().Substring(cmbSinif2.SelectedValue.ToString().IndexOf("-") + 1));
                        if (cmbSinif3.SelectedValue.ToString() == "00-0")
                        {
                            Stok1.Add("@sSinifKodu22", "");
                        }
                        else
                        {
                            Stok1.Add("@sSinifKodu22", cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif3.SelectedValue.ToString().Substring(cmbSinif3.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        if (cmbSinif4.SelectedValue == null)
                        {
                            Stok1.Add("@sSinifKodu23", "");
                        }
                        else
                        {
                            Stok1.Add("@sSinifKodu23", cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif4.SelectedValue.ToString().Substring(cmbSinif4.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        if (cmbSinif5.SelectedValue == null)
                        {
                            Stok1.Add("@sSinifKodu24", "");
                        }
                        else
                        {
                            Stok1.Add("@sSinifKodu24", cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif5.SelectedValue.ToString().Substring(cmbSinif5.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        if (cmbSinif6.SelectedValue == null)
                        {
                            Stok1.Add("@sSinifKodu25", "");
                        }
                        else
                        {
                            Stok1.Add("@sSinifKodu25", cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1));
                            CatogryID = cmbSinif6.SelectedValue.ToString().Substring(cmbSinif6.SelectedValue.ToString().IndexOf("-") + 1);
                        }
                        conn.DfQuery("Entegref_Create_Item_Update", Stok1);
                    }
                }

                for (int ii = 0; ii < attribute_avp.Rows.Count; ii++)
                {
                    Dictionary<string, string> Attr = new Dictionary<string, string>();
                    Attr.Add("@Model", txtStokKodu.Text.ToString());
                    Attr.Add("@CategoryID", CatogryID.ToString());
                    Attr.Add("@Required", attribute_avp.Rows[ii]["bRequired"].ToString());
                    Attr.Add("@Varianter", attribute_avp.Rows[ii]["bVarianter"].ToString());
                    Attr.Add("@AttributeID", attribute_avp.Rows[ii]["nAttributeID"].ToString());
                    Attr.Add("@Name", attribute_avp.Rows[ii]["sName"].ToString());
                    Attr.Add("@ValueID", attribute_avp.Rows[ii]["nValueID"].ToString());
                    Attr.Add("@ValueName", attribute_avp.Rows[ii]["sValueName"].ToString());
                    conn.DfInsert("Entegref_Create_Item_Attribute", Attr);
                }
            }
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

        private void cmbOzellik1_SelectedValueChanged(object sender, EventArgs e)
        {

            //int bRequired = 0;
            //if (chk1.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik1.SelectedValue == null || cmbOzellik1.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik1.Tag, lblOzellik1.Text, bRequired, 0, cmbOzellik1.SelectedValue, cmbOzellik1.SelectedText });
            //}
            //else
            //{
            //attribute_avp.Rows[1][0] = lblOzellik1.Tag;
            //attribute_avp.Rows[1][1] = lblOzellik1.Text;
            if (cmbOzellik1.SelectedValue != null)
            {
                attribute_avp.Rows[1][4] = cmbOzellik1.SelectedValue.ToString();
                attribute_avp.Rows[1][5] = cmbOzellik1.Text;
            }
            //}
        }
        private void cmbOzellik2_SelectedValueChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk2.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik2.SelectedValue == null || cmbOzellik2.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik2.Tag, lblOzellik2.Text, bRequired, 0, cmbOzellik2.SelectedValue, cmbOzellik2.SelectedText });
            //}
            //else
            //{
                if (cmbOzellik2.SelectedValue != null)
                {
                    //attribute_avp.Rows[2][0] = lblOzellik2.Tag;
                    //attribute_avp.Rows[2][2] = lblOzellik2.Text;
                    attribute_avp.Rows[2][4] = cmbOzellik2.SelectedValue;
                    attribute_avp.Rows[2][5] = cmbOzellik2.Text;
                }
            //}
        }
        private void cmbOzellik3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk3.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik3.SelectedValue == null || cmbOzellik3.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik3.Tag, lblOzellik3.Text, bRequired, 0, cmbOzellik3.SelectedValue, cmbOzellik3.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[3][0] = lblOzellik3.Tag;
            //    attribute_avp.Rows[3][1] = lblOzellik3.Text;
            if (cmbOzellik3.SelectedValue != null)
            {
                attribute_avp.Rows[3][4] = cmbOzellik3.SelectedValue;
                attribute_avp.Rows[3][5] = cmbOzellik3.Text;
            }
            //}
        }
        private void cmbOzellik4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk4.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik4.SelectedValue == null || cmbOzellik4.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik4.Tag, lblOzellik4.Text, bRequired, 0, cmbOzellik4.SelectedValue, cmbOzellik4.SelectedText });
            //}
            //else
            //{

            //    attribute_avp.Rows[4][0] = lblOzellik4.Tag;
            //    attribute_avp.Rows[4][1] = lblOzellik4.Text;
            if (cmbOzellik4.SelectedValue != null)
            {
                attribute_avp.Rows[4][4] = cmbOzellik4.SelectedValue;
                attribute_avp.Rows[4][5] = cmbOzellik4.Text;
            }
        }
        private void cmbOzellik5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk5.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik5.SelectedValue == null || cmbOzellik5.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik5.Tag, lblOzellik5.Text, bRequired, 0, cmbOzellik5.SelectedValue, cmbOzellik5.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[5][0] = lblOzellik5.Tag;
            //    attribute_avp.Rows[5][1] = lblOzellik5.Text;
            if (cmbOzellik5.SelectedValue != null)
            {
                attribute_avp.Rows[5][5] = cmbOzellik5.SelectedValue;
                attribute_avp.Rows[5][5] = cmbOzellik5.Text;
            }
        }
        private void cmbOzellik6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk6.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik6.SelectedValue == null || cmbOzellik6.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik6.Tag, lblOzellik6.Text, bRequired, 0, cmbOzellik6.SelectedValue, cmbOzellik6.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[6][0] = lblOzellik6.Tag;
            //    attribute_avp.Rows[6][1] = lblOzellik6.Text;
            if (cmbOzellik6.SelectedValue != null)
            {
                if (attribute_avp.Columns.Count>6)
                {
                    attribute_avp.Rows[6][4] = cmbOzellik6.SelectedValue;
                    attribute_avp.Rows[6][6] = cmbOzellik6.Text;
                }
            }
        }
        private void cmbOzellik7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk7.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik7.SelectedValue == null || cmbOzellik7.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik7.Tag, lblOzellik7.Text, bRequired, 0, cmbOzellik7.SelectedValue, cmbOzellik7.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[7][0] = lblOzellik7.Tag;
            //    attribute_avp.Rows[7][1] = lblOzellik7.Text;
            if (cmbOzellik7.SelectedValue != null)
            {
                attribute_avp.Rows[7][4] = cmbOzellik7.SelectedValue;
                attribute_avp.Rows[7][5] = cmbOzellik7.Text;
            }
        }
        private void cmbOzellik8_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk8.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik8.SelectedValue == null || cmbOzellik8.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik8.Tag, lblOzellik8.Text, bRequired, 0, cmbOzellik8.SelectedValue, cmbOzellik8.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[8][0] = lblOzellik8.Tag;
            //    attribute_avp.Rows[8][1] = lblOzellik8.Text;
            if (cmbOzellik8.SelectedValue != null)
            {
                attribute_avp.Rows[8][4] = cmbOzellik8.SelectedValue;
                attribute_avp.Rows[8][5] = cmbOzellik8.Text;
            }
        }
        private void cmbOzellik9_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk9.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik9.SelectedValue == null || cmbOzellik9.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik9.Tag, lblOzellik9.Text, bRequired, 0, cmbOzellik9.SelectedValue, cmbOzellik9.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[9][0] = lblOzellik9.Tag;
            //    attribute_avp.Rows[9][1] = lblOzellik9.Text;
            if (cmbOzellik9.SelectedValue != null)
            {
                attribute_avp.Rows[9][4] = cmbOzellik9.SelectedValue;
                attribute_avp.Rows[9][5] = cmbOzellik9.Text;
            }
        }
        private void cmbOzellik10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk10.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik10.SelectedValue == null || cmbOzellik10.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik10.Tag, lblOzellik10.Text, bRequired, 0, cmbOzellik10.SelectedValue, cmbOzellik10.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[10][0] = lblOzellik10.Tag;
            //    attribute_avp.Rows[10][1] = lblOzellik10.Text;
            if (cmbOzellik10.SelectedValue != null)
            {
                attribute_avp.Rows[10][4] = cmbOzellik10.SelectedValue;
                attribute_avp.Rows[10][5] = cmbOzellik10.Text;
            }
        }
        private void cmbOzellik11_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk11.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik11.SelectedValue == null || cmbOzellik11.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik11.Tag, lblOzellik11.Text, bRequired, 0, cmbOzellik11.SelectedValue, cmbOzellik11.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[11][0] = lblOzellik11.Tag;
            //    attribute_avp.Rows[11][1] = lblOzellik11.Text;
            if (cmbOzellik11.SelectedValue != null)
            {
                attribute_avp.Rows[11][4] = cmbOzellik11.SelectedValue;
                attribute_avp.Rows[11][5] = cmbOzellik11.Text;
            }
        }
        private void cmbOzellik12_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk12.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik12.SelectedValue == null || cmbOzellik12.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik12.Tag, lblOzellik12.Text, bRequired, 0, cmbOzellik12.SelectedValue, cmbOzellik12.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[12][0] = lblOzellik12.Tag;
            //    attribute_avp.Rows[12][1] = lblOzellik12.Text;
            if (cmbOzellik12.SelectedValue != null)
            {
                attribute_avp.Rows[12][4] = cmbOzellik12.SelectedValue;
                attribute_avp.Rows[12][5] = cmbOzellik12.Text;
            }
        }
        private void cmbOzellik13_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk13.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik13.SelectedValue == null || cmbOzellik13.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik13.Tag, lblOzellik13.Text, bRequired, 0, cmbOzellik13.SelectedValue, cmbOzellik13.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[11][0] = lblOzellik13.Tag;
            //    attribute_avp.Rows[11][1] = lblOzellik13.Text;
            if (cmbOzellik13.SelectedValue != null)
            {
                attribute_avp.Rows[13][4] = cmbOzellik13.SelectedValue;
                attribute_avp.Rows[13][5] = cmbOzellik13.Text;
            }
        }
        private void cmbOzellik14_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk14.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik14.SelectedValue == null || cmbOzellik14.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik14.Tag, lblOzellik14.Text, bRequired, 0, cmbOzellik14.SelectedValue, cmbOzellik14.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[14][0] = lblOzellik14.Tag;
            //    attribute_avp.Rows[14][1] = lblOzellik14.Text;
            if (cmbOzellik14.SelectedValue != null)
            {
                attribute_avp.Rows[14][4] = cmbOzellik14.SelectedValue;
                attribute_avp.Rows[14][5] = cmbOzellik14.Text;
            }
        }
        private void cmbOzellik15_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk15.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik15.SelectedValue == null || cmbOzellik15.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik15.Tag, lblOzellik15.Text, bRequired, 0, cmbOzellik15.SelectedValue, cmbOzellik15.SelectedText });
            //}
            //else
            //{
            //attribute_avp.Rows[15][0] = lblOzellik15.Tag;
            //attribute_avp.Rows[15][1] = lblOzellik15.Text;
            if (cmbOzellik15.SelectedValue != null)
            {
                attribute_avp.Rows[15][4] = cmbOzellik15.SelectedValue;
                attribute_avp.Rows[15][5] = cmbOzellik15.Text;
            }
        }
        private void cmbOzellik16_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk16.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik16.SelectedValue == null || cmbOzellik16.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik16.Tag, lblOzellik16.Text, bRequired, 0, cmbOzellik16.SelectedValue, cmbOzellik16.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[16][0] = lblOzellik16.Tag;
            //    attribute_avp.Rows[16][1] = lblOzellik16.Text;
            if (cmbOzellik16.SelectedValue != null)
            {
                attribute_avp.Rows[16][4] = cmbOzellik16.SelectedValue;
                attribute_avp.Rows[16][5] = cmbOzellik16.Text;
            }
        }
        private void cmbOzellik17_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk17.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik17.SelectedValue == null || cmbOzellik17.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik17.Tag, lblOzellik17.Text, bRequired, 0, cmbOzellik17.SelectedValue, cmbOzellik17.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[17][0] = lblOzellik17.Tag;
            //    attribute_avp.Rows[17][1] = lblOzellik17.Text;
            if (cmbOzellik17.SelectedValue != null)
            {
                attribute_avp.Rows[17][4] = cmbOzellik17.SelectedValue;
                attribute_avp.Rows[17][5] = cmbOzellik17.Text;
            }
        }
        private void cmbOzellik18_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk18.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik18.SelectedValue == null || cmbOzellik18.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik18.Tag, lblOzellik18.Text, bRequired, 0, cmbOzellik18.SelectedValue, cmbOzellik18.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[18][0] = lblOzellik18.Tag;
            //    attribute_avp.Rows[18][1] = lblOzellik18.Text;
            if (cmbOzellik18.SelectedValue != null)
            {
                attribute_avp.Rows[18][4] = cmbOzellik18.SelectedValue;
                attribute_avp.Rows[18][5] = cmbOzellik18.Text;
            }
        }
        private void cmbOzellik19_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk19.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik19.SelectedValue == null || cmbOzellik19.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik19.Tag, lblOzellik19.Text, bRequired, 0, cmbOzellik19.SelectedValue, cmbOzellik19.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[19][0] = lblOzellik19.Tag;
            //    attribute_avp.Rows[19][1] = lblOzellik19.Text;
            if (cmbOzellik19.SelectedValue != null)
            {
                attribute_avp.Rows[19][4] = cmbOzellik19.SelectedValue;
                attribute_avp.Rows[19][5] = cmbOzellik19.Text;
            }
        }
        private void cmbOzellik20_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int bRequired = 0;
            //if (chk20.Checked == true)
            //{
            //    bRequired = 1;
            //}
            //else
            //{
            //    bRequired = 0;
            //}
            //if (cmbOzellik20.SelectedValue == null || cmbOzellik20.SelectedValue.ToString() == "0")
            //{
            //    attribute_avp.Rows.Add(new object[] { lblOzellik20.Tag, lblOzellik20.Text, bRequired, 0, cmbOzellik20.SelectedValue, cmbOzellik20.SelectedText });
            //}
            //else
            //{
            //    attribute_avp.Rows[20][0] = lblOzellik20.Tag;
            //    attribute_avp.Rows[20][1] = lblOzellik20.Text;
            if (cmbOzellik20.SelectedValue != null)
            {
                attribute_avp.Rows[20][4] = cmbOzellik20.SelectedValue;
                attribute_avp.Rows[20][5] = cmbOzellik20.Text;
            }
        }

        private void ultraButton3_Click_1(object sender, EventArgs e)
        {
            sinifsira1 = null;
            sinifsira2 = null;
            sinifsira3 = null;
            sinifsira4 = null;
            sinifsira5 = null;
            sinifsira6 = null;
            Renk = false;
            frmCicekSepeti_Sinif sinifi = new frmCicekSepeti_Sinif();
            sinifi.TopLevel = true;
            sinifi.ShowDialog();
        }
    }
}
