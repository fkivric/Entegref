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
        public string kavalaTipi;
        public string bedenTipi;
        private string hexValue;
        private int decValue;
        renkbeden rnb;

        public frmRenk(string _kavala,string _beden)
        {
            kavalaTipi = _kavala;
            bedenTipi = _beden;
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
            this.Width = 486;
            Ekle();
            setUpEventHandlers();
            if (bedenTipi == null)
            {
                btnOk.Text = "Renk Ekle";
            }
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
            btnOk.Enabled = false;
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
                    if (secilirenkler!="")
                    {
                        secilirenkler = secilirenkler.ToString() + "," + secilen.ToString();
                    }
                    else
                    {
                        secilirenkler = secilen.ToString();
                    }
                }
                if (bedenTipi != null && bedenTipi != "")
                {
                    this.Width = 1450;
                    ultraPanel1.Enabled = false;
                    ultraPanel2.Enabled = false;
                    ultraPanel5.Visible = true;
                    btnOk.Enabled = false;

                    Dictionary<string, string> Values = new Dictionary<string, string>();
                    if (kavalaTipi != null)
                    {
                        Values.Add("@sKavalaTipi", kavalaTipi);
                    }
                    else
                    {
                        Values.Add("@sKavalaTipi", "");
                    }
                    if (bedenTipi != null)
                    {
                        Values.Add("@sBedenTipi", bedenTipi);
                    }
                    else
                    {
                        Values.Add("@sBedenTipi", "");
                    }
                    Values.Add("@sRenkKodu", secilirenkler);
                    var tablo = conn.DfQuery("UrunRenkBedenKavalaSec", Values);
                    dataGridView1.DataSource = tablo;
                    dataGridView1.AutoResizeColumns();
                }
                frmStokAc.sRenkKodu = secilirenkler;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (bedenTipi != null && bedenTipi != "")
            {
                for (int r = 0; r < dataGridView1.Rows.Count; r++)
                {
                    var dd = frmStokAc.sinifsira1.IndexOf("-");
                    string bedensira;
                    int stoksayi = 0;
                    var srenk = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    var skavala = dataGridView1.Rows[r].Cells[3].Value.ToString().Replace(" ", "");
                    for (int c = 4; c < dataGridView1.ColumnCount; c++)
                    {
                        var bedenvar = dataGridView1.Rows[r].Cells[c].Value.ToString();
                        Dictionary<string, string> Renkler = new Dictionary<string, string>();
                        Renkler.Add("@sModel", frmStokAc.sModel.ToString());
                        Renkler.Add("@BedenTipi", frmStokAc.BedenTipi);
                        Renkler.Add("@KavalaTipi", frmStokAc.Kavala);
                        Renkler.Add("@sRenkKodu", srenk);
                        if (bedenvar.ToString() == "True")
                        {
                            bedensira = dataGridView1.Columns[c].HeaderText.ToString();
                            Renkler.Add("@sBeden", bedensira);
                            stoksayi++;
                        }
                        else
                        {
                            Renkler.Add("@sBeden", "");
                        }
                        Renkler.Add("@Kavala", skavala);
                        Renkler.Add("@sinif1", frmStokAc.sinifsira1.ToString().Substring(frmStokAc.sinifsira1.IndexOf("-")+1).Replace("00", ""));
                        Renkler.Add("@sinif2", frmStokAc.sinifsira2.ToString().Substring(frmStokAc.sinifsira2.IndexOf("-")+1).Replace("00", ""));
                        Renkler.Add("@sinif3", frmStokAc.sinifsira3.ToString().Substring(frmStokAc.sinifsira3.IndexOf("-")+1).Replace("00", ""));
                        if (frmStokAc.sinifsira4.ToString() != "")
                        {
                            Renkler.Add("@sinif4", frmStokAc.sinifsira4.ToString().Substring(frmStokAc.sinifsira4.IndexOf("-")+1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif4", "");
                        }
                        if (frmStokAc.sinifsira5.ToString() != "")
                        {
                            Renkler.Add("@sinif5", frmStokAc.sinifsira5.ToString().Substring(frmStokAc.sinifsira5.IndexOf("-")+1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif5", "");
                        }
                        if (frmStokAc.sinifsira6.ToString() != "")
                        {
                            Renkler.Add("@sinif6", frmStokAc.sinifsira6.ToString().Substring(frmStokAc.sinifsira6.IndexOf("-")+1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif6", "");
                        }
                        if (frmStokAc.sinifsira7.ToString() != "")
                        {
                            Renkler.Add("@sinif7", frmStokAc.sinifsira7.ToString().Substring(frmStokAc.sinifsira7.IndexOf("-") + 1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif7", "");
                        }
                        if (frmStokAc.sinifsira8.ToString() != "")
                        {
                            Renkler.Add("@sinif8", frmStokAc.sinifsira8.ToString().Substring(frmStokAc.sinifsira8.IndexOf("-") + 1).Replace("00", ""));

                        }
                        else
                        {
                            Renkler.Add("@sinif8", "");
                        }
                        if (frmStokAc.sinifsira9.ToString() != "")
                        {
                            Renkler.Add("@sinif9", frmStokAc.sinifsira3.ToString().Substring(frmStokAc.sinifsira9.IndexOf("-") + 1).Replace("00", ""));
                        }
                        else
                        {

                            Renkler.Add("@sinif8", "");

                        }
                        if (frmStokAc.sinifsira10.ToString() != "")
                        {
                            Renkler.Add("@sinif10", frmStokAc.sinifsira10.ToString().Substring(frmStokAc.sinifsira10.IndexOf("-") + 1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif10", "");
                        }
                        if (frmStokAc.sinifsira11.ToString() != "")
                        {
                            Renkler.Add("@sinif11", frmStokAc.sinifsira11.ToString().Substring(frmStokAc.sinifsira11.IndexOf("-") + 1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif11", "");
                        }
                        if (frmStokAc.sinifsira12.ToString() != "")
                        {
                            Renkler.Add("@sinif12", frmStokAc.sinifsira12.ToString().Substring(frmStokAc.sinifsira12.IndexOf("-") + 1).Replace("00", ""));
                        }
                        else
                        {
                            Renkler.Add("@sinif12", "");
                        }
                        conn.DfInsert("Entegref_Add_Item_Property", Renkler);
                    }
                }
            }
            this.Close();
            this.Dispose();
        }
    }
}