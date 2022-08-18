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

namespace Entegref
{
    public partial class frmTrendyol_Attributes : DevExpress.XtraEditors.XtraForm
    {
        int CatagoryID = 0;
        public frmTrendyol_Attributes(int ctagoryID)
        {
            InitializeComponent();
            CatagoryID = ctagoryID;
        }
        
        public class Attribute
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class AttributeValue
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class CategoryAttribute
        {
            public bool allowCustom { get; set; }
            public Attribute attribute { get; set; }
            public List<AttributeValue> attributeValues { get; set; }
            public int categoryId { get; set; }
            public bool required { get; set; }
            public bool varianter { get; set; }
            public bool slicer { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public List<CategoryAttribute> categoryAttributes { get; set; }
        }

        private void frmTrendyol_Attributes_Load(object sender, EventArgs e)
        {
            string url = "https://api.trendyol.com/sapigw/product-categories/"+ CatagoryID.ToString() + "/attributes";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "{\"DatabaseName\":\"" + Properties.Settings.Default.TrendyolId + "\"," +
            //                  "\"UserGroupCode\":\"" + Properties.Settings.Default.TrendyolApi + "\"," +
            //                  "\"UserName\":\"" + Properties.Settings.Default.TrendyolSecretkey + "\",";

            //    streamWriter.Write(json);


            //}
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                int sira = 0;
                int x1 = 10;
                int y1 = -20;
                int x2 = 200;
                int y2 = -20;
                string name1= "lblbaslik";
                string name2 = "txt";
                string name3 = "cmb";
                foreach (var item in myDeserializedClass.categoryAttributes)
                {
                    sira += 1;

                    if (item.allowCustom == false)
                    {
                        y1 += 30;
                        Label lbl = new Label()
                        {
                            Location = new Point(x1, y1),
                            Name = name1 + sira.ToString(),
                            Text = item.attribute.name
                            
                        };
                        y2 += 30;
                        System.Windows.Forms.ComboBox cmb1 = new System.Windows.Forms.ComboBox()
                        {
                            Location = new Point(x2, y2),
                            Size = new Size(300, 20),
                            Name = name3+item.attribute.name+sira.ToString()
                            
                        };
                        this.Controls.Add(lbl);
                        this.Controls.Add(cmb1);
                        cmb1.DisplayMember ="name";
                        cmb1.ValueMember = "id";

                        var persons = new List<Attribute>();
                        foreach (var attributeValues in item.attributeValues)
                        {
                            var d = new Attribute();
                            d.id = attributeValues.id;
                            d.name = attributeValues.name;
                            persons.Add(d);
                        }
                        cmb1.DataSource = persons;



                    }
                    else
                    {
                        y1 += 30;
                        Label label1 = new Label()
                        {
                            Location = new Point(x1, y1),
                            Name = name1 + sira.ToString(),
                            Text = item.attribute.name
                    };
                        y2 += 30;
                        TextBox Renk = new TextBox()
                        {
                            Location = new Point(x2, y2),
                            Size = new Size(300, 20),
                            Name = name2+item.attribute.name + sira.ToString()
                        };
                        this.Controls.Add(label1);
                        this.Controls.Add(Renk);
                    }
                }
            }
        }
    }
}