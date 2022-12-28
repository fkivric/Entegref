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
using System.Net.Http;

namespace Entegref
{
    public partial class frmCicekSepeti_Ürün_Aktif : DevExpress.XtraEditors.XtraForm
    {
        public frmCicekSepeti_Ürün_Aktif()
        {
            InitializeComponent();
        }
        public static string sure = "Hazır";
        private void frmCicekSepeti_Ürün_Aktif_Load(object sender, EventArgs e)
        {
            if (sure == "Hazır")
            {
                simpleButton1.Enabled = true;
            }
            else
            {
                simpleButton1.Enabled = false;
            }
            lblsorguzaman.Text = sure;
        }
        public class Resimler
        {
            public string resim { get; set; }
        }
        public class Attribute
        {
            public int parentId { get; set; }
            public string parentName { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public int textLength { get; set; }
        }
        public class Product
        {
            public string productName { get; set; }
            public string productCode { get; set; }
            public string stockCode { get; set; }
            public bool isActive { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public string mainProductCode { get; set; }
            public string productStatusType { get; set; }
            public string description { get; set; }
            public string link { get; set; }
            public object mediaLink { get; set; }
            public int deliveryMessageType { get; set; }
            public int deliveryType { get; set; }
            public bool isUseStockQuantity { get; set; }
            public int stockQuantity { get; set; }
            public double salesPrice { get; set; }
            public double listPrice { get; set; }
            public string barcode { get; set; }
            public string commissionRate { get; set; }
            public int numberOfFavorites { get; set; }
            public object origin { get; set; }
            public object productHarmonyCode { get; set; }
            public List<string> images { get; set; }
            public List<Attribute> attributes { get; set; }
        }

        public class Root
        {
            public int totalCount { get; set; }
            public List<Product> products { get; set; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var key = "x-api-key";
            var Value = Properties.Settings.Default.CicekSepetiApi_key;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(key + ":" + Value));

            var url = "https://apis.ciceksepeti.com/api/v1/Products?SortMethod=1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers["Authorization"] = "API Key " + encoded;
            httpWebRequest.Headers.Add("x-api-key", Value);
            if (timer1.Enabled == false)
            {


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    timer1.Start();
                    var UrunHepsi = new List<Product>();
                    var Taslak = new List<Product>();
                    var Onay_Bekliyor = new List<Product>();
                    var Yayında = new List<Product>();
                    var Ret_Edilmiş = new List<Product>();
                    var Pasif = new List<Product>();
                    var Onay_Bekleyen = new List<Product>();
                    var Stoğu_Bitenler = new List<Product>();



                    var result = streamReader.ReadToEnd();
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                    foreach (var item in myDeserializedClass.products)
                    {
                        var Ozellikler = new List<Attribute>();
                        var Urun = new Product();
                        Urun.productName = item.productName;//Ürünün adı
                        Urun.productCode = item.productCode; //Ürünün çiçeksepetindeki kodu
                        Urun.categoryId = item.categoryId; //Ürünün çiçeksepetindeki kategori id'si
                        Urun.categoryName = item.categoryName;//Ürünün çiçeksepetindeki kategori adı
                        Urun.stockCode = item.stockCode; //Tedarikçi ürün varyant kodu
                        Urun.mainProductCode = item.mainProductCode; //Tedarikçi ürün kodu
                        Urun.productStatusType = item.productStatusType; //Ürünün çiçeksepetindeki durumu
                        Urun.description = item.description;//Ürünün açıklaması
                        Urun.link = item.link; //Ürünün çiçeksepetindeki linki
                        Urun.mediaLink = item.mediaLink;  //Varsa ürüne eklenen video linki
                        Urun.deliveryType = item.deliveryType;    //Ürünün çiçeksepetindeki teslimat tipi
                        Urun.deliveryMessageType = item.deliveryMessageType; //Ürünün çiçeksepetindeki gönderim süresi bilgisi
                        Urun.isUseStockQuantity = item.isUseStockQuantity; //True: ürün stoklu, False: Ürün stoksuz
                        Urun.stockQuantity = item.stockQuantity;//Ürünün çiçeksepetindeki stok adedi
                        Urun.salesPrice = item.salesPrice; //Ürünün çiçeksepetindeki satış fiyatı
                        Urun.listPrice = item.listPrice;//Ürünün çiçeksepetindeki üstü çizili fiyatı
                        Urun.barcode = item.barcode;//Ürün Barkodu 40 karakter üzerinde olmamalıdır.Barkodunuzda "? / & % + ^ ' * _" boşluk gibi özel karakterler kullanılamaz.Barkodunuzun ortasında boşluk varsa birleştirilerek içeri alınır
                        Urun.isActive = item.isActive;  // True: Aktif ürün, False:Pasif ürün
                        Urun.images = item.images;//Ürünün resmi
                        foreach (var itemAtt in item.attributes) //id Ürünün çiçeksepetindeki kategori id'si
                        {
                            var Ozellik = new Attribute();
                            Ozellik.parentId = itemAtt.parentId;
                            Ozellik.parentName = itemAtt.parentName;
                            Ozellik.id = itemAtt.id;
                            Ozellik.name = itemAtt.name;
                            Ozellik.type = itemAtt.type = Ozellik.type;
                            Ozellik.textLength = itemAtt.textLength;
                            Ozellikler.Add(Ozellik);

                        }
                        Urun.attributes = Ozellikler;
                        UrunHepsi.Add(Urun);
                    }
                    gridAktifUrunler.DataSource = UrunHepsi;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblsorguzaman.Text = sure;
        }

    }
    
}