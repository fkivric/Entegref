using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entegref
{
    public partial class frmCicekSepeti_Sinif : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
        DataTable sf1 = new DataTable();
        DataTable sf2 = new DataTable();
        DataTable sf3 = new DataTable();
        DataTable sf4 = new DataTable();
        DataTable sf5 = new DataTable();
        DataTable sf6 = new DataTable();
        DataTable beden = new DataTable();
        DataTable fiyatlar = new DataTable();
        string newid;
        string newidson;
        string newid1 = "00";
        string newid2 = "00";
        string newid3 = "00";
        string newid4 = "00";
        string newid5 = "00";
        string newid6 = "00";


        string sira1="00-0";
        string sira2="00-0";
        string sira3="00-0";
        string sira4="00-0";
        string sira5="00-0";
        string sira6="00-0";

        string lblbeden;
        string lblkavala;
        string lblFiyat;
        string nFiyatlandırma="";
        string sKavalaTipi="";
        string sBedenTipi="";
        string sRenkKodu="";
        bool nRenk=false;

        public class tbBedenTipi
        {
            public string sBedenTipi { get; set; }
            public string sAciklama { get; set; }
            public string sBeden1 { get; set; }
            public string sBeden2 { get; set; }
            public string sBeden3 { get; set; }
            public string sBeden4 { get; set; }
            public string sBeden5 { get; set; }
            public string sBeden6 { get; set; }
            public string sBeden7 { get; set; }
            public string sBeden8 { get; set; }
            public string sBeden9 { get; set; }
            public string sBeden10 { get; set; }
            public string sBeden11 { get; set; }
            public string sBeden12 { get; set; }
            public string sBeden13 { get; set; }
            public string sBeden14 { get; set; }
            public string sBeden15 { get; set; }
            public string Name => $"{sBedenTipi} {sAciklama} {sBeden1} {sBeden1} {sBeden2} {sBeden3} {sBeden4} {sBeden5} {sBeden6} {sBeden7} {sBeden8} {sBeden9} {sBeden10} {sBeden11} {sBeden12} {sBeden13} {sBeden14} {sBeden15}";
        }

        public class tbKavala
        {
            public string sKavalaTipi { get; set; }
            public string sAciklama { get; set; }
            public string sKavala1 { get; set; }
            public string sKavala2 { get; set; }
            public string sKavala3 { get; set; }
            public string sKavala4 { get; set; }
            public string sKavala5 { get; set; }
            public string sKavala6 { get; set; }
            public string sKavala7 { get; set; }
            public string sKavala8 { get; set; }
            public string sKavala9 { get; set; }
            public string sKavala10 { get; set; }
            public string sKavala11 { get; set; }
            public string sKavala12 { get; set; }
            public string sKavala13 { get; set; }
            public string sKavala14 { get; set; }
            public string sKavala15 { get; set; }
            public string Name => $"{sKavalaTipi} {sAciklama} {sKavala1} {sKavala1} {sKavala2} {sKavala3} {sKavala4} {sKavala5} {sKavala6} {sKavala7} {sKavala8} {sKavala9} {sKavala10} {sKavala11} {sKavala12} {sKavala13} {sKavala14} {sKavala15}";
        }

        public frmCicekSepeti_Sinif()
        {
            InitializeComponent();
            panel1.Size = new Size(panel1.Width, 25);
            this.Size = new Size(701, 287);
        }
        private void frmStokSinifi_Load(object sender, EventArgs e)
        {
            cmbsinif1.DisplayMember = "sAciklama";
            cmbsinif1.ValueMember = "sSinifKodu";
            Dictionary<string, string> Prm = new Dictionary<string, string>();
            Prm.Add("@sira","7");
            Prm.Add("@parentid","0");
            sf1 = conn.DfQuery("Sinif2", Prm);
            cmbsinif1.DataSource = sf1;

        }

        private void cmbsinif1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsinif1.SelectedValue.ToString() != "00-0")
            {
                cmbsinif2.DisplayMember = "sAciklama";
                cmbsinif2.ValueMember = "sSinifKodu";
                Dictionary<string, string> Prm = new Dictionary<string, string>();
                Prm.Add("@sira", "8");
                Prm.Add("@parentid", cmbsinif1.SelectedValue.ToString().Substring(cmbsinif1.SelectedValue.ToString().IndexOf("-")+1).Replace(" ", ""));
                sf2 = conn.DfQuery("Sinif2", Prm);
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
                Prm.Add("@sira", "9");
                Prm.Add("@parentid", cmbsinif2.SelectedValue.ToString().Substring(cmbsinif2.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf3 = conn.DfQuery("Sinif2", Prm);
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
                Prm.Add("@sira", "10");
                Prm.Add("@parentid", cmbsinif3.SelectedValue.ToString().Substring(cmbsinif3.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf4 = conn.DfQuery("Sinif2", Prm);
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
                Prm.Add("@sira", "11");
                Prm.Add("@parentid", cmbsinif4.SelectedValue.ToString().Substring(cmbsinif4.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf5 = conn.DfQuery("Sinif2", Prm);
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
                Prm.Add("@sira", "12");
                Prm.Add("@parentid", cmbsinif5.SelectedValue.ToString().Substring(cmbsinif5.SelectedValue.ToString().IndexOf("-") + 1).Replace(" ", ""));
                sf6 = conn.DfQuery("Sinif2", Prm);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbsinif1.SelectedValue.ToString() == "00-0")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.Caption = "İşlem Sırası Uyarı";
                args.Text = "Ürün Sınıfı 1 Seçilmedi.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                XtraMessageBox.Show(args).ToString();
            }
            else if (cmbsinif2.SelectedValue.ToString() == "00-0")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.Caption = "İşlem Sırası Uyarı";
                args.Text = "Ürün Sınıfı 2 Seçilmedi.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                XtraMessageBox.Show(args).ToString();
            }
            else if (cmbsinif3.SelectedValue != null)
            {
                if (cmbsinif3.SelectedValue.ToString() == "00-0")
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.Caption = "İşlem Sırası Uyarı";
                    args.Text = "Ürün Sınıfı 3 Seçilmedi.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    XtraMessageBox.Show(args).ToString();

                }
                else
                {
                    if (cmbsinif1.SelectedValue.ToString().Substring(0, cmbsinif1.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                    {
                        newid1 = cmbsinif1.SelectedValue.ToString().Substring(0, cmbsinif1.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                        sira1 = cmbsinif1.SelectedValue.ToString();
                    }
                    if (cmbsinif2.SelectedValue != null)
                    {
                        if (cmbsinif2.SelectedValue.ToString().Substring(0, cmbsinif2.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                        {
                            newid2 = cmbsinif2.SelectedValue.ToString().Substring(0, cmbsinif2.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                            sira2 = cmbsinif2.SelectedValue.ToString();
                        }
                    }
                    if (cmbsinif3.SelectedValue != null)
                    {

                        if (cmbsinif3.SelectedValue.ToString().Substring(0, cmbsinif3.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                        {
                            newid3 = cmbsinif3.SelectedValue.ToString().Substring(0, cmbsinif3.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                            sira3 = cmbsinif3.SelectedValue.ToString();
                        }
                    }

                    if (cmbsinif4.SelectedValue != null)
                    {
                        if (cmbsinif4.SelectedValue.ToString().Substring(0, cmbsinif4.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                        {
                            newid4 = cmbsinif4.SelectedValue.ToString().Substring(0, cmbsinif4.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                            sira4 = cmbsinif4.SelectedValue.ToString();
                        }
                    }

                    if (cmbsinif5.SelectedValue != null)
                    {
                        if (cmbsinif5.SelectedValue.ToString().Substring(0, cmbsinif5.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                        {
                            newid5 = cmbsinif5.SelectedValue.ToString().Substring(0, cmbsinif5.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                            sira5 = cmbsinif5.SelectedValue.ToString();
                        }
                    }

                    if (cmbsinif6.SelectedValue != null)
                    {
                        if (cmbsinif6.SelectedValue.ToString().Substring(0, cmbsinif6.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                        {
                            newid6 = cmbsinif6.SelectedValue.ToString().Substring(0, cmbsinif6.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                            sira6 = cmbsinif6.SelectedValue.ToString();
                        }
                    }

                    newid = newid1 + newid2.Replace("00", "") + newid3.Replace("00", ""); //+ newid4.Replace("00","") + newid5.Replace("00", "") + newid6.Replace("00", "");
                    Dictionary<string, string> ID = new Dictionary<string, string>();
                    ID.Add("@temporaryID", newid);
                    var dt = conn.DfQuery("Entegref_New_sModel", ID);
                    newidson = dt.Rows[0]["sModel"].ToString();

                    grpSinif.Enabled = false;
                    grpOzellik.Enabled = true;

                    cmbFiyatlandırma.Enabled = true;
                    cmbFiyatlandırma.ValueMember = "nFiyatlandirma";
                    cmbFiyatlandırma.DisplayMember = "sAciklama";
                    string query = "select * from tbFiyatlandirma";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    ad.Fill(fiyatlar);
                    connection.Close();
                    cmbFiyatlandırma.DataSource = fiyatlar;

                    DataRowView vrow = (DataRowView)cmbFiyatlandırma.SelectedItem;
                    DataRow row = vrow.Row;
                    lblFiyat = row.ItemArray[1].ToString();
                }
            }
            else
            {
                if (cmbsinif1.SelectedValue.ToString().Substring(0, cmbsinif1.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                {
                    newid1 = cmbsinif1.SelectedValue.ToString().Substring(0, cmbsinif1.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                    sira1 = cmbsinif1.SelectedValue.ToString();
                }
                if (cmbsinif2.SelectedValue != null)
                {
                    if (cmbsinif2.SelectedValue.ToString().Substring(0, cmbsinif2.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                    {
                        newid2 = cmbsinif2.SelectedValue.ToString().Substring(0, cmbsinif2.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                        sira2 = cmbsinif2.SelectedValue.ToString();
                    }
                }
                if (cmbsinif3.SelectedValue != null)
                {

                    if (cmbsinif3.SelectedValue.ToString().Substring(0, cmbsinif3.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                    {
                        newid3 = cmbsinif3.SelectedValue.ToString().Substring(0, cmbsinif3.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                        sira3 = cmbsinif3.SelectedValue.ToString();
                    }
                    
                }

                if (cmbsinif4.SelectedValue != null)
                {
                    if (cmbsinif4.SelectedValue.ToString().Substring(0, cmbsinif4.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                    {
                        newid4 = cmbsinif4.SelectedValue.ToString().Substring(0, cmbsinif4.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                        sira4 = cmbsinif4.SelectedValue.ToString();
                    }
                }

                if (cmbsinif5.SelectedValue != null)
                {
                    if (cmbsinif5.SelectedValue.ToString().Substring(0, cmbsinif5.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                    {
                        newid5 = cmbsinif5.SelectedValue.ToString().Substring(0, cmbsinif5.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                        sira5 = cmbsinif5.SelectedValue.ToString();
                    }
                }

                if (cmbsinif6.SelectedValue != null)
                {
                    if (cmbsinif6.SelectedValue.ToString().Substring(0, cmbsinif6.SelectedValue.ToString().IndexOf("-")).Replace(" ", "") != "00")
                    {
                        newid6 = cmbsinif6.SelectedValue.ToString().Substring(0, cmbsinif6.SelectedValue.ToString().IndexOf("-")).Replace(" ", "");
                        sira6 = cmbsinif6.SelectedValue.ToString();
                    }
                }
                newid = newid1 + newid2.Replace("00", "") + newid3.Replace("00", ""); //+ newid4.Replace("00","") + newid5.Replace("00", "") + newid6.Replace("00", "");
                Dictionary<string, string> ID = new Dictionary<string, string>();
                ID.Add("@temporaryID", newid);
                var dt = conn.DfQuery("Entegref_New_sModel", ID);
                newidson = dt.Rows[0]["sModel"].ToString();

                grpSinif.Enabled = false;
                grpOzellik.Enabled = true;

                cmbFiyatlandırma.Enabled = true;
                cmbFiyatlandırma.ValueMember = "nFiyatlandirma";
                cmbFiyatlandırma.DisplayMember = "sAciklama";
                string query = "select * from tbFiyatlandirma";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                ad.Fill(fiyatlar);
                connection.Close();
                cmbFiyatlandırma.DataSource = fiyatlar;

                DataRowView vrow = (DataRowView)cmbFiyatlandırma.SelectedItem;
                DataRow row = vrow.Row;
                lblFiyat = row.ItemArray[1].ToString();
            }

        }

        private void chkRenk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRenk.Checked == true)
            {
                grpBeden.Enabled = true;
                nRenk = true;
            }
            else
            {
                grpBeden.Enabled = false;
                chkBeden.Checked = false;
                nRenk = false;
            }
        }

        private void chkBeden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeden.Checked == true)
            {
                cmbBeden.Enabled = true;
                var persons = new List<tbBedenTipi>();

                using (var connection = new SqlConnection(Properties.Settings.Default.connectionstring))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from tbBedenTipi";// where sBedenTipi != ''";
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var person = new tbBedenTipi
                            {
                                sBedenTipi = reader.GetString(0),
                                sAciklama = reader.GetString(1),
                                sBeden1 = reader.GetString(2),
                                sBeden2 = reader.GetString(3),
                                sBeden3 = reader.GetString(4),
                                sBeden4 = reader.GetString(5),
                                sBeden5 = reader.GetString(6),
                                sBeden6 = reader.GetString(7),
                                sBeden7 = reader.GetString(8),
                                sBeden8 = reader.GetString(9),
                                sBeden9 = reader.GetString(10),
                                sBeden10 = reader.GetString(11),
                                sBeden11 = reader.GetString(12),
                                sBeden12 = reader.GetString(13),
                                sBeden13 = reader.GetString(14),
                                sBeden14 = reader.GetString(15),
                                sBeden15 = reader.GetString(16),
                            };
                            persons.Add(person);
                        }
                    }
                }

                cmbBeden.ValueMember = "sBedenTipi";
                cmbBeden.DisplayMember = "Name";
                cmbBeden.DataSource = persons;
            }
            else
            {
                cmbBeden.DataSource = null;
                cmbBeden.Enabled = false;
                tbBedenTipi tbBedenTipi = new tbBedenTipi();
            }

        }

        private void cmbBeden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBeden.SelectedValue.ToString() == "   ")
            {

            }
            else
            {
                string q = "select sBedenTipi,sAciklama from tbBedenTipi where sBedenTipi = '" + cmbBeden.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(q, connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                ad.Fill(dt);
                connection.Close();

                lblbeden = dt.Rows[0][1].ToString();
                sBedenTipi = dt.Rows[0][0].ToString();
            }
        }
        private void chkKavala_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKavala.Checked == true)
            {
                cmbKavala.Enabled = true;
                var kavalas = new List<tbKavala>();

                using (var connection = new SqlConnection(Properties.Settings.Default.connectionstring))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from tbKavala";// where sKavalaTipi != ''";
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var kavala= new tbKavala
                            {
                                sKavalaTipi = reader.GetString(0),
                                sAciklama = reader.GetString(1),
                                sKavala1 = reader.GetString(2),
                                sKavala2 = reader.GetString(3),
                                sKavala3 = reader.GetString(4),
                                sKavala4 = reader.GetString(5),
                                sKavala5 = reader.GetString(6),
                                sKavala6 = reader.GetString(7),
                                sKavala7 = reader.GetString(8),
                                sKavala8 = reader.GetString(9),
                                sKavala9 = reader.GetString(10),
                                sKavala10 = reader.GetString(11),
                                sKavala11 = reader.GetString(12),
                                sKavala12 = reader.GetString(13),
                                sKavala13 = reader.GetString(14),
                                sKavala14 = reader.GetString(15),
                                sKavala15 = reader.GetString(16),
                            };
                            kavalas.Add(kavala);
                        }
                    }
                }

                cmbKavala.ValueMember = "sKavalaTipi";
                cmbKavala.DisplayMember = "Name";
                cmbKavala.DataSource = kavalas;
            }
            else
            {
                chkKavala.Checked = false;
            }
        }

        private void cmbKavala_SelectedIndexChanged(object sender, EventArgs e)
        {

            string q = "select sKavalaTipi,sAciklama from tbKavala where sKavalaTipi = '" + cmbKavala.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(q, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            ad.Fill(dt);
            connection.Close();
            
            lblkavala = dt.Rows[0][1].ToString();
            sKavalaTipi = dt.Rows[0][0].ToString();

        }

        private void cmbFiyatlandırma_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFiyat = cmbFiyatlandırma.SelectedText;
            nFiyatlandırma = cmbFiyatlandırma.SelectedValue.ToString();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmStokAc.sModel = newidson;
            frmStokAc.sinifsira1 = sira1;
            frmStokAc.sinifsira2 = sira2;
            frmStokAc.sinifsira3 = sira3;
            frmStokAc.sinifsira4 = sira4;
            frmStokAc.sinifsira5 = sira5;
            frmStokAc.sinifsira6 = sira6;
            frmStokAc.nFiyatlandirma = nFiyatlandırma;
            frmStokAc.Fiyatlandirma = lblFiyat;

            if (chkRenk.Checked == true)
            {
                frmStokAc.Renk = nRenk;
                frmStokAc.nStokTipi = "1";
                if (chkBeden.Checked == true)
                {
                    frmStokAc.BedenTipi = sBedenTipi;
                    frmStokAc.Beden = lblbeden;
                    frmStokAc.nStokTipi = "2";
                    if (chkKavala.Checked==true)
                    {
                        frmStokAc.KavalaTipi = sKavalaTipi;
                        frmStokAc.Kavala = lblkavala;
                        frmStokAc.nStokTipi = "3";
                    }
                    else
                    {
                        frmStokAc.KavalaTipi = "";
                    }
                }
                else
                {
                    frmStokAc.BedenTipi = null;
                    frmStokAc.KavalaTipi = null;
                    frmStokAc.Beden = "Beden Yok";
                    frmStokAc.Kavala = "Kavala Yok";
                }

                frmRenk frmRenk = new frmRenk(sKavalaTipi, sBedenTipi);
                frmRenk.ShowDialog();
                this.Hide();
            }
            else
            {
                frmStokAc.Renk = false;
                frmStokAc.BedenTipi = "";
                frmStokAc.KavalaTipi = "";
                frmStokAc.nStokTipi = "0";
            }
            this.Close();
            this.Dispose();
        }

        private void txtSinif_TextChanged(object sender, EventArgs e)
        {
            datagridYol.DataSource = null;
            Dictionary<string, string> PRM = new Dictionary<string, string>();
            PRM.Add("@Text", txtSinif.Text);
            var dt = conn.DfQuery("CicekSepeti_Category_Select_Text", PRM);
            datagridYol.DataSource = dt;
        }
        private void btnBulAc_Click(object sender, EventArgs e)
        {
            datagridYol.Visible = true;
            label4.Visible = true;
            txtSinif.Visible = true;
            panel1.Size = new Size(693,194);
            this.Size = new Size(701, 458);
            btnBulAc.Visible = false;
        }
    }
}
