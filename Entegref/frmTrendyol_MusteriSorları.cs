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
using static Entegref.frmKargo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Entegref
{
    public partial class frmTrendyol_MusteriSorları : DevExpress.XtraEditors.XtraForm
    {
        public frmTrendyol_MusteriSorları()
        {
            InitializeComponent();

        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Answer
        {
            public int id { get; set; }
            public object creationDate { get; set; }
            public string text { get; set; }
        }

        public class Content
        {
            public Answer answer { get; set; }
            public string answeredDateMessage { get; set; }
            public object creationDate { get; set; }
            public int customerId { get; set; }
            public int id { get; set; }
            public string imageUrl { get; set; }
            public string productName { get; set; }
            public bool @public { get; set; }
            public bool showUserName { get; set; }
            public string status { get; set; }
            public string text { get; set; }
            public string userName { get; set; }
            public string webUrl { get; set; }
            public string productMainId { get; set; }
        }

        public class Root
        {
            public List<Content> content { get; set; }
            public int page { get; set; }
            public int size { get; set; }
            public int totalElements { get; set; }
            public int totalPages { get; set; }
        }
        private void frmTrendyol_MusteriSorları_Load(object sender, EventArgs e)
        {
            var username = Properties.Settings.Default.TrendyolApi;
            var password = Properties.Settings.Default.TrendyolSecretkey;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));

            var url = "https://api.trendyol.com/sapigw/suppliers/" + Properties.Settings.Default.TrendyolId + "/questions/filter";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                var Sorular = new List<Content>();
                var Cevaplar = new List<Answer>();
                foreach (var item in myDeserializedClass.content)
                {
                    var soru = new Content();
                    var Cevap = new Answer();
                    Cevap.creationDate = item.answer.creationDate;
                    Cevap.id = item.answer.id;
                    Cevap.text = item.answer.text;
                    Cevaplar.Add(Cevap);
                    //repositoryItemLookUpEdit1.DataSource = Cevaplar;
                    soru.answer = Cevap;
                    soru.answeredDateMessage = item.answeredDateMessage;
                    soru.creationDate = item.creationDate;
                    soru.customerId = item.customerId;
                    soru.id = item.id;
                    soru.imageUrl = item.imageUrl;
                    soru.productMainId = item.productMainId;
                    soru.productName = item.productName;
                    soru.@public = item.@public;
                    soru.showUserName = item.showUserName;
                    soru.status = item.status;
                    soru.text = item.text;
                    soru.userName = item.userName;
                    soru.webUrl = item.webUrl;
                    Sorular.Add(soru);

                }
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                gridControl1.DataSource = Sorular;

            }
        }
    }
}