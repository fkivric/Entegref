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

namespace Entegref
{
    public partial class frmTrendyol_Ürün_Aktif : DevExpress.XtraEditors.XtraForm
    {
        public frmTrendyol_Ürün_Aktif()
        {
            InitializeComponent();
        }
        public class Attribute
        {
            public int attributeId { get; set; }
            public string attributeName { get; set; }
            public string attributeValue { get; set; }
            public int attributeValueId { get; set; }
        }

        public class Content
        {
            public bool approved { get; set; }
            public bool archived { get; set; }
            public List<Attribute> attributes { get; set; }
            public string barcode { get; set; }
            public string batchRequestId { get; set; }
            public string brand { get; set; }
            public int brandId { get; set; }
            public string categoryName { get; set; }
            public object createDateTime { get; set; }
            public string description { get; set; }
            public int dimensionalWeight { get; set; }
            public bool hasActiveCampaign { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public object lastPriceChangeDate { get; set; }
            public object lastStockChangeDate { get; set; }
            public object lastUpdateDate { get; set; }
            public int listPrice { get; set; }
            public bool locked { get; set; }
            public bool onSale { get; set; }
            public int pimCategoryId { get; set; }
            public string platformListingId { get; set; }
            public int productCode { get; set; }
            public int productContentId { get; set; }
            public string productMainId { get; set; }
            public int quantity { get; set; }
            public int salePrice { get; set; }
            public string stockCode { get; set; }
            public string stockId { get; set; }
            public string stockUnitType { get; set; }
            public int supplierId { get; set; }
            public string title { get; set; }
            public int vatRate { get; set; }
            public int version { get; set; }
            public bool rejected { get; set; }
            public List<object> rejectReasonDetails { get; set; }
            public bool blacklisted { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
        }

        public class Root
        {
            public int page { get; set; }
            public int size { get; set; }
            public int totalElements { get; set; }
            public int totalPages { get; set; }
            public List<Content> content { get; set; }
        }

        private void frmTrendyol_Ürün_Aktif_Load(object sender, EventArgs e)
        {


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var username = Properties.Settings.Default.TrendyolApi;
            var password = Properties.Settings.Default.TrendyolSecretkey;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));

            var url = "https://api.trendyol.com/sapigw/suppliers/" + Properties.Settings.Default.TrendyolId + "/products?page=0&size=500";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var urunler = new List<Content>();
                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                foreach (var item in myDeserializedClass.content)
                {
                    var ozellikler = new List<Attribute>();
                    var resimler = new List<Image>();
                    var urun = new Content();
                    urun.approved = item.approved;
                    urun.archived = item.archived;
                    foreach (var attribute in item.attributes)
                    {
                        var ozellik = new Attribute();
                        ozellik.attributeId = attribute.attributeId;
                        ozellik.attributeName = attribute.attributeName;
                        ozellik.attributeValue = attribute.attributeValue;
                        ozellik.attributeValueId = attribute.attributeValueId;
                        ozellikler.Add(ozellik);
                    }
                    urun.attributes = ozellikler;
                    urun.barcode = item.barcode;
                    urun.batchRequestId = item.batchRequestId;
                    urun.blacklisted = item.blacklisted;
                    urun.brand = item.brand;
                    urun.brandId = item.brandId;
                    urun.categoryName = item.categoryName;
                    urun.createDateTime = item.createDateTime;
                    urun.description = item.description;
                    urun.dimensionalWeight = item.dimensionalWeight;
                    urun.hasActiveCampaign = item.hasActiveCampaign;
                    urun.id = item.id;
                    foreach (var rsm in item.images)
                    {
                        var resim = new Image();
                        resim.url = rsm.url;
                        resimler.Add(resim);
                    }
                    urun.images = resimler;
                    urun.lastPriceChangeDate = item.lastPriceChangeDate;
                    urun.lastStockChangeDate = item.lastStockChangeDate;
                    urun.lastUpdateDate = item.lastUpdateDate;
                    urun.listPrice = item.listPrice;
                    urun.locked = item.locked;
                    urun.onSale = item.onSale;
                    urun.pimCategoryId = item.pimCategoryId;
                    urun.platformListingId = item.platformListingId;
                    urun.productCode = item.productCode;
                    urun.productContentId = item.productContentId;
                    urun.productMainId = item.productMainId;
                    urun.quantity = item.quantity;
                    urun.rejected = item.rejected;
                    urun.rejectReasonDetails = item.rejectReasonDetails;
                    urun.salePrice = item.salePrice;
                    urun.stockCode = item.stockCode;
                    urun.stockId = item.stockId;
                    urun.stockUnitType = item.stockUnitType;
                    urun.supplierId = item.supplierId;
                    urun.title = item.title;
                    urun.vatRate = item.vatRate;
                    urun.version = item.version;
                    urunler.Add(urun);
                }
                foreach (var item in urunler)
                {
                    if (item.approved == true)
                    {
                        if (item.archived == true)
                        {

                        }

                    }
                }
                gridAktifUrunler.DataSource = urunler;
            }
        }
    }
}