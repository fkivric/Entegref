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

namespace Entegref
{
    public partial class frmStokAc : XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);


        string nStokID;

        DataTable kdv = new DataTable();
        DataTable birim1 = new DataTable();
        DataTable birim2 = new DataTable();
        DataTable Otv = new DataTable();


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
            string query2 = "select sKdvTipi,sKdvTipi + convert(char(5),nKdvOrani) as nKdvOrani from tbKdv";
            string query3 = "select sOTVTipi,sOTVTipi+' ' + convert(char(6),nOTVOrani) as nOTVOrani from tbOTV";
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
        private void button1_Click(object sender, EventArgs e)
        {
            frmBarkod barkod = new frmBarkod(txtStokKodu.Text);
            barkod.Show();

        }


        DataTable renkolanlar = new DataTable();



        private void ultraButton3_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string Queryable = "select * from tbstok s inner join tbStokSinifi f on f.nStokID = s.nStokID where sModel = '"+ txtStokKodu.Text + "'";
            SqlCommand cmd = new SqlCommand(Queryable, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            connection.Close();
            renkolanlar.Clear();
            renkolanlar.Columns.Clear();
            renkolanlar.Columns.Add("sBedenTipi");
            renkolanlar.Columns.Add("sKavalaTipi");
            renkolanlar.Columns.Add("sRenk");
            renkolanlar.Columns.Add("sBeden");
            renkolanlar.Columns.Add("sKavala");
            DataRow _ravi = renkolanlar.NewRow();

            if (dt.Rows.Count > 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (nStokID != null)
                    {
                        nStokID = nStokID + "-" + dt.Rows[i]["nStokID"].ToString();
                    }
                    else
                    {
                        nStokID = dt.Rows[i]["nStokID"].ToString();
                    }
                    renkolanlar.Rows.Add(new object[] { dt.Rows[i]["sBedenTipi"].ToString(), dt.Rows[i]["sKavalaTipi"].ToString(), dt.Rows[i]["sRenk"].ToString(), dt.Rows[i]["sBeden"].ToString(), dt.Rows[i]["sKavala"].ToString() });
                }

                KavalaTipi = dt.Rows[0]["sKavalaTipi"].ToString();
                BedenTipi = dt.Rows[0]["sBedenTipi"].ToString();
                bunifuCustomTextbox1.Text = dt.Rows[0]["sAciklama"].ToString();
                cmbBirim1.Text = dt.Rows[0]["sBirimCinsi1"].ToString();
                cmbBirim2.Text = dt.Rows[0]["sBirimCinsi2"].ToString();
                cmbKDV.Text = dt.Rows[0]["sKdvTipi"].ToString();
                bunifuCustomTextbox1.Text = dt.Rows[0]["sAciklama"].ToString();
                sinifsira1 = dt.Rows[0]["sSinifKodu20"].ToString();
                sinifsira2 = dt.Rows[0]["sSinifKodu21"].ToString();
                sinifsira3 = dt.Rows[0]["sSinifKodu22"].ToString();
                sinifsira4 = dt.Rows[0]["sSinifKodu23"].ToString();
                sinifsira5 = dt.Rows[0]["sSinifKodu24"].ToString();
                sinifsira6 = dt.Rows[0]["sSinifKodu25"].ToString();
            }
            else if (dt.Rows.Count == 1)
            {
                nStokID = dt.Rows[0]["nStokID"].ToString();
            }
            btnStokBul.Enabled = false;
            ultraButton1.Enabled = false;
            ultraButton2.Enabled = false;
            simpleButton3.Enabled = false;
            ultraTabControl1.VisibleTabs[1].Visible = true;
            ultraTabControl1.VisibleTabs[2].Visible = true;
            ultraTabControl1.VisibleTabs[3].Visible = true;
            ultraTabControl1.VisibleTabs[4].Visible = true;

            if (nStokID != null || nStokID != "")
            {
                ultraTabControl1.VisibleTabs[5].Visible = true;
                btnKaydet.Text = "Güncelle";
            }


            txtStokKodu.Enabled = false;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            frmStokSinifi sinifi = new frmStokSinifi();
            sinifi.TopLevel = true;
            sinifi.ShowDialog();
            sinif1.Clear();
            sinif2.Clear();
            sinif3.Clear();
            sinif4.Clear();
            sinif5.Clear();
            sinif6.Clear();

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

            cmbSinif1.SelectedValue = sinifsira1;


            if (cmbSinif1.SelectedValue != null)
            {
                cmbSinif2.DisplayMember = "sAciklama";
                cmbSinif2.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "2");
                Prm.Add("@parentid", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-")+1,4));
                sinif2 = conn.DfQuery("Sinif", Prm);
                cmbSinif2.DataSource = sinif2;

            }
            cmbSinif2.SelectedValue = sinifsira2;
            if (sinifsira3 != null)
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

                }

                cmbSinif3.SelectedValue = sinifsira3.Replace("00-0", null);
            }
            if (sinifsira4 != null && sinifsira4 != "00-0")
            {
                cmbSinif4.SelectedValue = sinifsira4.Replace("00-0", null);
            }
            if (sinifsira5 != null && sinifsira5 != "00-0")
            {
                cmbSinif5.SelectedValue = sinifsira5.Replace("00-0", null);
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
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
            else
            {

            }
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

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            frmBarkod barkod = new frmBarkod(txtStokKodu.Text);
            barkod.Show();
        }

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

        private void cmbSinif1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinif1.SelectedValue != null || cmbSinif1.SelectedValue.ToString() == "00-0")
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
                    cmbSinif3.Enabled = true;
                }
                else
                {
                    sinif3.Clear();
                    cmbSinif3.Enabled = false;
                    cmbSinif3.DataSource = null;
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
                XtraMessageBox.Show(dt.ToString() + " Adet Renk / Beden / Kavala olarak Fiyat oluştu");
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
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        renkbeden rnb;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmRenk frm = new frmRenk(KavalaTipi, BedenTipi);
            frm.ShowDialog();

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            renkolanlar.Clear();
            renkolanlar.Columns.Clear();
            txtStokKodu.Text = null;
            sRenkKodu = null;
            bunifuCustomTextbox1.Text = null;
            bunifuCustomTextbox2.Text = null;
            bunifuCustomTextbox3.Text = null;
            lblFiyattipi.Visible = false;
            nStokID = null;
            ultraTabControl1.VisibleTabs[1].Visible = false;
            ultraTabControl1.VisibleTabs[2].Visible = false;
            ultraTabControl1.VisibleTabs[3].Visible = false;
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

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (nStokID != null)
            {  var dd = miniHTMLTextBox1.Text;
                Dictionary<string, string> guncelle = new Dictionary<string, string>();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
