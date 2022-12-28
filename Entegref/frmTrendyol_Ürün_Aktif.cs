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
using static Entegref.frmTrendyol_catogory;

namespace Entegref
{
    public partial class frmTrendyol_Ürün_Aktif : DevExpress.XtraEditors.XtraForm
    {
        public frmTrendyol_Ürün_Aktif()
        {
            InitializeComponent();
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        public class Attribute
        {
            public int attributeId { get; set; }
            public string attributeName { get; set; }
            public string attributeValue { get; set; }
            public int attributeValueId { get; set; }
        }
        public class Attribute2
        {
            public string barcode { get; set; }
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
            public string blacklistReason { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
        }
        public class Image2
        {
            public int productCode { get; set; }
            public string barcode { get; set; }
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


        public class AttAttribute
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class AttAttributeValue
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class AttCategoryAttribute
        {
            public bool allowCustom { get; set; }
            public AttAttribute attribute { get; set; }
            public List<AttAttributeValue> attributeValues { get; set; }
            public int categoryId { get; set; }
            public bool required { get; set; }
            public bool varianter { get; set; }
            public bool slicer { get; set; }
        }
        public class AttRoot
        {
            public int id { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public List<AttCategoryAttribute> categoryAttributes { get; set; }
        }
        DataTable Urunaktif = new DataTable();
        DataTable Urunbiten = new DataTable();
        DataTable Urunpasif = new DataTable();
        DataTable Urunkitli = new DataTable();
        DataTable Urunarsiv = new DataTable();
        DataTable Urunler = new DataTable();


        DataTable Ozlaktif = new DataTable();
        DataTable Ozlpasif = new DataTable();
        DataTable Ozlbiten = new DataTable();
        DataTable Ozlarsiv = new DataTable();
        DataTable Ozlkitli = new DataTable();

        DataTable Rsmaktif = new DataTable();
        DataTable Rsmbiten = new DataTable();
        DataTable Rsmpasif = new DataTable();
        DataTable Rsmkitli = new DataTable();
        DataTable Rsmarsiv = new DataTable();

        DataTable Ozellikler = new DataTable();
        DataTable Resimler = new DataTable();





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
                var UrunHepsi = new List<Content>();
                var aktif = new List<Content>();
                var biten = new List<Content>();
                var pasif = new List<Content>();
                var kitli = new List<Content>();
                var arsiv = new List<Content>();


                var aktifozl = new List<Attribute2>();
                var bitenozl = new List<Attribute2>();
                var pasifozl = new List<Attribute2>();
                var kitliozl = new List<Attribute2>();
                var arsivozl = new List<Attribute2>();


                var aktifrsm = new List<Image2>();
                var bitenrsm = new List<Image2>();
                var pasifrsm = new List<Image2>();
                var kitlirsm = new List<Image2>();
                var arsivrsm = new List<Image2>();

                var ozellikler2 = new List<Attribute2>();
                var resimler2 = new List<Image2>();

                var result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                foreach (var item in myDeserializedClass.content)
                {
                    var ozellikler = new List<Attribute>();
                    var resimler = new List<Image>();
                    var urun = new Content();
                    urun.approved = item.approved;
                    urun.onSale = item.onSale;
                    urun.archived = item.archived;
                    urun.locked = item.locked;
                    urun.blacklisted = item.blacklisted;
                    urun.blacklistReason = item.blacklistReason;
                    urun.stockCode = item.stockCode;
                    urun.stockId = item.stockId;
                    urun.barcode = item.barcode;
                    urun.title = item.title;
                    urun.brand = item.brand;
                    urun.brandId = item.brandId;
                    urun.quantity = item.quantity;
                    urun.lastStockChangeDate = item.lastStockChangeDate;
                    urun.stockUnitType = item.stockUnitType;
                    urun.vatRate = item.vatRate;
                    urun.categoryName = item.categoryName;
                    urun.pimCategoryId = item.pimCategoryId;
                    foreach (var attribute in item.attributes)
                    {
                        var ozellik = new Attribute();
                        ozellik.attributeId = attribute.attributeId;
                        ozellik.attributeName = attribute.attributeName;
                        ozellik.attributeValue = attribute.attributeValue;
                        ozellik.attributeValueId = attribute.attributeValueId;
                        ozellikler.Add(ozellik);


                        var ozellik2 = new Attribute2();
                        ozellik2.barcode = item.barcode;
                        ozellik2.attributeId = attribute.attributeId;
                        ozellik2.attributeName = attribute.attributeName;
                        ozellik2.attributeValue = attribute.attributeValue;
                        ozellik2.attributeValueId = attribute.attributeValueId;
                        if (item.pimCategoryId != 4943 && attribute.attributeId != 338)
                        {
                            if (item.approved == true && item.onSale == true && item.archived == false && item.locked == false && item.blacklisted == false && item.quantity > 0 && item.listPrice > 0 && item.salePrice > 0)
                            {
                                aktifozl.Add(ozellik2);
                            }
                            else if (item.approved == false && item.onSale == false && item.archived == false && item.locked == false && item.blacklisted == false)
                            {
                                pasifozl.Add(ozellik2);
                            }
                            else if (item.approved == true && item.onSale == false && item.archived == false && item.locked == false && item.blacklisted == false && item.quantity == 0 && item.listPrice > 0 && item.salePrice > 0)
                            {
                                bitenozl.Add(ozellik2);
                            }
                            else if (item.archived == true)
                            {
                                arsivozl.Add(ozellik2);
                            }
                            else if (item.blacklisted == true)
                            {
                                kitliozl.Add(ozellik2);
                            }
                        }
                        ozellikler2.Add(ozellik2);
                    }
                    urun.attributes = ozellikler;
                    urun.description = item.description;
                    urun.listPrice = item.listPrice;
                    urun.salePrice = item.salePrice;
                    urun.lastPriceChangeDate = item.lastPriceChangeDate;
                    urun.supplierId = item.supplierId;
                    urun.rejected = item.rejected;
                    urun.rejectReasonDetails = item.rejectReasonDetails;
                    urun.createDateTime = item.createDateTime;
                    urun.platformListingId = item.platformListingId;
                    urun.productCode = item.productCode;
                    urun.productContentId = item.productContentId;
                    urun.productMainId = item.productMainId;
                    urun.lastUpdateDate = item.lastUpdateDate;
                    urun.hasActiveCampaign = item.hasActiveCampaign;
                    urun.dimensionalWeight = item.dimensionalWeight;
                    urun.batchRequestId = item.batchRequestId;
                    urun.id = item.id;
                    foreach (var rsm in item.images)
                    {
                        var resim = new Image();
                        resim.url = rsm.url;
                        resimler.Add(resim);

                        var resim2 = new Image2();
                        resim2.productCode = item.productCode;
                        resim2.barcode = item.barcode;
                        resim2.url = rsm.url;
                        if (item.approved == true && item.onSale == true && item.archived == false && item.locked == false && item.blacklisted == false && item.quantity > 0 && item.listPrice > 0 && item.salePrice > 0)
                        {
                            aktifrsm.Add(resim2);
                        }
                        else if (item.approved == false && item.onSale == false && item.archived == false && item.locked == false && item.blacklisted == false)
                        {
                            pasifrsm.Add(resim2);
                        }
                        else if (item.approved == true && item.onSale == false && item.archived == false && item.locked == false && item.blacklisted == false && item.quantity == 0 && item.listPrice > 0 && item.salePrice > 0)
                        {
                            bitenrsm.Add(resim2);
                        }
                        else if (item.archived == true)
                        {
                            arsivrsm.Add(resim2);
                        }
                        else if (item.blacklisted == true)
                        {
                            kitlirsm.Add(resim2);
                        }
                        resimler2.Add(resim2);
                    }
                    urun.images = resimler;
                    if (item.approved == true && item.onSale == true && item.archived == false && item.locked == false && item.blacklisted == false && item.quantity > 0 && item.listPrice > 0 && item.salePrice > 0)
                    {
                        aktif.Add(urun);
                    }
                    else if (item.approved == false && item.onSale == false && item.archived == false && item.locked == false && item.blacklisted == false)
                    {
                        pasif.Add(urun);
                    }
                    else if (item.approved == true && item.onSale == false && item.archived == false && item.locked == false && item.blacklisted == false && item.quantity == 0 && item.listPrice > 0 && item.salePrice > 0)
                    {
                        biten.Add(urun);
                    }
                    else if (item.archived == true)
                    {
                        arsiv.Add(urun);
                    }
                    else if (item.blacklisted == true)
                    {
                        kitli.Add(urun);
                    }
                    UrunHepsi.Add(urun);
                }
                ListtoDataTableConverter converter = new ListtoDataTableConverter();

                Urunler = converter.ToDataTable(UrunHepsi);
                Urunaktif = converter.ToDataTable(aktif);
                Urunpasif = converter.ToDataTable(pasif);
                Urunbiten = converter.ToDataTable(biten);
                Urunarsiv = converter.ToDataTable(arsiv);
                Urunkitli = converter.ToDataTable(kitli);

                Ozlaktif = converter.ToDataTable(aktifozl);
                Ozlpasif = converter.ToDataTable(pasifozl);
                Ozlbiten = converter.ToDataTable(bitenozl);
                Ozlarsiv = converter.ToDataTable(arsivozl);
                Ozlkitli = converter.ToDataTable(kitliozl);

                Rsmaktif = converter.ToDataTable(aktifrsm);
                Rsmpasif = converter.ToDataTable(pasifrsm);
                Rsmbiten = converter.ToDataTable(bitenrsm);
                Rsmarsiv = converter.ToDataTable(arsivrsm);
                Rsmkitli = converter.ToDataTable(kitlirsm);

                Ozellikler = converter.ToDataTable(ozellikler2);
                Resimler = converter.ToDataTable(resimler2);
                gridAktifUrunler.DataSource = aktif;
                gridControl1.DataSource = biten;
                gridControl2.DataSource = pasif;
                gridControl3.DataSource = kitli;
                gridControl4.DataSource = arsiv;

                ultraTabControl1.Tabs[0].Text = "Satuşta Olan Ürünler";
                ultraTabControl1.Tabs[1].Text = "Tükenen Ürünler";
                ultraTabControl1.Tabs[2].Text = "Satışta Olmayan Ürünler";
                ultraTabControl1.Tabs[3].Text = "Kilitli Ürünler";
                ultraTabControl1.Tabs[4].Text = "Arşivlenen Ürünler";
                ultraTabControl1.Tabs[0].Text = ultraTabControl1.Tabs[0].Text + " - " + viewAktifUrunler.DataRowCount.ToString() + "  Adet ";
                ultraTabControl1.Tabs[1].Text = ultraTabControl1.Tabs[1].Text + " - " + gridView1.DataRowCount.ToString() + "  Adet ";
                ultraTabControl1.Tabs[2].Text = ultraTabControl1.Tabs[2].Text + " - " + gridView2.DataRowCount.ToString() + "  Adet ";
                ultraTabControl1.Tabs[3].Text = ultraTabControl1.Tabs[3].Text + " - " + gridView3.DataRowCount.ToString() + "  Adet ";
                ultraTabControl1.Tabs[4].Text = ultraTabControl1.Tabs[4].Text + " - " + gridView4.DataRowCount.ToString() + "  Adet ";


            }
        }

        
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DataTable brkdn = new DataTable();
            brkdn.Columns.Add("barkod");
            brkdn.Columns.Add("pimCategoryId");
            if (ultraTabControl1.SelectedTab.Key == "0")
            {
                for (int i = 0; i < Urunaktif.Rows.Count; i++)
                {
                    Dictionary<string, string> Stok = new Dictionary<string, string>();
                    Stok.Add("@barcode", Urunaktif.Rows[i]["barcode"].ToString());
                    Stok.Add("@brand", Urunaktif.Rows[i]["brand"].ToString());
                    Stok.Add("@brandId", Urunaktif.Rows[i]["brandId"].ToString());
                    Stok.Add("@categoryName", Urunaktif.Rows[i]["categoryName"].ToString());
                    Stok.Add("@description", Urunaktif.Rows[i]["description"].ToString());
                    Stok.Add("@dimensionalWeight", Urunaktif.Rows[i]["dimensionalWeight"].ToString());
                    Stok.Add("@id", Urunaktif.Rows[i]["id"].ToString());
                    Stok.Add("@listPrice", Urunaktif.Rows[i]["listPrice"].ToString());
                    Stok.Add("@pimCategoryId", Urunaktif.Rows[i]["pimCategoryId"].ToString());
                    Stok.Add("@platformListingId", Urunaktif.Rows[i]["platformListingId"].ToString());
                    Stok.Add("@productCode", Urunaktif.Rows[i]["productCode"].ToString());
                    Stok.Add("@productContentId", Urunaktif.Rows[i]["productContentId"].ToString());
                    Stok.Add("@productMainId", Urunaktif.Rows[i]["productMainId"].ToString());
                    Stok.Add("@quantity", Urunaktif.Rows[i]["quantity"].ToString());
                    Stok.Add("@salePrice", Urunaktif.Rows[i]["salePrice"].ToString());
                    Stok.Add("@stockCode", Urunaktif.Rows[i]["stockCode"].ToString());
                    Stok.Add("@stockId", Urunaktif.Rows[i]["stockId"].ToString());
                    Stok.Add("@stockUnitType", Urunaktif.Rows[i]["stockUnitType"].ToString());
                    Stok.Add("@title", Urunaktif.Rows[i]["title"].ToString());
                    Stok.Add("@vatRate", Urunaktif.Rows[i]["vatRate"].ToString());
                    Stok.Add("@version", Urunaktif.Rows[i]["version"].ToString());
                    Stok.Add("@sKullaniciAdi", frmLogin.username);
                    brkdn.Rows.Add(new object[] { Urunaktif.Rows[i]["barcode"].ToString(), Urunaktif.Rows[i]["pimCategoryId"].ToString() });
                    conn.DfInsert("Entegref_Create_item_web_new", Stok);
                    //conn.DfInsert("Entegref_Create_item_web_Create", Stok);
                }
                int sira = 0;
                for (int brksira = 0; brksira < brkdn.Rows.Count; brksira++)
                {
                    var barkod = brkdn.Rows[brksira]["barkod"].ToString();
                    var catogoryID = brkdn.Rows[brksira]["pimCategoryId"].ToString();

                    string url = "https://api.trendyol.com/sapigw/product-categories/" + catogoryID + "/attributes";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "Get";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        AttRoot myDeserializedClass = JsonConvert.DeserializeObject<AttRoot>(result);
                        foreach (var attr in myDeserializedClass.categoryAttributes)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", barkod);
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", attr.attribute.id.ToString());
                            Ozl.Add("@attributeName", attr.attribute.name.ToString());
                            Ozl.Add("@attributeValueId", "0");
                            Ozl.Add("@attributeValue", "");
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }

                    for (int oz = 0; oz < Ozlaktif.Rows.Count; oz++)
                    {
                        if (Ozlaktif.Rows[oz].ItemArray[0].ToString() == barkod)
                        {
                            sira++;
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Ozlaktif.Rows[oz].ItemArray[0].ToString());
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", Ozlaktif.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@attributeName", Ozlaktif.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@attributeValueId", Ozlaktif.Rows[oz].ItemArray[4].ToString());
                            Ozl.Add("@attributeValue", Ozlaktif.Rows[oz].ItemArray[3].ToString());
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }
                    for (int oz = 0; oz < Rsmaktif.Rows.Count; oz++)
                    {
                        if (Rsmaktif.Rows[oz].ItemArray[1].ToString() == barkod)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Rsmaktif.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@sLocation", "WEB");
                            Ozl.Add("@sResimAdi", Rsmaktif.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@sKullaniciAdi", frmLogin.username);
                            conn.DfInsert("Entegref_Create_item_web_Resim", Ozl);
                        }
                    }
                }
            }
            else if (ultraTabControl1.SelectedTab.Key == "1")
            {
                brkdn.Rows.Clear();
                for (int i = 0; i < Urunbiten.Rows.Count; i++)
                {
                    Dictionary<string, string> Stok = new Dictionary<string, string>();
                    Stok.Add("@barcode", Urunbiten.Rows[i]["barcode"].ToString());
                    Stok.Add("@brand", Urunbiten.Rows[i]["brand"].ToString());
                    Stok.Add("@brandId", Urunbiten.Rows[i]["brandId"].ToString());
                    Stok.Add("@categoryName", Urunbiten.Rows[i]["categoryName"].ToString());
                    Stok.Add("@description", Urunbiten.Rows[i]["description"].ToString());
                    Stok.Add("@dimensionalWeight", Urunbiten.Rows[i]["dimensionalWeight"].ToString());
                    Stok.Add("@id", Urunbiten.Rows[i]["id"].ToString());
                    Stok.Add("@listPrice", Urunbiten.Rows[i]["listPrice"].ToString());
                    Stok.Add("@pimCategoryId", Urunbiten.Rows[i]["pimCategoryId"].ToString());
                    Stok.Add("@platformListingId", Urunbiten.Rows[i]["platformListingId"].ToString());
                    Stok.Add("@productCode", Urunbiten.Rows[i]["productCode"].ToString());
                    Stok.Add("@productContentId", Urunbiten.Rows[i]["productContentId"].ToString());
                    Stok.Add("@productMainId", Urunbiten.Rows[i]["productMainId"].ToString());
                    Stok.Add("@quantity", Urunbiten.Rows[i]["quantity"].ToString());
                    Stok.Add("@salePrice", Urunbiten.Rows[i]["salePrice"].ToString());
                    Stok.Add("@stockCode", Urunbiten.Rows[i]["stockCode"].ToString());
                    Stok.Add("@stockId", Urunbiten.Rows[i]["stockId"].ToString());
                    Stok.Add("@stockUnitType", Urunbiten.Rows[i]["stockUnitType"].ToString());
                    Stok.Add("@title", Urunbiten.Rows[i]["title"].ToString());
                    Stok.Add("@vatRate", Urunbiten.Rows[i]["vatRate"].ToString());
                    Stok.Add("@version", Urunbiten.Rows[i]["version"].ToString());
                    Stok.Add("@sKullaniciAdi", frmLogin.username);
                    brkdn.Rows.Add(new object[] { Urunbiten.Rows[i]["barcode"].ToString(), Urunbiten.Rows[i]["pimCategoryId"].ToString() });
                    conn.DfInsert("Entegref_Create_item_web_new", Stok);
                    //conn.DfInsert("Entegref_Create_item_web_Create", Stok);
                }
                int sira = 0;
                for (int brksira = 0; brksira < brkdn.Rows.Count; brksira++)
                {
                    var barkod = brkdn.Rows[brksira]["barkod"].ToString();
                    var catogoryID = brkdn.Rows[brksira]["pimCategoryId"].ToString();

                    string url = "https://api.trendyol.com/sapigw/product-categories/" + catogoryID + "/attributes";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "Get";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        AttRoot myDeserializedClass = JsonConvert.DeserializeObject<AttRoot>(result);
                        foreach (var attr in myDeserializedClass.categoryAttributes)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", barkod);
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", attr.attribute.id.ToString());
                            Ozl.Add("@attributeName", attr.attribute.name.ToString());
                            Ozl.Add("@attributeValueId", "0");
                            Ozl.Add("@attributeValue", "");
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }

                    for (int oz = 0; oz < Ozlbiten.Rows.Count; oz++)
                    {
                        if (Ozlbiten.Rows[oz].ItemArray[0].ToString() == barkod)
                        {
                            sira++;
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Ozlbiten.Rows[oz].ItemArray[0].ToString());
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", Ozlbiten.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@attributeName", Ozlbiten.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@attributeValueId", Ozlbiten.Rows[oz].ItemArray[4].ToString());
                            Ozl.Add("@attributeValue", Ozlbiten.Rows[oz].ItemArray[3].ToString());
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }
                    for (int oz = 0; oz < Rsmbiten.Rows.Count; oz++)
                    {
                        if (Rsmbiten.Rows[oz].ItemArray[1].ToString() == barkod)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Rsmbiten.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@sLocation", "WEB");
                            Ozl.Add("@sResimAdi", Rsmbiten.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@sKullaniciAdi", frmLogin.username);
                            conn.DfInsert("Entegref_Create_item_web_Resim", Ozl);
                        }
                    }
                }
            }
            else if (ultraTabControl1.SelectedTab.Key == "2")
            {
                brkdn.Rows.Clear();
                for (int i = 0; i < Urunpasif.Rows.Count; i++)
                {
                    Dictionary<string, string> Stok = new Dictionary<string, string>();
                    Stok.Add("@barcode", Urunpasif.Rows[i]["barcode"].ToString());
                    Stok.Add("@brand", Urunpasif.Rows[i]["brand"].ToString());
                    Stok.Add("@brandId", Urunpasif.Rows[i]["brandId"].ToString());
                    Stok.Add("@categoryName", Urunpasif.Rows[i]["categoryName"].ToString());
                    Stok.Add("@description", Urunpasif.Rows[i]["description"].ToString());
                    Stok.Add("@dimensionalWeight", Urunpasif.Rows[i]["dimensionalWeight"].ToString());
                    Stok.Add("@id", Urunpasif.Rows[i]["id"].ToString());
                    Stok.Add("@listPrice", Urunpasif.Rows[i]["listPrice"].ToString());
                    Stok.Add("@pimCategoryId", Urunpasif.Rows[i]["pimCategoryId"].ToString());
                    Stok.Add("@platformListingId", Urunpasif.Rows[i]["platformListingId"].ToString());
                    Stok.Add("@productCode", Urunpasif.Rows[i]["productCode"].ToString());
                    Stok.Add("@productContentId", Urunpasif.Rows[i]["productContentId"].ToString());
                    Stok.Add("@productMainId", Urunpasif.Rows[i]["productMainId"].ToString());
                    Stok.Add("@quantity", Urunpasif.Rows[i]["quantity"].ToString());
                    Stok.Add("@salePrice", Urunpasif.Rows[i]["salePrice"].ToString());
                    Stok.Add("@stockCode", Urunpasif.Rows[i]["stockCode"].ToString());
                    Stok.Add("@stockId", Urunpasif.Rows[i]["stockId"].ToString());
                    Stok.Add("@stockUnitType", Urunpasif.Rows[i]["stockUnitType"].ToString());
                    Stok.Add("@title", Urunpasif.Rows[i]["title"].ToString());
                    Stok.Add("@vatRate", Urunpasif.Rows[i]["vatRate"].ToString());
                    Stok.Add("@version", Urunpasif.Rows[i]["version"].ToString());
                    Stok.Add("@sKullaniciAdi", frmLogin.username);
                    brkdn.Rows.Add(new object[] { Urunpasif.Rows[i]["barcode"].ToString(), Urunpasif.Rows[i]["pimCategoryId"].ToString() });
                    conn.DfInsert("Entegref_Create_item_web_new", Stok);
                    //conn.DfInsert("Entegref_Create_item_web_Create", Stok);
                }
                int sira = 0;
                for (int brksira = 0; brksira < brkdn.Rows.Count; brksira++)
                {
                    var barkod = brkdn.Rows[brksira]["barkod"].ToString();
                    var catogoryID = brkdn.Rows[brksira]["pimCategoryId"].ToString();

                    string url = "https://api.trendyol.com/sapigw/product-categories/" + catogoryID + "/attributes";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "Get";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        AttRoot myDeserializedClass = JsonConvert.DeserializeObject<AttRoot>(result);
                        foreach (var attr in myDeserializedClass.categoryAttributes)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", barkod);
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", attr.attribute.id.ToString());
                            Ozl.Add("@attributeName", attr.attribute.name.ToString());
                            Ozl.Add("@attributeValueId", "0");
                            Ozl.Add("@attributeValue", "");
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }

                    for (int oz = 0; oz < Ozlpasif.Rows.Count; oz++)
                    {
                        if (Ozlpasif.Rows[oz].ItemArray[0].ToString() == barkod)
                        {
                            sira++;
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Ozlpasif.Rows[oz].ItemArray[0].ToString());
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", Ozlpasif.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@attributeName", Ozlpasif.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@attributeValueId", Ozlpasif.Rows[oz].ItemArray[4].ToString());
                            Ozl.Add("@attributeValue", Ozlpasif.Rows[oz].ItemArray[3].ToString());
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }
                    for (int oz = 0; oz < Rsmpasif.Rows.Count; oz++)
                    {
                        if (Rsmpasif.Rows[oz].ItemArray[1].ToString() == barkod)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Rsmpasif.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@sLocation", "WEB");
                            Ozl.Add("@sResimAdi", Rsmpasif.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@sKullaniciAdi", frmLogin.username);
                            conn.DfInsert("Entegref_Create_item_web_Resim", Ozl);
                        }
                    }
                }
            }
            else if (ultraTabControl1.SelectedTab.Key == "3")
            {
                brkdn.Rows.Clear();
                for (int i = 0; i < Urunkitli.Rows.Count; i++)
                {
                    Dictionary<string, string> Stok = new Dictionary<string, string>();
                    Stok.Add("@barcode", Urunkitli.Rows[i]["barcode"].ToString());
                    Stok.Add("@brand", Urunkitli.Rows[i]["brand"].ToString());
                    Stok.Add("@brandId", Urunkitli.Rows[i]["brandId"].ToString());
                    Stok.Add("@categoryName", Urunkitli.Rows[i]["categoryName"].ToString());
                    Stok.Add("@description", Urunkitli.Rows[i]["description"].ToString());
                    Stok.Add("@dimensionalWeight", Urunkitli.Rows[i]["dimensionalWeight"].ToString());
                    Stok.Add("@id", Urunkitli.Rows[i]["id"].ToString());
                    Stok.Add("@listPrice", Urunkitli.Rows[i]["listPrice"].ToString());
                    Stok.Add("@pimCategoryId", Urunkitli.Rows[i]["pimCategoryId"].ToString());
                    Stok.Add("@platformListingId", Urunkitli.Rows[i]["platformListingId"].ToString());
                    Stok.Add("@productCode", Urunkitli.Rows[i]["productCode"].ToString());
                    Stok.Add("@productContentId", Urunkitli.Rows[i]["productContentId"].ToString());
                    Stok.Add("@productMainId", Urunkitli.Rows[i]["productMainId"].ToString());
                    Stok.Add("@quantity", Urunkitli.Rows[i]["quantity"].ToString());
                    Stok.Add("@salePrice", Urunkitli.Rows[i]["salePrice"].ToString());
                    Stok.Add("@stockCode", Urunkitli.Rows[i]["stockCode"].ToString());
                    Stok.Add("@stockId", Urunkitli.Rows[i]["stockId"].ToString());
                    Stok.Add("@stockUnitType", Urunkitli.Rows[i]["stockUnitType"].ToString());
                    Stok.Add("@title", Urunkitli.Rows[i]["title"].ToString());
                    Stok.Add("@vatRate", Urunkitli.Rows[i]["vatRate"].ToString());
                    Stok.Add("@version", Urunkitli.Rows[i]["version"].ToString());
                    Stok.Add("@sKullaniciAdi", frmLogin.username);
                    brkdn.Rows.Add(new object[] { Urunkitli.Rows[i]["barcode"].ToString(), Urunkitli.Rows[i]["pimCategoryId"].ToString() });
                    conn.DfInsert("Entegref_Create_item_web_new", Stok);
                    //conn.DfInsert("Entegref_Create_item_web_Create", Stok);
                }
                int sira = 0;
                for (int brksira = 0; brksira < brkdn.Rows.Count; brksira++)
                {
                    var barkod = brkdn.Rows[brksira]["barkod"].ToString();
                    var catogoryID = brkdn.Rows[brksira]["pimCategoryId"].ToString();

                    string url = "https://api.trendyol.com/sapigw/product-categories/" + catogoryID + "/attributes";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "Get";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        AttRoot myDeserializedClass = JsonConvert.DeserializeObject<AttRoot>(result);
                        foreach (var attr in myDeserializedClass.categoryAttributes)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", barkod);
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", attr.attribute.id.ToString());
                            Ozl.Add("@attributeName", attr.attribute.name.ToString());
                            Ozl.Add("@attributeValueId", "0");
                            Ozl.Add("@attributeValue", "");
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }

                    for (int oz = 0; oz < Ozlkitli.Rows.Count; oz++)
                    {
                        if (Ozlkitli.Rows[oz].ItemArray[0].ToString() == barkod)
                        {
                            sira++;
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Ozlkitli.Rows[oz].ItemArray[0].ToString());
                            Ozl.Add("@CategoryID", catogoryID);
                            Ozl.Add("@attributeId", Ozlkitli.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@attributeName", Ozlkitli.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@attributeValueId", Ozlkitli.Rows[oz].ItemArray[4].ToString());
                            Ozl.Add("@attributeValue", Ozlkitli.Rows[oz].ItemArray[3].ToString());
                            conn.DfInsert("Entegref_Create_item_web_Attribute", Ozl);
                        }
                    }
                    for (int oz = 0; oz < Rsmkitli.Rows.Count; oz++)
                    {
                        if (Rsmkitli.Rows[oz].ItemArray[1].ToString() == barkod)
                        {
                            Dictionary<string, string> Ozl = new Dictionary<string, string>();
                            Ozl.Add("@barcode", Rsmkitli.Rows[oz].ItemArray[1].ToString());
                            Ozl.Add("@sLocation", "WEB");
                            Ozl.Add("@sResimAdi", Rsmkitli.Rows[oz].ItemArray[2].ToString());
                            Ozl.Add("@sKullaniciAdi", frmLogin.username);
                            conn.DfInsert("Entegref_Create_item_web_Resim", Ozl);
                        }
                    }
                }
            }
            else if (ultraTabControl1.SelectedTab.Key == "4")
            {

            }
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

            simpleButton2.Text = e.Tab.Text + " Ürünleri ERP de Aç";
            if (e.Tab.Key == "0")
            {
                
            }
        }
    }

}