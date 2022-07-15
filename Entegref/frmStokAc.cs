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
    public partial class frmStokAc : Form
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
        DataTable kdv = new DataTable();
        DataTable birim1 = new DataTable();
        DataTable birim2 = new DataTable();
        DataTable Otv = new DataTable();
        public static string sKodu = "";
        public static string sFiyatTipi = "";
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
            bunifuCustomTextbox1.Text = dt.Rows[0]["sAciklama"].ToString();
            cmbBirim1.Text = dt.Rows[0]["sBirimCinsi1"].ToString();
            cmbBirim2.Text = dt.Rows[0]["sBirimCinsi2"].ToString();
            cmbKDV.Text = dt.Rows[0]["sKdvTipi"].ToString();
            bunifuCustomTextbox1.Text = dt.Rows[0]["sAciklama"].ToString();

            XtraMessageBox.Show("Kaydetildi");
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            frmStokSinifi sinifi = new frmStokSinifi();
            sinifi.TopLevel = true;
            sinifi.Show();
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

            }
            else
            {
                
            }
        }
        public string filename = "";
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            var lst = listBox1.Items[index].ToString();

            string file = @"..\..\Pictures\"+ txtStokKodu.Text.ToString();
            string dosya = listBox1.SelectedValue.ToString();
            int satirno = listBox1.SelectedIndex;
            pictureBox1.Image = Image.FromFile(dosya);
            txtFileAdress.Text = dosya;
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
            }
            if (grpFTipiSec.SelectedIndex.ToString() == "1")
            {
                pnlTopluFiyat.Visible = true;
                pnlTekfiyat.Visible = false;
                txtTipi.Text = null;


                //DataTable fiyat_yeni = new DataTable();
                //string Fiyatsql = "select ff.nStokID,t.sFiyatTipi, t.sAciklama,dteFiyatTespitTarihi,lFiyat,0 from tbFiyatTipi t ";
                //Fiyatsql = Fiyatsql + " left join(select f.nStokID,f.lFiyat, f.dteFiyatTespitTarihi, f.sFiyatTipi from tbStokFiyati f ";
                //Fiyatsql = Fiyatsql + "inner join tbstok s on s.nStokID= f.nStokID where s.sKodu = isnull('" + txtStokKodu.Text + "','')";
                //Fiyatsql = Fiyatsql + ") ff on ff.sFiyatTipi = t.sFiyatTipi";
                //SqlCommand cmd = new SqlCommand(Fiyatsql, connection);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //if (connection.State == ConnectionState.Closed)
                //{
                //    connection.Open();
                //}
                //da.Fill(fiyat_yeni);
                //connection.Close();
                //gridTopluFiyat.DataSource = fiyat_yeni;
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
    }
}
