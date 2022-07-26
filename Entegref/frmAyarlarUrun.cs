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
using System.Data.SqlClient;
using System.Globalization;

namespace Entegref
{
    public partial class frmAyarlarUrun : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        DataTable renk = new DataTable();

        int sonRenk;
        string sonkod;
        int toplam;
        string YeniBedenTipi = "";

        private string hexValue;
        private int decValue;

        public frmAyarlarUrun()
        {
            InitializeComponent();
        }

        private void frmUrunAyarları_Load(object sender, EventArgs e)
        {
        }
        void Beden()
        {
            renk.Clear();
            string query = "select * from tbBedenTipi ";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            da.Fill(dt);
            sql.Close();
            gridBedenTumu.DataSource = dt;
            toplam = ViewBedenTumu.RowCount+1;
            YeniBedenTipi = "0" + toplam.ToString();
        }
        void Renk(string _renk)
        {
            string query;
            if (_renk == null)
            {
                renk.Clear();
                query = "select sRenk,sRenkAdi,lRenkNo from tbRenk where sRenk != ''";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
                da.Fill(renk);
                sql.Close();
                GridRenk.DataSource = renk;
                sonRenk = ViewRenk.RowCount;
            }
            else
            {
                query = "select sRenk,sRenkAdi,lRenkNo from tbRenk where sRenk = '" + _renk + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
                da.Fill(renk);
                sql.Close();
                
            }
            
        }
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Key == "0")
            {
                btnRenkSec.Text = "Yeni";
                Renk(null);
            }
            if (ultraTabControl1.SelectedTab.Key == "1")
            {
                Beden();
                cmbBedenTipi.DisplayMember = "sAciklama";
                cmbBedenTipi.ValueMember = "sBedenTipi";
                string query = "select '' as sBedenTipi,'Seçiniz...' as sAciklama union select sBedenTipi,sAciklama from tbBedenTipi where sBedenTipi != '' order by 1,2";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
                da.Fill(dt);
                sql.Close();
                cmbBedenTipi.DataSource = dt;


            }
        }

        private void cmbBedenTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridBeden.DataSource = null;
            string value;
            if (cmbBedenTipi.SelectedValue.ToString() == "")
            {
                value = " ";
            }
            else
            {
                value = cmbBedenTipi.SelectedValue.ToString();
            }
            string query = "select * from tbBedenTipi where sBedenTipi = '" +value+ "'";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tekbeden = new DataTable();
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            da.Fill(tekbeden);
            sql.Close();
            gridBeden.DataSource = tekbeden;


        }

        private void btnBedenYeni_Click(object sender, EventArgs e)
        {
            if (btnBedenAc.Enabled == false)
            {
                cmbBedenTipi.SelectedIndex = 0;
                cmbBedenTipi.Enabled = false;
                txtBedenAdı.Enabled = true;
                btnBedenAc.Enabled = true;
                btnBedenYeni.Text = "Vazgeç";
            }
            else
            {

                cmbBedenTipi.Enabled = true;
                txtBedenAdı.Enabled = false;
                btnBedenAc.Enabled = false;
                btnBedenYeni.Text = "Yeni Oluştur";
            }
        }

        private void btnBedenAc_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sBedenTipi", YeniBedenTipi);
            Prm.Add("@sAciklama", txtBedenAdı.Text);
            Prm.Add("@sBeden1", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[0]).ToString());
            Prm.Add("@sBeden2", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[1]).ToString());
            Prm.Add("@sBeden3", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[2]).ToString());
            Prm.Add("@sBeden4", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[3]).ToString());
            Prm.Add("@sBeden5", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[4]).ToString());
            Prm.Add("@sBeden6", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[5]).ToString());
            Prm.Add("@sBeden7", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[6]).ToString());
            Prm.Add("@sBeden8", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[7]).ToString());
            Prm.Add("@sBeden9", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[8]).ToString());
            Prm.Add("@sBeden10", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[9]).ToString());
            Prm.Add("@sBeden11", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[10]).ToString());
            Prm.Add("@sBeden12", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[11]).ToString());
            Prm.Add("@sBeden13", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[12]).ToString());
            Prm.Add("@sBeden14", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[13]).ToString());
            Prm.Add("@sBeden15", ViewBeden.GetRowCellValue(ViewBeden.FocusedRowHandle, ViewBeden.Columns[14]).ToString());

            cmbBedenTipi.SelectedIndex = 0;
            txtBedenAdı.Text = null;
            cmbBedenTipi.Enabled = true;
            txtBedenAdı.Enabled = false;
            btnBedenAc.Enabled = false;
            gridBeden.DataSource = null;
            btnBedenYeni.Text = "Yeni Oluştur";
            Beden();
        }

        private void btnRenkAc_Click(object sender, EventArgs e)
        {

        }
        void sonkodubul()
        {
            var uzun = sonRenk.ToString().Length;
            if (uzun <= 9)
            {
                sonkod = "00" + sonRenk.ToString();
            }
        }
    private void btnRenkSec_Click(object sender, EventArgs e)
        {
            if (txtRenkKodu.Text == null || txtRenkKodu.Text != "")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 5000;
                args.Caption = "İşlem Sırası Uyarı";
                args.Text = "Ürün Kodu Boş Olamaz..! Yeni Kod Yazın Yada Var olanlardan birini güncellemek için listeden 1 tane seçin ";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                XtraMessageBox.Show(args).ToString();

            }
            else
            {

                if (btnRenkSec.Text == "Yeni")
                {
                    btnRenkSec.Text = "Kaydet";
                    sonkodubul();
                    txtRenkKodu.Text = sonkod;
                }
                Renk(txtRenkKodu.Text);
                btnRenkSec.Enabled = false;
                txtRenkKodu.ReadOnly = true;
                txtRenkKodu.Enabled = false;
            }
        }

        private void btnRenkKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnRenkYeni_Click(object sender, EventArgs e)
        {

        }

        private void btnRenkSil_Click(object sender, EventArgs e)
        {

        }

        private void ultraColorPicker1_ColorChanged(object sender, EventArgs e)
        {
            ultraTextEditor2.Appearance.BackColorDisabled = ultraColorPicker1.Color;
        }

        private void btnRenkResimAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.CheckFileExists = false;
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            fileDialog.Title = "Resim Dosyası Seçin";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = fileDialog.FileName;
                pictureBox1.Load();
            }

        }

        private void kısayolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmAyarlarUrun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.D)
            {

            }

            
        }
        public static Color HexToColor(string hexString)
        {
            //replace # occurences
            if (hexString.IndexOf('#') != -1)
                hexString = hexString.Replace("#", "");

            int r = 0;
            int g = 0;
            int b = 0;
            if (hexString.Length > 5)
            {
                r = int.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                g = int.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                b = int.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            }
            return Color.FromArgb(r, g, b);
        }
        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[0])
            {
                String hexColor = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(ultraColorPicker1.Color.A, ultraColorPicker1.Color.R, ultraColorPicker1.Color.G, ultraColorPicker1.Color.B));  //returns the hex value
                var color =  int.Parse(hexColor.Replace("#",""), System.Globalization.NumberStyles.HexNumber);
                
                



                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                keyValues.Add("@sRenk", txtRenkKodu.Text);
                keyValues.Add("@sRenkAdi", txtRenkAdi.Text);
                keyValues.Add("@lRenkNo", color.ToString());
                keyValues.Add("@ReturnDesc", "");
                var sonuc = conn.DfInsertBack("Renk", keyValues);
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text +" sayfasında " +sonuc);
                btnRenkSec.Text = "Yeni";
                pictureBox1.ImageLocation="";
                pictureBox1.Dispose();
                Renk(null);
                btnYeni_ItemClick(null, null);
                ultraTabControl1.Tabs[0].Selected = true;
                
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[1])
            {
                ultraTabControl1.Tabs[1].Selected = true;
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text);
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[2])
            {
                ultraTabControl1.Tabs[2].Selected = true;
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text);
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[3])
            {
                ultraTabControl1.Tabs[3].Selected = true;
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text);
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[4])
            {
                ultraTabControl1.Tabs[4].Selected = true;
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text);
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[5])
            {
                ultraTabControl1.Tabs[5].Selected = true;
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text);
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[6])
            {
                ultraTabControl1.Tabs[6].Selected = true;
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text);
            }

        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[0])
            {
                ultraTabControl1.Tabs[0].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[1])
            {
                ultraTabControl1.Tabs[1].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[2])
            {
                ultraTabControl1.Tabs[2].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[3])
            {
                ultraTabControl1.Tabs[3].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[4])
            {
                ultraTabControl1.Tabs[4].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[5])
            {
                ultraTabControl1.Tabs[5].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[6])
            {
                ultraTabControl1.Tabs[6].Selected = true;
            }
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[0])
            {

                if (btnRenkSec.Text == "Yeni")
                {
                    sonkodubul();
                    txtRenkKodu.Text = sonkod;
                }
                else
                {
                    btnRenkSec.Text = "Yeni";
                    txtRenkKodu.Text = null;
                }
                btnRenkSec.Enabled = true;
                txtRenkKodu.ReadOnly = false;
                txtRenkKodu.Enabled = true;
                txtRenkKodu.Text = null;
                txtRenkAdi.Text = null;

                ultraTabControl1.Tabs[0].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[1])
            {
                ultraTabControl1.Tabs[1].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[2])
            {
                ultraTabControl1.Tabs[2].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[3])
            {
                ultraTabControl1.Tabs[3].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[4])
            {
                ultraTabControl1.Tabs[4].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[5])
            {
                ultraTabControl1.Tabs[5].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[6])
            {
                ultraTabControl1.Tabs[6].Selected = true;
            }
        }

        private void ViewRenk_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle >=0 && e.Clicks ==2 && e.Button == MouseButtons.Left)
            {
                txtRenkKodu.Text = ViewRenk.GetRowCellValue(ViewRenk.FocusedRowHandle, "sRenk").ToString().Replace(" ","");
                txtRenkAdi.Text = ViewRenk.GetRowCellValue(ViewRenk.FocusedRowHandle, "sRenkAdi").ToString().Replace(" ", "");

                decValue = int.Parse(ViewRenk.GetRowCellValue(ViewRenk.FocusedRowHandle, "lRenkNo").ToString().Replace(" ", ""), System.Globalization.NumberStyles.Integer);
                hexValue = decValue.ToString("X");

                Color rgb = System.Drawing.ColorTranslator.FromHtml("#" + hexValue);
                ultraTextEditor2.Appearance.BackColorDisabled = rgb;
                //ultraTextEditor2.Appearance.BackColor.IsSystemColor.ToString() =  ViewRenk.GetRowCellValue(ViewRenk.FocusedRowHandle, "lRenkNo").ToString().Replace(" ", "");
            }
        }
    }
}