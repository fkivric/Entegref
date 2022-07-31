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

namespace Entegref
{
    public partial class frmRenk : DevExpress.XtraEditors.XtraForm
    {
        List<Data> Items = new List<Data>();
        public frmRenk()
        {
            InitializeComponent();
        }
        public class tbRenk
        {
            public string sRenk { get; set; }
            public string sRenkAdi { get; set; }

            public tbRenk(string sRenk_, string sRenkAdi_)
            {
                this.sRenk = sRenk_;
                this.sRenkAdi = sRenkAdi_;
            }
        }
        class Data
        {
            public string sRenk { get; set; }
            public string sRenkAdi { get; set; }
        }
        class Nebular
        {
            public string sRenk { get; set; }
            public string sRenkAdi { get; set; }
        }
        private static Nebular[] nebulae;
        private tbRenk[] renkler;
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionstring);
        private void frmRenk_Load(object sender, EventArgs e)
        {
            string q = "select sRenk,sRenkAdi from tbRenk where sRenk != ''";
            ListRenkler.Items.Clear(); //www.yazilimkodlama.com
            connection.Open();
            SqlCommand cmd = new SqlCommand(q, connection);
            SqlDataAdapter da = new SqlDataAdapter(q, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            nebulae = new[]
            {
                new Nebular {sRenk=dt.Rows[0]["sRenk"].ToString(),sRenkAdi =dt.Rows[0]["sRenkAdi"].ToString()},
                new Nebular {sRenk=dt.Rows[1]["sRenk"].ToString(),sRenkAdi =dt.Rows[1]["sRenkAdi"].ToString()},
                new Nebular {sRenk=dt.Rows[2]["sRenk"].ToString(),sRenkAdi =dt.Rows[2]["sRenkAdi"].ToString()},
                new Nebular {sRenk=dt.Rows[3]["sRenk"].ToString(),sRenkAdi =dt.Rows[3]["sRenkAdi"].ToString()},

            };
            foreach (Nebular s in nebulae)
            {
                ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi}));
            }
        
            connection.Close();
            ListRenkler.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListRenkler.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
        }
            
    
        private void searchData(string searchTerm)
        {
            ListRenkler.Items.Clear();
            foreach (Nebular s in nebulae)
            {
                if (s.sRenk.ToLower().Contains(searchTerm.ToLower()) || s.sRenkAdi.ToLower().Contains(searchTerm.ToLower()))
                {
                    ListRenkler.Items.Add(new ListViewItem(new[] { s.sRenk, s.sRenkAdi}));
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox1.Text == null)
            {
                frmRenk_Load(null, null);
            }
            ListRenkler.Items.Clear();
            searchData(textBox1.Text);
            //listView1.Items.Clear(); // clear list items before adding 
            //                         // filter the items match with search key and add result to list view 
            //listView1.Items.AddRange(Items.Where(i => string.IsNullOrEmpty(textBox1.Text) || i.sRenkAdi.StartsWith(textBox1.Text)).Select(i => new ListViewItem()).ToArray());
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                //MessageBox.Show("Renk Kodu : " + ListRenkler.SelectedItems[0].SubItems[0].Text + "\r\n" +
                //    "Renk Adi : " + ListRenkler.SelectedItems[0].SubItems[1].Text); 
                selected = true;
            }
            else
            {
                selected = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (var item in ListRenkler.SelectedItems)
            {
                MessageBox.Show("Renk Kodu : " + ListRenkler.SelectedItems[0].SubItems[0].Text + "\r\n" +
                    "Renk Adi : " + ListRenkler.SelectedItems[0].SubItems[1].Text);
            }
        }
    }
}