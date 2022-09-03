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
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Entegref
{
    public partial class frmCicekSepeti_Category : DevExpress.XtraEditors.XtraForm
    {
        public frmCicekSepeti_Category()
        {
            InitializeComponent();
        }
        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }
            public object parentCategoryId { get; set; }
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
            public int parentCategoryId { get; set; }
            public List<SubCategory> subCategories { get; set; }
        }
        public class AttributeValue
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class CategoryAttribute
        {
            public int attributeId { get; set; }
            public string attributeName { get; set; }
            public bool required { get; set; }
            public bool varianter { get; set; }
            public string type { get; set; }
            public List<AttributeValue> attributeValues { get; set; }
        }

        public class Root2
        {
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public List<CategoryAttribute> categoryAttributes { get; set; }
        }
        DataTable sinif1 = new DataTable();
        DataTable CategoryFull = new DataTable();
        SqlConnectionObject conn = new SqlConnectionObject();

        int row = 0;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = null;
            sinif1.Columns.Clear();
            sinif1.Rows.Clear();
            sinif1.Columns.Add("categoryId");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://apis.ciceksepeti.com/api/v1/Categories");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("X-Api-key", Properties.Settings.Default.CicekSepetiApi_key);
            httpWebRequest.Method = "Get";
            CategoryFull.Columns.Clear();
            CategoryFull.Rows.Clear();
            CategoryFull.Columns.Add("id");
            CategoryFull.Columns.Add("name");
            CategoryFull.Columns.Add("parentCategoryId");
            CategoryFull.Columns.Add("subCategories");
            CategoryFull.Columns.Add("sira");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var Categories = new List<Category>();
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
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
                    person.parentCategoryId = item.parentCategoryId;
                    foreach (var item2 in item.subCategories)
                    {
                        var p1 = new SubCategory();
                        p1.id = item2.id;
                        p1.name = item2.name;
                        p1.parentCategoryId = item2.parentCategoryId;
                        foreach (var item3 in item2.subCategories)
                        {
                            var p2 = new SubCategory();
                            p2.id = item3.id;
                            p2.name = item3.name;
                            p2.parentCategoryId = item3.parentCategoryId;
                            foreach (var item4 in item3.subCategories)
                            {
                                var p3 = new SubCategory();
                                p3.id = item4.id;
                                p3.name = item4.name;
                                p3.parentCategoryId = item4.parentCategoryId;
                                foreach (var item5 in item4.subCategories)
                                {
                                    var p4 = new SubCategory();
                                    p4.id = item5.id;
                                    p4.name = item5.name;
                                    p4.parentCategoryId = item5.parentCategoryId;
                                    foreach (var item6 in item5.subCategories)
                                    {
                                        var p5 = new SubCategory();
                                        p5.id = item6.id;
                                        p5.name = item6.name;
                                        p5.parentCategoryId = item6.parentCategoryId;
                                        foreach (var item7 in item6.subCategories)
                                        {
                                            var p6 = new SubCategory();
                                            p6.id = item7.id;
                                            p6.name = item7.name;
                                            p6.parentCategoryId = item7.parentCategoryId;
                                            p6.subCategories = item7.subCategories;
                                            persons7.Add(p6);
                                            sinif1.Rows.Add(new object[] { item7.id});
                                            CategoryFull.Rows.Add(new object[] { item7.id,item7.name,item7.parentCategoryId,item7.subCategories,"7"});
                                        }
                                        p5.subCategories = item6.subCategories;
                                        persons6.Add(p5);
                                        sinif1.Rows.Add(new object[] { item6.id });
                                        CategoryFull.Rows.Add(new object[] { item6.id, item6.name, item6.parentCategoryId, item6.subCategories,"6" });
                                    }
                                    p4.subCategories = item5.subCategories;
                                    persons5.Add(p4);
                                    sinif1.Rows.Add(new object[] { item5.id });
                                    CategoryFull.Rows.Add(new object[] { item5.id, item5.name, item5.parentCategoryId, item5.subCategories ,"5"});
                                }
                                p3.subCategories = item4.subCategories;
                                persons4.Add(p3);
                                sinif1.Rows.Add(new object[] { item4.id });
                                CategoryFull.Rows.Add(new object[] { item4.id, item4.name, item4.parentCategoryId, item4.subCategories ,"4"});
                            }
                            p2.subCategories = item3.subCategories;
                            persons3.Add(p2);
                            sinif1.Rows.Add(new object[] { item3.id });
                            CategoryFull.Rows.Add(new object[] { item3.id, item3.name, item3.parentCategoryId, item3.subCategories ,"3"});
                        }
                        p1.subCategories = item2.subCategories;
                        persons2.Add(p1);
                        sinif1.Rows.Add(new object[] { item2.id });
                        CategoryFull.Rows.Add(new object[] { item2.id, item2.name, item2.parentCategoryId, item2.subCategories ,"2"});
                    }
                    person.subCategories = item.subCategories;
                    persons.Add(person);
                    sinif1.Rows.Add(new object[] { item.id });
                    CategoryFull.Rows.Add(new object[] { item.id, item.name, item.parentCategoryId, item.subCategories,"1" });
                }
                gridControl2.DataSource = persons;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var Categories = new List<CategoryAttribute>();
            for (int i = 0; i < sinif1.Rows.Count; i++)
            {
                var url = "https://apis.ciceksepeti.com/api/v1/categories/"+ sinif1.Rows[i][0].ToString()+ "/attributes";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("X-Api-key", Properties.Settings.Default.CicekSepetiApi_key);
                httpWebRequest.Method = "Get";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Root2 myDeserializedClass = JsonConvert.DeserializeObject<Root2>(result);
                    foreach (var item in myDeserializedClass.categoryAttributes)
                    {
                        var ats = new List<AttributeValue>();
                        var Ca = new CategoryAttribute();
                        Ca.attributeId = item.attributeId;
                        Ca.attributeName = item.attributeName;
                        Ca.required = item.required;
                        Ca.varianter = item.varianter;
                        Ca.type = item.type;
                        foreach (var item2 in item.attributeValues)
                        {
                            var at = new AttributeValue();
                            at.id = item2.id;
                            at.name = item2.name;
                            ats.Add(at);
                        }
                        Ca.attributeValues = ats;
                        Categories.Add(Ca);
                    }
                }
            }
            gridControl1.DataSource = Categories;
        }
        private BackgroundWorker _backgroundWorker;
        private ManualResetEvent _workerCompletedEvent = new ManualResetEvent(false);
        private const string READY_TEXT = "Hazır";
        private void executeBackground(Action doWorkAction, Action progressAction = null, Action completedAction = null)
        {
            try
            {
                if (_backgroundWorker != null)
                {


                    if (_backgroundWorker.IsBusy)
                    {
                        //XtraMessageBox.Show("Her oturum açıldığında 1 işlem yapacak. Eğer bu girişteki ilk işlemse uygulama çalışmaktadır. Lütfen Bekleyiniz");
                        return;
                    }
                }
                _backgroundWorker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true
                };
                _backgroundWorker.DoWork += (x, y) =>
                {
                    try
                    {
                        doWorkAction.Invoke();
                    }
                    catch (Exception ex)
                    {
                        y.Cancel = true;
                        XtraMessageBox.Show("Bilinmeyen Hata. Detay : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // throw;
                    }
                };
                if (progressAction != null)
                {
                    _backgroundWorker.ProgressChanged += (x, y) =>
                    {
                        progressAction.Invoke();
                    };
                }
                if (completedAction != null)
                {
                    _backgroundWorker.RunWorkerCompleted += (x, y) =>
                    {
                        completedAction.Invoke();
                    };
                }
                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception)
            {

            }

        }
        private void completeProgress()
        {
            try
            {
                _backgroundWorker.Dispose();
                _backgroundWorker = null;
                if (!this.Enabled)
                {
                    this.Enabled = true;
                }

            }
            finally
            {
                //this.Cursor = Cursors.Default;
                _workerCompletedEvent.Set();

            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmProgresBr progressForm = new frmProgresBr()
            {
                Start = 0,
                Finish = row,
                Position = 0,
            };

            int success = 0;
            int error = 0;
            this.Enabled = false;

            executeBackground(
       () =>
       {
           progressForm.Show(this);
           row = CategoryFull.Rows.Count;
           for (int i = 0; i < CategoryFull.Rows.Count; i++)
            {
                Dictionary<string, string> CC = new Dictionary<string, string>();
                CC.Add("@id", CategoryFull.Rows[i][0].ToString());
                CC.Add("@name", CategoryFull.Rows[i][1].ToString());
                CC.Add("@parent_id", CategoryFull.Rows[i][2].ToString());
                //CC.Add("@sira", CategoryFull.Rows[i][4].ToString());
                conn.NTBLInsert("Cieksepeti_Category_Add", CC);
            }

       },
                    null,
                     () =>
                     {
                         completeProgress();
                         progressForm.Hide(this);
                     });
        }

    }
}