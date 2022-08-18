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
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace Entegref
{
    public partial class frmTrendyol_catogory : DevExpress.XtraEditors.XtraForm
    {
        public frmTrendyol_catogory()
        {
            InitializeComponent();
        }
        public class Brand
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Marka
        {
            public List<Brand> brands { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }
            public object parentId { get; set; }
            public List<SubCategory> subCategories { get; set; }
        }

        public class Root
        {
            public List<Category> categories { get; set; }
        }

        public class SubCategory
        {
            public int id { get; set; }
            public string name { get; set; }
            public int parentId { get; set; }
            public List<SubCategory> subCategories { get; set; }
        }

        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.trendyol.com/sapigw-product/product-categories");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                //DataTable dt = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));

                DataTable sinif1 = new DataTable();
                DataTable sinif2 = new DataTable();
                DataTable sinif3 = new DataTable();
                DataTable sinif4 = new DataTable();
                DataTable sinif5 = new DataTable();
                DataTable sinif6 = new DataTable();
                var persons = new List<Category>();
                var persons2 = new List<SubCategory>();
                var persons3 = new List<SubCategory>();
                var persons4 = new List<SubCategory>();
                var persons5 = new List<SubCategory>();
                var persons6 = new List<SubCategory>();
                var persons7 = new List<SubCategory>();
                foreach (var item in myDeserializedClass.categories)
                {
                    var person = new Category();
                    person.id = item.id;
                    person.name = item.name;
                    person.parentId = item.parentId;
                    foreach (var item2 in item.subCategories)
                    {
                        var p1 = new SubCategory();
                        p1.id = item2.id;
                        p1.name = item2.name;
                        p1.parentId = item2.parentId;
                        foreach (var item3 in item2.subCategories)
                        {
                            var p2 = new SubCategory();
                            p2.id = item3.id;
                            p2.name = item3.name;
                            p2.parentId = item3.parentId;
                            foreach (var item4 in item3.subCategories)
                            {
                                var p3 = new SubCategory();
                                p3.id = item4.id;
                                p3.name = item4.name;
                                p3.parentId = item4.parentId;
                                foreach (var item5 in item4.subCategories)
                                {
                                    var p4 = new SubCategory();
                                    p4.id = item5.id;
                                    p4.name = item5.name;
                                    p4.parentId = item5.parentId;
                                    foreach (var item6 in item5.subCategories)
                                    {
                                        var p5 = new SubCategory();
                                        p5.id = item6.id;
                                        p5.name = item6.name;
                                        p5.parentId = item6.parentId;
                                        foreach (var item7 in item6.subCategories)
                                        {
                                            var p6 = new SubCategory();
                                            p6.id = item7.id;
                                            p6.name = item7.name;
                                            p6.parentId = item7.parentId;
                                            p6.subCategories = item7.subCategories;
                                            persons7.Add(p6);
                                        }
                                        p5.subCategories = item6.subCategories;
                                        persons6.Add(p5);
                                    }
                                    p4.subCategories = item5.subCategories;
                                    persons5.Add(p4);
                                }
                                p3.subCategories = item4.subCategories;
                                persons4.Add(p3);
                            }
                            p2.subCategories = item3.subCategories;
                            persons3.Add(p2);
                        }
                        p1.subCategories = item2.subCategories;
                        persons2.Add(p1);
                    }
                    person.subCategories = item.subCategories;
                    persons.Add(person);
                }
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                ListtoDataTableConverter converter2 = new ListtoDataTableConverter();
                ListtoDataTableConverter converter3 = new ListtoDataTableConverter();
                ListtoDataTableConverter converter4 = new ListtoDataTableConverter();
                ListtoDataTableConverter converter5 = new ListtoDataTableConverter();
                ListtoDataTableConverter converter6 = new ListtoDataTableConverter();
                sinif1 = converter.ToDataTable(persons2);
                sinif2 = converter.ToDataTable(persons3);
                sinif3 = converter.ToDataTable(persons4);
                sinif4 = converter.ToDataTable(persons5);
                sinif5 = converter.ToDataTable(persons6);
                sinif6 = converter.ToDataTable(persons7);

                dataGridView1.DataSource = persons;
                dataGridView2.DataSource = sinif1;
                dataGridView3.DataSource = sinif2;
                dataGridView4.DataSource = sinif3;
                dataGridView5.DataSource = sinif4;
                dataGridView6.DataSource = sinif5;
                dataGridView7.DataSource = sinif6;


            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTrendyol_Attributes attributes = new frmTrendyol_Attributes(387);
            attributes.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.trendyol.com/sapigw/brands");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            var MRK = new List<Brand>();
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Marka myDeserializedClass = JsonConvert.DeserializeObject<Marka>(result);
                foreach (var item in myDeserializedClass.brands)
                {
                    var dt = new Brand();
                    dt.id = item.id;
                    dt.name = item.name;
                    MRK.Add(dt);
                }
                dataGridView8.DataSource = MRK;
            }
        }
    }
}