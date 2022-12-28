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
using ExcelDataReader;
using System.IO;
using System.Data.SqlClient;

namespace Entegref
{
    public partial class frmStokToplu : DevExpress.XtraEditors.XtraForm
    {
        DataTableCollection tableCollection;

        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
        DataTable sf1 = new DataTable();
        DataTable sf2 = new DataTable();
        DataTable sf3 = new DataTable();
        DataTable sf4 = new DataTable();
        DataTable sf5 = new DataTable();
        DataTable sf6 = new DataTable();

        string newidson;
        string newid1 = "00";
        string newid2 = "00";
        string newid3 = "00";
        string newid4 = "00";
        string newid5 = "00";
        string newid6 = "00";


        string sira1 = "00-0";
        string sira2 = "00-0";
        string sira3 = "00-0";
        string sira4 = "00-0";
        string sira5 = "00-0";
        string sira6 = "00-0";

        string lblbeden;
        string lblkavala;
        string lblFiyat;

        public frmStokToplu()
        {
            InitializeComponent();
        }
        private void frmStokToplu_Load(object sender, EventArgs e)
        {
            cmbsinif1.DisplayMember = "sAciklama";
            cmbsinif1.ValueMember = "sSinifKodu";
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira", "1");
            Prm.Add("@parentid", "0");
            sf1 = conn.DfQuery("Sinif", Prm);
            cmbsinif1.DataSource = sf1;
        }

        private void btnSiniftanAc_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = true;
        }
        private void cmbsinif1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsinif1.SelectedValue.ToString() != "00-0")
            {
                cmbsinif2.DisplayMember = "sAciklama";
                cmbsinif2.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "2");
                Prm.Add("@parentid", cmbsinif1.SelectedValue.ToString().Substring(cmbsinif1.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf2 = conn.DfQuery("Sinif", Prm);
                cmbsinif2.DataSource = sf2;
                if (sf2.Rows.Count > 1)
                {
                    cmbsinif2.Enabled = true;
                }
                else
                {
                    sf2.Clear();
                    cmbsinif2.Enabled = false;
                    cmbsinif2.DataSource = null;
                }

            }
            else
            {
                sf2.Clear();
                cmbsinif2.Enabled = false;
                cmbsinif2.DataSource = null;
                sf3.Clear();
                cmbsinif3.Enabled = false;
                cmbsinif3.DataSource = null;
                sf4.Clear();
                cmbsinif4.Enabled = false;
                cmbsinif4.DataSource = null;
                sf5.Clear();
                cmbsinif5.Enabled = false;
                cmbsinif5.DataSource = null;
                sf6.Clear();
                cmbsinif6.Enabled = false;
                cmbsinif6.DataSource = null;
            }
        }

        private void cmbsinif2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsinif2.SelectedValue.ToString() != "00-0")
            {
                cmbsinif3.DisplayMember = "sAciklama";
                cmbsinif3.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "3");
                Prm.Add("@parentid", cmbsinif2.SelectedValue.ToString().Substring(cmbsinif2.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf3 = conn.DfQuery("Sinif", Prm);
                cmbsinif3.DataSource = sf3;
                if (sf3.Rows.Count > 1)
                {
                    cmbsinif3.Enabled = true;
                }
                else
                {
                    sf3.Clear();
                    cmbsinif3.Enabled = false;
                    cmbsinif3.DataSource = null;
                }

            }
            else
            {
                sf3.Clear();
                cmbsinif3.Enabled = false;
                cmbsinif3.DataSource = null;
                sf4.Clear();
                cmbsinif4.Enabled = false;
                cmbsinif4.DataSource = null;
                sf5.Clear();
                cmbsinif5.Enabled = false;
                cmbsinif5.DataSource = null;
                sf6.Clear();
                cmbsinif6.Enabled = false;
                cmbsinif6.DataSource = null;
            }
        }

        private void cmbsinif3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsinif3.SelectedValue.ToString() != "00-0")
            {
                cmbsinif4.DisplayMember = "sAciklama";
                cmbsinif4.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "4");
                Prm.Add("@parentid", cmbsinif3.SelectedValue.ToString().Substring(cmbsinif3.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf4 = conn.DfQuery("Sinif", Prm);
                cmbsinif4.DataSource = sf4;
                if (sf4.Rows.Count > 1)
                {
                    cmbsinif4.Enabled = true;
                }
                else
                {
                    sf4.Clear();
                    cmbsinif4.Enabled = false;
                    cmbsinif4.DataSource = null;
                }

            }
            else
            {
                sf4.Clear();
                cmbsinif4.Enabled = false;
                cmbsinif4.DataSource = null;
                sf5.Clear();
                cmbsinif5.Enabled = false;
                cmbsinif5.DataSource = null;
                sf6.Clear();
                cmbsinif6.Enabled = false;
                cmbsinif6.DataSource = null;
            }
        }

        private void cmbsinif4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsinif4.SelectedValue.ToString() != "00-0")
            {
                cmbsinif5.DisplayMember = "sAciklama";
                cmbsinif5.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "5");
                Prm.Add("@parentid", cmbsinif4.SelectedValue.ToString().Substring(cmbsinif4.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf5 = conn.DfQuery("Sinif", Prm);
                cmbsinif5.DataSource = sf5;
                if (sf5.Rows.Count > 1)
                {
                    cmbsinif5.Enabled = true;
                }
                else
                {
                    sf5.Clear();
                    cmbsinif5.Enabled = false;
                    cmbsinif5.DataSource = null;
                }

            }
            else
            {
                sf5.Clear();
                cmbsinif5.Enabled = false;
                cmbsinif5.DataSource = null;
                sf6.Clear();
                cmbsinif6.Enabled = false;
                cmbsinif6.DataSource = null;
            }
        }

        private void cmbsinif5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsinif5.SelectedValue.ToString() != "00-0")
            {
                cmbsinif6.DisplayMember = "sAciklama";
                cmbsinif6.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "6");
                Prm.Add("@parentid", cmbsinif5.SelectedValue.ToString().Substring(cmbsinif5.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf6 = conn.DfQuery("Sinif", Prm);
                cmbsinif6.DataSource = sf6;
                cmbsinif6.Enabled = true;
            }
            else
            {
                sf6.Clear();
                cmbsinif6.Enabled = false;
                cmbsinif6.DataSource = null;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnExcelAc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtExcelYolu.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cmbExcelSekme.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cmbExcelSekme.Items.Add(table.TableName);//add sheet to combobox
                        }
                    }
                }
            }
        }
        private void cmbExcelSekme_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cmbExcelSekme.SelectedItem.ToString()];
            gridExcelVeriAktar.DataSource = dt;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sourcePath = Application.StartupPath;
            StreamWriter tw = new StreamWriter(sourcePath + "\\DownloadDefauldFile\\UrunAc.xls");
            tw.Write(textBox1.Text);
            label1.Text = "File Save Successfully";
            Random r = new Random();
            label1.ForeColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
            tw.Close();
            //SaveFileDialog save = new SaveFileDialog();
            //save.DefaultExt = "xls";
            //save.Filter = "Excel files (*.xls)|*.xlsx";
            //save.CheckFileExists = true;
            //if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string sourcePath = Application.StartupPath;
            //    File.Copy(sourcePath + "\\DownloadDefauldFile\\UrunAc.xls", save.FileName);
            //}
        }
    }
}