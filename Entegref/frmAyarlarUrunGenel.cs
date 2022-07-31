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
            string q = "select bDepoVarmi [Çoklu Depo Kullanılacak], bEanVarmi [Ean Kodu Kullanılacak], sResimDosyalariPath,bOTVVar [Ötv'li Ürün var],sDefaultKdvTipi,sDefaultBirimCinsi,sDefaultOtvTipi,sDefaultHareketTipi, sAciklamaBaslik1, sAciklamaBaslik2, sAciklamaBaslik3, sAciklamaBaslik4, sAciklamaBaslik5, sAciklamaBaslik6, sAciklamaBaslik7, sAciklamaBaslik8, sAciklamaBaslik9, sAciklamaBaslik10,bDovizliGirisVar from tbParamStok";
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
                    textEdit1.Text = dt.Rows[0][i].ToString();
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
                else
                {
                    checkUrunParemetre.Items.Add(dt.Columns[i]);
                    if (dt.Rows[0][i].ToString() == "True")
                    {
                        checkUrunParemetre.SetItemChecked(i, true);
                    }
                }
            }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
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
                textEdit1.Text = folderPath;
            }
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
    }
}