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
using System.IO;
using System.Data.SqlClient;

namespace Entegref
{
    public partial class frmAyarlarUrunGenel : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        public frmAyarlarUrunGenel()
        {
            InitializeComponent();
        }
        
        private void frmAyarlarUrunGenel_Load(object sender, EventArgs e)
        {
            dteUrunTarih1.DateTime = DateTime.Now;
            dteUrunTarih2.DateTime = DateTime.Now;
            int sira = 0;
            string q = "select bRenkVarmi[Renk Var], bBedenVarmi[Beden Var], bKavalaVarmi[Kavala Var], bDepoVarmi[Çoklu Depo Kullanılacak], bEanVarmi[Ean Kodu Kullanılacak], "+
                "bDovizliGirisVar[Fiyatlarda Döviz Kuru Var], bEksiyeDusulebilirmi[Stok Eksiye Düşebilir], bFiyatSifirGirilsin[Fiyat Girişinde 0 Girilebilir], bIkinciMiktarVar [İşlemlerde 2.nci Miktar Girişi Var], "+
                "sResimDosyalariPath, sDefaultKdvTipi, sDefaultBirimCinsi, sDefaultOtvTipi, sDefaultHareketTipi, "+
                "sAciklamaBaslik1, sAciklamaBaslik2, sAciklamaBaslik3, sAciklamaBaslik4, sAciklamaBaslik5, sAciklamaBaslik6," +
                "sAciklamaBaslik7, sAciklamaBaslik8, sAciklamaBaslik9, sAciklamaBaslik10, bHareketTipiVarmi, sMatbuFormlarPath," +
                " sRaporlarPath,sTasimaDosyalariPath,dteBaslangicTarih,dteBitisTarih from tbParamStok stk Cross Apply(select bHareketTipiVarmi, sMatbuFormlarPath," +
                "sRaporlarPath, sTasimaDosyalariPath from tbParamGenel) gnl";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string d = dt.Rows[0][i].ToString();
                if (dt.Columns[i].ToString() == "sResimDosyalariPath")
                {
                    textResimYolu.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sDefaultKdvTipi")
                {
                    txtKDV.Text= dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sDefaultBirimCinsi")
                {
                    txtBirim.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sDefaultHareketTipi")
                {
                    txtHareketTipi.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "Ötv'li Ürün var")
                {
                    if (dt.Rows[0][i].ToString() == "False")
                    {
                        checkOTVVar.Checked = false;
                    }
                    else
                    {
                        checkOTVVar.Checked = true;
                    }
                }
                else if (dt.Columns[i].ToString() == "sDefaultOtvTipi")
                {
                    if (dt.Rows[0][3].ToString() == "True")
                    {
                        txtOTV.Text = dt.Rows[0][i].ToString();
                    }
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik1")
                {
                    txtsAciklamaBaslik1.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik2")
                {
                    txtsAciklamaBaslik2.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik3")
                {
                    txtsAciklamaBaslik3.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik4")
                {
                    txtsAciklamaBaslik4.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik5")
                {
                    txtsAciklamaBaslik5.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik6")
                {
                    txtsAciklamaBaslik6.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik7")
                {
                    txtsAciklamaBaslik7.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik8")
                {
                    txtsAciklamaBaslik8.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik9")
                {
                    txtsAciklamaBaslik9.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sAciklamaBaslik10")
                {
                    txtsAciklamaBaslik10.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "bHareketTipiVarmi")
                {
                    if (dt.Rows[0][i].ToString() == "False")
                    {
                        checkHarekettipiVar.Checked = false;
                    }
                    else
                    {
                        checkHarekettipiVar.Checked = true;
                    }
                }
                else if (dt.Columns[i].ToString() == "sMatbuFormlarPath")
                {
                    txtFormYolu.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sRaporlarPath")
                {
                    txtRaporYolu.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "sTasimaDosyalariPath")
                {
                    txtDisVeriYolu.Text = dt.Rows[0][i].ToString();
                }
                else if (dt.Columns[i].ToString() == "dteBaslangicTarih") 
                {

                    dteUrunTarih1.DateTime = Convert.ToDateTime(dt.Rows[0]["dteBaslangicTarih"].ToString());
                }
                else if (dt.Columns[i].ToString() == "dteBitisTarih") 
                {
                    dteUrunTarih2.DateTime = Convert.ToDateTime(dt.Rows[0]["dteBitisTarih"].ToString());
                }
                else
                {
                    //checkUrunParemetre.Items.Capacity = 20;
                    checkUrunParemetre.Items.Add(dt.Columns[i]);
                    sira++;
                    if (dt.Rows[0][i].ToString() == "True")
                    {
                        checkUrunParemetre.SetItemChecked(sira-1, true);
                    }
                }
            }

        }
        private void btnResimYoluAc_Click(object sender, EventArgs e)
        {
            textResimYolu.Text = DosyaYoluAc("");
        }

        private void btnFormYoluAc_Click(object sender, EventArgs e)
        {
            txtFormYolu.Text = DosyaYoluAc("");
        }

        private void btnRaporYoluAc_Click(object sender, EventArgs e)
        {
            txtRaporYolu.Text = DosyaYoluAc("");
        }

        private void btnDisveriYoluAc_Click(object sender, EventArgs e)
        {
            txtDisVeriYolu.Text = DosyaYoluAc("");
        }
        public string DosyaYoluAc(string _dosyayolu)
        {
            string workingDirectory = Environment.CurrentDirectory;
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            string path = Directory.GetParent(workingDirectory).Parent.FullName + @"\Pictures";
            if (Directory.Exists(path))
            {
                folderBrowser.InitialDirectory = path;
            }
            else
            {
                folderBrowser.InitialDirectory = @"C:\";
            }

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                _dosyayolu = folderPath;
            }
            return _dosyayolu;
        }

        private void txtKDV_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtBirim_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void txtHareketTipi_MouseClick(object sender, MouseEventArgs e)
        {
           

        }
        private void UpdateGrid(DataTable dataSource)
        {
            gridOncelik.BeginUpdate();
            try
            {
                gridOncelik.DataSource = null;
                gridOncelik.DataSource = dataSource;
            }
            finally
            {
                gridOncelik.EndUpdate();
            }
        }
        private void txtKDV_MouseDown(object sender, MouseEventArgs e)
        {

            gridOncelik.DataSource = null;
            
            string q = "select sKdvTipi as [adi], nKdvOrani as [aciklama] from tbKdv where sKdvTipi != ''";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            UpdateGrid(dt);
        }

        private void txtBirim_MouseDown(object sender, MouseEventArgs e)
        {
            gridOncelik.DataSource = null;
            string q = "select sBirimCinsi as [adi],sAciklama as [aciklama] from tbBirimCinsi";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            UpdateGrid(dt);
        }

        private void txtHareketTipi_MouseDown(object sender, MouseEventArgs e)
        {
            gridOncelik.DataSource = null;
            string q = "select sHareketTipi as [adi],sAciklama as [aciklama] from tbHareketTipi where sHareketTipi != ''";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            UpdateGrid(dt);
        }

        private void txtOTV_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkOTVVar.Checked == true)
            {
                gridOncelik.DataSource = null;
                string q = "select sOTVTipi as [adi], nOTVOrani as [aciklama] from tbOTV where sOTVTipi != ''";
                SqlCommand cmd = new SqlCommand(q, sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                UpdateGrid(dt);
            }
        }

        private void checkOTVVar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOTVVar.Checked == true)
            {
                txtOTV.Enabled = true;
            }
            else
            {
                txtOTV.Enabled = false;
            }

        }

        private void checkHarekettipiVar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHarekettipiVar.Checked == true)
            {
                txtHareketTipi.Enabled = true;
            }
            else
            {
                txtHareketTipi.Enabled = false;
            }

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> PG = new Dictionary<string, string>();
            for (int i = 0; i < checkUrunParemetre.Items.Count; i++)
            {
                string tt = "@b"+checkUrunParemetre.Items[i].Value.ToString().Replace(" ","");
                string durum = checkUrunParemetre.Items[i].CheckState.ToString();
                if (durum == "Unchecked")
                {
                    PG.Add(tt, "0");
                }
                else
                {
                    PG.Add(tt, "1");
                }
            }
            if (checkOTVVar.Checked == true)
            {
                PG.Add("@bOTVVar", "1");
            }
            else
            {
                PG.Add("@bOTVVar", "0");
            }
            PG.Add("@sDefaultOtvTipi", txtOTV.Text);
            PG.Add("@sDefaultKdvTipi", txtKDV.Text);
            PG.Add("@sDefaultBirimCinsi", txtBirim.Text);
            if (checkHarekettipiVar.Checked == true)
            {
                PG.Add("@bHareketTipiVar","1");
            }
            else
            {
                PG.Add("@bHareketTipiVar", "0");
            }
            PG.Add("@sDefaultHareketTipi", txtHareketTipi.Text);
            PG.Add("@sResimDosyalariPath", textResimYolu.Text);
            PG.Add("@sMatbuFormlarPath", txtFormYolu.Text);
            PG.Add("@sRaporlarPath", txtRaporYolu.Text);
            PG.Add("@sTasimaDosyalariPath", txtDisVeriYolu.Text);
            PG.Add("@sAciklamaBaslik1", txtsAciklamaBaslik1.Text);
            PG.Add("@sAciklamaBaslik2", txtsAciklamaBaslik2.Text);
            PG.Add("@sAciklamaBaslik3", txtsAciklamaBaslik3.Text);
            PG.Add("@sAciklamaBaslik4", txtsAciklamaBaslik4.Text);
            PG.Add("@sAciklamaBaslik5", txtsAciklamaBaslik5.Text);
            PG.Add("@sAciklamaBaslik6", txtsAciklamaBaslik6.Text);
            PG.Add("@sAciklamaBaslik7", txtsAciklamaBaslik7.Text);
            PG.Add("@sAciklamaBaslik8", txtsAciklamaBaslik8.Text);
            PG.Add("@sAciklamaBaslik9", txtsAciklamaBaslik9.Text);
            PG.Add("@sAciklamaBaslik10", txtsAciklamaBaslik10.Text);
            PG.Add("@dteBaslangicTarih", dteUrunTarih1.Text);
            PG.Add("@dteBitisTarih", dteUrunTarih2.Text);

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}