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
using DevExpress.XtraBars.Docking2010;
using System.Drawing.Drawing2D;

namespace Entegref
{
    public partial class frmRenk : DevExpress.XtraEditors.XtraForm
    {
        public string kavala;
        public string beden;

        private string hexValue;
        private int decValue;

        public frmRenk(string _kavala,string _beden)
        {
            kavala = _kavala;
            beden = _beden;
            InitializeComponent();
        }
        class Nebular
        {
            public string sRenk { get; set; }
            public string sRenkAdi { get; set; }
        }

        private static Nebular[] nebulae;
        private static bool selected;

        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);

        private void frmRenk_Load(object sender, EventArgs e)
        {
            this.Width = 600;
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, btnOk.Width - 4, btnOk.Height - 4);
            btnOk.Region = new Region(p);
            Ekle();
            setUpEventHandlers();
        }
        private void Ekle()
        {
            nebulae = new[]
              {
                new Nebular {sRenk="000",sRenkAdi="SARI"},
                new Nebular {sRenk="001",sRenkAdi="KIRMIZ"},
                new Nebular {sRenk="002",sRenkAdi="MAVI"},
                new Nebular {sRenk="003",sRenkAdi="YEŞİL",},
                new Nebular {sRenk="004",sRenkAdi="SİYAH"},
                new Nebular {sRenk="004",sRenkAdi="BEYAZ"},
                new Nebular {sRenk="005",sRenkAdi="MOR"},
                new Nebular {sRenk="006",sRenkAdi="TURKUAZ"},
                new Nebular {sRenk="007",sRenkAdi="KAREMEL"},
                new Nebular {sRenk="008",sRenkAdi="TURUNCU"},
                new Nebular {sRenk="009",sRenkAdi="EFLATUN"},
                new Nebular {sRenk="010",sRenkAdi="GRİ"},
                new Nebular {sRenk="011",sRenkAdi="ZAMBAK"},
                new Nebular {sRenk="012",sRenkAdi="AY IŞIĞI"},
                new Nebular {sRenk="0l3",sRenkAdi="FİL DİŞİ"},
                new Nebular {sRenk="014",sRenkAdi="VELDE"},
                new Nebular {sRenk="015",sRenkAdi="ŞARAP"},
                new Nebular {sRenk="016",sRenkAdi="TURKUAZ"},
                new Nebular {sRenk="017",sRenkAdi="EBRULİ"},
                new Nebular {sRenk="018",sRenkAdi="MELİSA"},
                new Nebular {sRenk="018",sRenkAdi="HAZAN"},
            };

            foreach (Nebular s in nebulae)
            {
                ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
            }
        }
        private void searchData(string searchTerm)
        {
            ListRenkler.Items.Clear();
            foreach (Nebular s in nebulae)
            {
                if (s.sRenk.ToLower().Contains(searchTerm.ToLower()) || s.sRenkAdi.ToLower().Contains(searchTerm.ToLower()))
                {
                    if (ListSecili.Items.Count > 0)
                    {
                        for (int i = 0; i < ListSecili.Items.Count; i++)
                        {
                            if (s.sRenk != ListSecili.Items[i].SubItems[0].Text)
                            {
                                if (ListRenkler.Items.Count > 0)
                                {
                                    for (int ii = 0; ii < ListRenkler.Items.Count; ii++)
                                    {
                                        if (ListRenkler.Items[ii].SubItems[0].Text != s.sRenk)
                                        {
                                            ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                                        }
                                    }
                                }
                                else
                                {
                                    ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                                }
                                                              
                            }
                        }
                    }
                    else
                    {
                        ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                    }
                }
            }
        }
        private void setUpEventHandlers()
        {
            ListRenkler.ItemSelectionChanged += ListRenkler_ItemSelectionChanged;
            txtRenkAra.TextChanged += txtRenkAra_TextChanged;
        }
        private void ListRenkler_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                selected = true;
            }
            else
            {
                selected = false;
            }
        }
        private void txtRenkAra_TextChanged(object sender, EventArgs e)
        {
            searchData(txtRenkAra.Text);
        }

        private void data()
        {
            string q = "select sRenk,sRenkAdi from tbRenk where sRenk != ''";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand(q, connection);
            SqlDataAdapter da = new SqlDataAdapter(q, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ListRenkler.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] row = { dt.Rows[i]["sRenk"].ToString(), dt.Rows[i]["sRenkAdi"].ToString() };
                var listViewItem = new ListViewItem(row);
                ListRenkler.Items.Add(listViewItem);
            }
            connection.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (Nebular s in nebulae)
            {
                foreach (var item in ListRenkler.SelectedItems)
                {
                    string tt = ListRenkler.SelectedItems[0].SubItems[0].Text;
                    if (s.sRenk == ListRenkler.SelectedItems[0].SubItems[0].Text)
                    {
                        ListSecili.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                        ListRenkler.Items.RemoveAt(ListRenkler.SelectedItems[0].Index);
                    }
                }

            }            
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (Nebular s in nebulae)
            {
                foreach (var item in ListSecili.SelectedItems)
                {
                    string tt = ListSecili.SelectedItems[0].SubItems[0].Text;
                    if (s.sRenk == ListSecili.SelectedItems[0].SubItems[0].Text)
                    {
                        ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                        ListSecili.Items.RemoveAt(ListSecili.SelectedItems[0].Index);
                    }
                }
            }        
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            foreach (Nebular s in nebulae)
            {
                ListSecili.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                ListRenkler.Items.Clear();  
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            foreach (Nebular s in nebulae)
            {
                ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi }));
                ListSecili.Items.Clear();                
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string secilirenkler = "";
            string secilen = "";
            if (ListSecili.Items.Count < 0)
            {
                XtraMessageBox.Show("Renk Seçimi Yapmadınız");
            }
            else
            {
                for (int i = 0; i < ListSecili.Items.Count; i++)
                {
                    secilen = ListSecili.Items[i].SubItems[0].Text;
                    secilirenkler = secilirenkler.ToString() +","+ secilen.ToString();
                }
                this.Width = 1450;
                ultraPanel1.Enabled = false;
                ultraPanel2.Enabled = false;
                ultraPanel5.Visible = true;
                ultraPanel6.Visible = true;

                Dictionary<string, string> Values = new Dictionary<string, string>();
                if (kavala != null)
                {
                    Values.Add("@sKavalaTipi", kavala);
                }
                else
                {
                    Values.Add("@sKavalaTipi", "");
                }
                if (beden != null)
                {
                    Values.Add("@sBedenTipi", beden);
                }
                else
                {
                    Values.Add("@sBedenTipi", "");
                }
                Values.Add("@sRenkKodu", secilirenkler);
                var tablo = conn.DfQuery("UrunRenkBedenKavalaSec", Values);
                int stun = 20-tablo.Columns.Count;
                for (int i = 0; i < tablo.Columns.Count; i++)
                {
                    if (i == 5)
                    {
                        gridColumn5.Caption = tablo.Columns[i].ToString();
                        gridColumn5.FieldName = tablo.Columns[i].ToString();
                        repositoryItemCheckEdit1.ValueChecked = false;
                    }
                    if (i == 6)
                    {
                        gridColumn6.Caption = tablo.Columns[i].ToString();
                        gridColumn6.FieldName = tablo.Columns[i].ToString();
                        repositoryItemCheckEdit2.ValueChecked = false;
                    }
                    if (i == 7)
                    {
                        gridColumn7.Caption = tablo.Columns[i].ToString();
                        gridColumn7.FieldName = tablo.Columns[i].ToString();
                        repositoryItemCheckEdit3.ValueChecked = false;
                    }
                    if (i == 8)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn8.Visible = false;
                        }
                        else
                        {
                            gridColumn8.Caption = tablo.Columns[i].ToString();
                            gridColumn8.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 9)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn9.Visible = false;
                        }
                        else
                        {
                            gridColumn9.Caption = tablo.Columns[i].ToString();
                            gridColumn9.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 10)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn10.Visible = false;
                        }
                        else
                        {
                            gridColumn10.Caption = tablo.Columns[i].ToString();
                            gridColumn10.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 11)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn11.Visible = false;
                        }
                        else
                        {
                            gridColumn11.Caption = tablo.Columns[i].ToString();
                            gridColumn11.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 12)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn12.Visible = false;
                        }
                        else
                        {
                            gridColumn12.Caption = tablo.Columns[i].ToString();
                            gridColumn12.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 13)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn13.Visible = false;
                        }
                        else
                        {
                            gridColumn13.Caption = tablo.Columns[i].ToString();
                            gridColumn13.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 14)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn14.Visible = false;
                        }
                        else
                        {
                            gridColumn14.Caption = tablo.Columns[i].ToString();
                            gridColumn14.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 15)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn15.Visible = false;
                        }
                        else
                        {
                            gridColumn15.Caption = tablo.Columns[i].ToString();
                            gridColumn15.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 16)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn16.Visible = false;
                        }
                        else
                        {
                            gridColumn16.Caption = tablo.Columns[i].ToString();
                            gridColumn16.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 17)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn17.Visible = false;
                        }
                        else
                        {
                            gridColumn17.Caption = tablo.Columns[i].ToString();
                            gridColumn17.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 18)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn18.Visible = false;
                        }
                        else
                        {
                            gridColumn18.Caption = tablo.Columns[i].ToString();
                            gridColumn18.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                    if (i == 19)
                    {
                        if (tablo.Columns[i].ColumnName.ToString() == "")
                        {
                            gridColumn19.Visible = false;
                        }
                        else
                        {
                            gridColumn19.Caption = tablo.Columns[i].ToString();
                            gridColumn19.FieldName = tablo.Columns[i].ToString();
                        }
                    }
                }
                if (stun > 0)
                {
                    for (int i = 0; i < stun; i++)
                    {
                        if (i == 0)
                        {
                            gridColumn19.Visible = false;
                        }
                        if (i == 1)
                        {
                            gridColumn18.Visible = false;
                        }
                        if (i == 2)
                        {
                            gridColumn17.Visible = false;
                        }
                        if (i == 3)
                        {
                            gridColumn16.Visible = false;
                        }
                        if (i == 4)
                        {
                            gridColumn15.Visible = false;
                        }
                    }
                }
                gridControl1.DataSource = tablo;
            }
        }
    }
}