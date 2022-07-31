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
using System.Xml;

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


        decimal dolar;
        public frmAyarlarUrun()
        {
            InitializeComponent();
        }

        private void frmUrunAyarları_Load(object sender, EventArgs e)
        {
        }
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Key == "0")
            {
                btnKaydet.Text = "Kaydet";
                btnRenkSec.Text = "Yeni";
                Renk(null);

                XtraMessageBoxArgs rnk = new XtraMessageBoxArgs();
                rnk.Caption = "İlk İşlem Uyarısı";
                rnk.Text = "Mevcut Güncelleme Yapmak için Listede Olanlara Mouse ile Cift Tıklamalısınız..!";
                rnk.Buttons = new DialogResult[] { DialogResult.OK };
                rnk.DoNotShowAgainCheckBoxVisible = true;
                rnk.DoNotShowAgainCheckBoxText = "Tekrar Gösterme";
                XtraMessageBox.Show(rnk).ToString();
            }
            if (ultraTabControl1.SelectedTab.Key == "1")
            {
                btnKaydet.Text = "Kaydet";
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

                XtraMessageBoxArgs Bdn = new XtraMessageBoxArgs();
                Bdn.Caption = "İlk İşlem Uyarısı";
                Bdn.Text = "Mevcut Güncelleme Yapmak için Listede Olanlara Mouse ile Cift Tıklamalısınız..!";
                Bdn.Buttons = new DialogResult[] { DialogResult.OK };
                Bdn.DoNotShowAgainCheckBoxVisible = true;
                Bdn.DoNotShowAgainCheckBoxText = "Tekrar Gösterme";
                XtraMessageBox.Show(Bdn).ToString();
                btnYeni_Click(null, null);
            }
            if (ultraTabControl1.SelectedTab.Key=="2")
            {
                btnKaydet.Text = "Kaydet";
                btnYeni_Click(null, null);
            }
            if (ultraTabControl1.SelectedTab.Key == "3")
            {
                btnKaydet.Text = "Kaydet";
                Birim();
                XtraMessageBoxArgs birim = new XtraMessageBoxArgs();
                birim.Caption = "İlk İşlem Uyarısı";
                birim.Text = "Mevcut Güncelleme Yapmak için Listede Olanlara Mouse ile Cift Tıklamalısınız..!";
                birim.Buttons = new DialogResult[] { DialogResult.OK };
                birim.DoNotShowAgainCheckBoxVisible = true;
                birim.DoNotShowAgainCheckBoxText = "Tekrar Gösterme";
                XtraMessageBox.Show(birim).ToString();
                btnYeni_Click(null, null);

            }
            if (ultraTabControl1.SelectedTab.Key =="4")
            {
                btnKaydet.Text = "Kaydet";
                Kdv();
                XtraMessageBoxArgs KDV = new XtraMessageBoxArgs();
                KDV.Caption = "İlk İşlem Uyarısı";
                KDV.Text = "Mevcut Güncelleme Yapmak için Listede Olanlara Mouse ile Cift Tıklamalısınız..!";
                KDV.Buttons = new DialogResult[] { DialogResult.OK };
                KDV.DoNotShowAgainCheckBoxVisible = true;
                KDV.DoNotShowAgainCheckBoxText = "Tekrar Gösterme";
                XtraMessageBox.Show(KDV).ToString();
                btnYeni_Click(null, null);
            }
            if (ultraTabControl1.SelectedTab.Key == "5")
            {
                btnKaydet.Text = "Kaydet";
                Otv();
                XtraMessageBoxArgs OTV = new XtraMessageBoxArgs();
                OTV.Caption = "İlk İşlem Uyarısı";
                OTV.Text = "Mevcut Güncelleme Yapmak için Listede Olanlara Mouse ile Cift Tıklamalısınız..!";
                OTV.Buttons = new DialogResult[] { DialogResult.OK };
                OTV.DoNotShowAgainCheckBoxVisible = true;
                OTV.DoNotShowAgainCheckBoxText = "Tekrar Gösterme";
                XtraMessageBox.Show(OTV).ToString();
                btnYeni_Click(null, null);
            }
            if (ultraTabControl1.SelectedTab.Key == "6")
            {
                btnKaydet.Text = "Kaydet";
                Fiyattipi();
                XtraMessageBoxArgs Fiyattip = new XtraMessageBoxArgs();
                Fiyattip.AutoCloseOptions.Delay = 5000;
                Fiyattip.Caption = "İlk İşlem Uyarısı";
                Fiyattip.Text = "Mevcut Güncelleme Yapmak için Listede Olanlara Mouse ile Cift Tıklamalısınız..!";
                Fiyattip.Buttons = new DialogResult[] { DialogResult.OK };
                Fiyattip.DoNotShowAgainCheckBoxVisible = true;
                Fiyattip.DoNotShowAgainCheckBoxText = "Tekrar Gösterme";
                XtraMessageBox.Show(Fiyattip).ToString();
                btnYeni_Click(null, null);
            }
        }
        void DovizCinsi()
        {
            comboDoviz.DisplayMember = "sAciklama";
            comboDoviz.ValueMember = "sDovizCinsi";
            string query = "select sDovizCinsi, sAciklama from tbDovizCinsi where sDovizCinsi != ''";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            da.Fill(dt);
            comboDoviz.DataSource = dt;
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
            toplam = ViewBedenTumu.RowCount + 1;
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
        void Birim()
        {
            string q = "select sBirimCinsi as [Birim Cinsi] , sAciklama as Açıklama from tbBirimCinsi order  by sAciklama";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            gridBirimCinsi.DataSource = dt;

            
        }
        void Fiyattipi()
        {
            string q = "select sFiyatTipi as [Fiyat Tipi] , sAciklama as [Fiyat Adi], ";
            q = q + " Case nAST when 0 then 'Tümünde' ";
            q = q + "              when 2 then 'Satışlarda' ";
            q = q + "              when 1 then 'Alışlarda' ";
            q = q + "              when 3 then 'Perakende Satışlarda' ";
            q = q + "              when 4 then 'Sadece Listelerde (Pasif Fiyat Tipi)' ";
            q = q + "    end as [Kullanılabilir işlemler],  ";
            q = q + "    bKdvDahilmi as [Kdv Dahil], bDovizeBaglimi as [Dövize Bagli],  ";
            q = q + "    sDovizCinsi as [Döviz Cinsi], sHangiKur as [Mevcut Kur] ";
            q = q + "    from tbFiyatTipi Where sFiyatTipi != ''";
            q = q + "    order by sAciklama ";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridFiyatTipi.DataSource = dt;
        }

        void Kdv()
        {
            string q = "select sKdvTipi as [sKdvTipi],nKdvOrani as [nKdvOrani] from tbKdv where sKdvTipi != ''";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            gridKdv.DataSource = dt;
        }

        void Otv()
        {
            string q = "select sOTVTipi,nOTVOrani from tbOTV where sOTVTipi != ''";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            gridOtv.DataSource = dt;
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
        bool btnBedenAc;
        private void btnBedenYeni_Click(object sender, EventArgs e)
        {
            if (btnBedenAc == false)
            {
                cmbBedenTipi.SelectedIndex = 0;
                cmbBedenTipi.Enabled = false;
                txtBedenAdı.Enabled = true;
                btnBedenAc = true;
                btnBedenYeni.Text = "Vazgeç";
            }
            else
            {

                cmbBedenTipi.Enabled = true;
                txtBedenAdı.Enabled = false;
                btnBedenAc = false;
                btnBedenYeni.Text = "Yeni Oluştur";
            }
        }

        void BedenAc()
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
            conn.DfInsert("", Prm);
            cmbBedenTipi.SelectedIndex = 0;
            txtBedenAdı.Text = null;
            cmbBedenTipi.Enabled = true;
            txtBedenAdı.Enabled = false;
            btnBedenAc = false;
            gridBeden.DataSource = null;
            btnBedenYeni.Text = "Yeni Oluştur";
            Beden();
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
                ultraPanel2.Dock = DockStyle.Fill;
                GridRenk.Visible = false;
                GridRenk.Dock = DockStyle.Bottom;
                pictureBox1.ImageLocation = fileDialog.FileName;
                pictureBox1.Load();
            }

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

        private void btnYeni_Click(object sender, EventArgs e)
        {
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[0])
            {
                btnRenkSec.Text = "Yeni";
                txtRenkKodu.Text = null;
                
                ultraPanel2.Dock = DockStyle.Top;
                GridRenk.Visible = true;
                GridRenk.Dock = DockStyle.Fill;

                btnRenkSec.Enabled = true;
                txtRenkKodu.ReadOnly = false;
                txtRenkKodu.Enabled = true;
                txtRenkKodu.Text = null;
                txtRenkAdi.Text = null;

                pictureBox1.Image = null;
                ultraTabControl1.Tabs[0].Selected = true;
            }
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[1])
            {
                BedenAc();
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
                txtFiyatTipi.Text = null;
                txtFiyatAdi.Text = null;
                comboIslem.SelectedIndex = 0;
                checkKDV.Checked = false;
                checkDoviz.Checked = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (ultraTabControl1.SelectedTab == ultraTabControl1.Tabs[0])
            {
                String hexColor = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(ultraColorPicker1.Color.A, ultraColorPicker1.Color.R, ultraColorPicker1.Color.G, ultraColorPicker1.Color.B));  //returns the hex value
                var color = int.Parse(hexColor.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);

                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                keyValues.Add("@sRenk", txtRenkKodu.Text);
                keyValues.Add("@sRenkAdi", txtRenkAdi.Text);
                keyValues.Add("@lRenkNo", color.ToString());
                keyValues.Add("@ReturnDesc", "");
                var sonuc = conn.DfInsertBack("Renk", keyValues);
                XtraMessageBox.Show(ultraTabControl1.SelectedTab.Text + " sayfasında " + sonuc);
                btnRenkSec.Text = "Yeni";
                pictureBox1.ImageLocation = "";
                pictureBox1.Dispose();
                Renk(null);
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
                Dictionary<string, string> ParamValue = new Dictionary<string, string>();
                if (btnKaydet.Text == "Güncelle")
                {
                    ParamValue.Add("@islem", "1");
                }
                else
                {
                    ParamValue.Add("@islem", "0");
                }
                ParamValue.Add("@sFiyatTipi", txtFiyatTipi.Text);
                ParamValue.Add("@sAciklama", txtFiyatAdi.Text);
                ParamValue.Add("@nAST", comboIslem.SelectedIndex.ToString());
                if (checkKDV.Checked == true)
                {
                    ParamValue.Add("@bKdvDahilmi", "1");
                }
                else
                {
                    ParamValue.Add("@bKdvDahilmi", "0");
                }
                if (checkDoviz.Checked == true)
                {
                    ParamValue.Add("@bDovizeBaglimi", "1");
                    ParamValue.Add("@sDovizCinsi", comboDoviz.SelectedValue.ToString());
                    ParamValue.Add("@sHangiKur", txtDovizKuru.Text);
                }
                else
                {
                    ParamValue.Add("@bDovizeBaglimi", "0");
                    ParamValue.Add("@sDovizCinsi", "");
                    ParamValue.Add("@sHangiKur", "");
                }
                conn.DfInsert("fiyat", ParamValue);
                btnYeni_Click(null, null);
                Fiyattipi();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
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

        private void viewKdv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                txtKdvKodu.Text = viewKdv.GetRowCellValue(viewKdv.FocusedRowHandle, "sKdvTipi").ToString().Replace(" ", "");
                txtKdvOrani.Text = viewKdv.GetRowCellValue(viewKdv.FocusedRowHandle, "nKdvOrani").ToString().Replace(" ", "");
                btnKaydet.Text = "Güncelle";
            }
        }

        private void viewOtv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void viewFiyatTipi_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                txtFiyatTipi.Text = viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Fiyat Tipi").ToString().Replace(" ", "");
                txtFiyatAdi.Text = viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Fiyat Adi").ToString();
                string d = viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Kullanılabilir işlemler").ToString();
                if (d == "Tümünde")
                {
                    comboIslem.SelectedIndex = 0;
                }
                else if (d == "Satışlarda")
                {
                    comboIslem.SelectedIndex = 1;
                }
                else if (d == "Alışlarda")
                {
                    comboIslem.SelectedIndex = 2;
                }
                else if (d == "Perakende Satışlarda")
                {
                    comboIslem.SelectedIndex = 3;
                }
                else if (d == "Sadece Listelerde (Pasif Fiyat Tipi)")
                {
                    comboIslem.SelectedIndex = 4;
                }
                if (viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Kdv Dahil").ToString() == "True") 
                {
                    checkKDV.Checked = true;
                }
                else
	            {                    
                    checkKDV.Checked = false;
                }
                if (viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Dövize Bagli").ToString() == "True") 
                {
                    checkDoviz.Checked = true;
                    groupDoviz.Enabled = true;
                    comboDoviz.SelectedValue = viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Döviz Cinsi").ToString();
                    txtDovizKuru.Text = viewFiyatTipi.GetRowCellValue(viewFiyatTipi.FocusedRowHandle, "Mevcut Kur").ToString();
                }
                else
                {
                    checkDoviz.Checked = false;
                    groupDoviz.Enabled = false;
                }                
                btnKaydet.Text = "Güncelle";
            }
        }

        private void viewBirimCinsi_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void checkDoviz_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDoviz.Checked== true)
            {
                groupDoviz.Enabled = true;
                DovizCinsi();
            }
            else
            {
                groupDoviz.Enabled = false;
            }
        }
        public void Kurlar(string doviz)
        {
            dolar = 0;
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", doviz)).InnerText);
            }
            catch (XmlException xml)
            {
                MessageBox.Show(xml.ToString());
            }
        }
        private void comboDoviz_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kurlar(comboDoviz.SelectedValue.ToString());
            if (comboDoviz.Text != "")
            {
                txtDovizKuru.Text = dolar.ToString();
            }
        }
    }
}