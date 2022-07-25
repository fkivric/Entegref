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



        public static string sKodu = "";
        public static string sFiyatTipi = "";

        public static string sinifsira1;
        public static string sinifsira2;
        public static string sinifsira3;
        public static string sinifsira4;
        public static string sinifsira5;
        public static string sinifsira6;


        public static string Fiyatlandirma;
        public static string Beden;
        public static string Kavala;
        public frmStokAc()
        {
            InitializeComponent();
        }

        private void frmStokAc_Load(object sender, EventArgs e)
        {
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
                ultraTabControl1.VisibleTabs[2].Visible =false;
                ultraTabControl1.VisibleTabs[3].Visible = false;
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

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string Queryable = "select * from tbstok where skodu = '"+ txtStokKodu.Text + "'";
            SqlCommand cmd = new SqlCommand(Queryable, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            connection.Close();
            nStokID = dt.Rows[0]["nStokID"].ToString();
            bunifuCustomTextbox1.Text = dt.Rows[0]["sAciklama"].ToString();
            cmbBirim1.Text = dt.Rows[0]["sBirimCinsi1"].ToString();
            cmbBirim2.Text = dt.Rows[0]["sBirimCinsi2"].ToString();
            cmbKDV.Text = dt.Rows[0]["sKdvTipi"].ToString();
            bunifuCustomTextbox1.Text = dt.Rows[0]["sAciklama"].ToString();
            btnStokBul.Enabled = false;
            ultraButton1.Enabled = false;
            ultraButton2.Enabled = false;
            if (nStokID != null)
            {
                ultraTabControl1.VisibleTabs[1].Visible = true;
                ultraTabControl1.VisibleTabs[2].Visible = true;
                ultraTabControl1.VisibleTabs[3].Visible = true;
            }

            //XtraMessageBox.Show("Kaydetildi");
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            frmStokSinifi sinifi = new frmStokSinifi();
            sinifi.TopLevel = true;
            sinifi.ShowDialog();
            cmbSinif1.SelectedValue = sinifsira1;
            cmbSinif2.SelectedValue = sinifsira2;
            cmbSinif3.SelectedValue = sinifsira3.Replace("00-0",null);
            cmbSinif4.SelectedValue = sinifsira4.Replace("00-0",null);
            cmbSinif5.SelectedValue = sinifsira5.Replace("00-0",null);
            cmbSinif6.SelectedValue = sinifsira6.Replace("00-0", null);
            lblFiyattipi.Visible = true;
            lblFiyattipi.Text = Fiyatlandirma;
            if (Beden != null)
            {
                lblBeden.Text = Beden;
                lblBeden.Visible = true;
            }
            if (Kavala != null)
            {
                lblKavala.Text = Kavala;
                lblKavala.Visible = true;
            }
            txtStokKodu.Text = sKodu;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Configure open file dialog box 
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

            dlg.DefaultExt = ".png"; // Default file extension 

            // Show open file dialog box 
            //Nullable<bool> result = 
                dlg.ShowDialog();

            // Process open file dialog box results 
                // Open document 
            txtFileAdress.Text = dlg.FileName;
            filename = dlg.SafeFileName.ToString();
                // Do something with fileName  

            //OpenFileDialog open = new OpenFileDialog();
            //open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //open.Filter = "Resim Dosyası |*.PNG,*.png,*.jpg,*.JPG";
            //open.FilterIndex = 2;
            //open.ShowDialog();
            //txtFileAdress.Text = open.FileName;

        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab.Text == "Resimler")
            {
                if (txtStokKodu.Text == null || txtStokKodu.Text == "")
                {
                    XtraMessageBox.AllowCustomLookAndFeel = true;
                    DialogResult dialogResult = XtraMessageBox.Show("Ürün Kaydedilmemiş! Şimdi Kaydedilsin mi?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        ultraButton3_Click(null, null);
                    }
                    else
                    {
                        pnlUrunResimbtn.Enabled = false;
                    }
                }
                else
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

                        FileInfo[] Files = d.GetFiles("*.png");
                        FileInfo[] Files2 = d.GetFiles("*.jpg");

                        foreach (FileInfo file in Files)
                        {
                            resim.Rows.Add(new object[] { file.Name, file.FullName });
                            //listBox1.Items.Add(file.FullName);
                        }
                        foreach (FileInfo file2 in Files2)
                        {
                            resim.Rows.Add(new object[] { file2.Name, file2.FullName });
                            //listBox1.Items.Add(file2.FullName);
                        }
                        listBox1.DataSource = resim;
                        label20.Text = "Toplam Resim : " + listBox1.Items.Count.ToString();
                    }

                    label20.Text = "Toplam Resim : ";
                }
            }
            else if (e.Tab.Text == "Fiyatlandırma")
            {
                if (nStokID != null)
                {
                    string q = "select nStokID,sFiyatTipi,lFiyat,dteFiyatTespitTarihi,sKullaniciAdi from tbStokFiyati where nStokID = '" + nStokID + "'";
                    SqlCommand cmd = new SqlCommand(q, connection);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    ad.Fill(dt);
                    gridFiyatlar.DataSource = dt;
                    //gridTopluFiyat.DataSource = dt;
                }
            }
            else if (e.Tab.Text== "Sınıflar")
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
                //sinif_1();
                //sinif_2();
                //sinif_3();
                //sinif_4();
                //sinif_5();
                //sinif_6();
                //cmbSinif1.DisplayMember = "sAciklama";
                //cmbSinif1.ValueMember = "sSinifKodu";
                //cmbSinif1.DataSource = sinif1;
                //cmbSinif2.DisplayMember = "sAciklama";
                //cmbSinif2.ValueMember = "sSinifKodu";
                //cmbSinif2.DataSource = sinif2;
                //cmbSinif3.DisplayMember = "sAciklama";
                //cmbSinif3.ValueMember = "sSinifKodu";
                //cmbSinif3.DataSource = sinif3;
                //cmbSinif4.DisplayMember = "sAciklama";
                //cmbSinif4.ValueMember = "sSinifKodu";
                //cmbSinif4.DataSource = sinif4;
                //cmbSinif5.DisplayMember = "sAciklama";
                //cmbSinif5.ValueMember = "sSinifKodu";
                //cmbSinif5.DataSource = sinif5;
                //cmbSinif6.DisplayMember = "sAciklama";
                //cmbSinif6.ValueMember = "sSinifKodu";
                //cmbSinif6.DataSource = sinif6;
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
                txtFileAdress.Text = dosya;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Save the file in folder
            string fileLocation = txtFileAdress.Text;
            File.Copy(txtFileAdress.Text, Path.Combine(@"..\..\Pictures\", Path.GetFileName(filename)), true);
            txtFileAdress.Text = null;
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
            txtStokKodu.Text = sKodu;
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
                pnlTopluFiyat.Visible = false;
                pnlTekfiyat.Visible = true;
                txtTipi.Text = null;
                gridFiyatlar.Visible = true;
                gridFiyatlar.Dock = DockStyle.Fill;
            }
            if (grpFTipiSec.SelectedIndex.ToString() == "1")
            {
                pnlTopluFiyat.Visible = true;
                pnlTekfiyat.Visible = false;
                txtTipi.Text = null;
                pnlTopluFiyat.Dock = DockStyle.Fill;
                gridFiyatlar.Visible = false;


                DataTable fiyat_yeni = new DataTable();
                string Fiyatsql = "select ff.nStokID,t.sFiyatTipi, t.sAciklama,dteFiyatTespitTarihi,lFiyat,0 from tbFiyatTipi t ";
                Fiyatsql = Fiyatsql + " left join(select f.nStokID,f.lFiyat, f.dteFiyatTespitTarihi, f.sFiyatTipi from tbStokFiyati f ";
                Fiyatsql = Fiyatsql + "inner join tbstok s on s.nStokID= f.nStokID where s.sKodu = isnull('" + txtStokKodu.Text + "','')";
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
                Fiyatsql = Fiyatsql + "inner join tbstok s on s.nStokID= f.nStokID where s.sKodu = isnull('" + txtStokKodu.Text + "','')";
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
            frmFiyatTipi fiyatTipi = new frmFiyatTipi();
            fiyatTipi.ShowDialog();
            txtTipi.Text = sFiyatTipi;
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
            if (cmbSinif1.SelectedValue.ToString() != "00-0")
            {
                cmbSinif2.DisplayMember = "sAciklama";
                cmbSinif2.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "2");
                Prm.Add("@parentid", cmbSinif1.SelectedValue.ToString().Substring(cmbSinif1.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sinif2 = conn.DfQuery("Sinif", Prm);
                cmbSinif2.DataSource = sinif2;
                if (sinif2.Rows.Count > 1)
                {
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
            //Dictionary<string, string> keys = new Dictionary<string, string>();
            //keys.Add("",);
            //keys.Add("",);
            //keys.Add("",);

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
