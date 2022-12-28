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
using static Entegref.frmTrendyol_catogory;

namespace Entegref
{
    public partial class frmTrendyol_FirmaAdresBilgisi : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        public frmTrendyol_FirmaAdresBilgisi()
        {
            InitializeComponent();
        }
        public class DefaultInvoiceAddress
        {
            public int id { get; set; }
            public string addressType { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public int cityCode { get; set; }
            public string district { get; set; }
            public int districtId { get; set; }
            public string postCode { get; set; }
            public string address { get; set; }
            public bool isDefault { get; set; }
            public string fullAddress { get; set; }
            public bool shipmentAddress { get; set; }
            public bool returningAddress { get; set; }
            public bool invoiceAddress { get; set; }
        }

        public class DefaultReturningAddress
        {
            public bool present { get; set; }
        }

        public class DefaultShipmentAddress
        {
            public int id { get; set; }
            public string addressType { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public int cityCode { get; set; }
            public string district { get; set; }
            public int districtId { get; set; }
            public string postCode { get; set; }
            public string address { get; set; }
            public bool isDefault { get; set; }
            public string fullAddress { get; set; }
            public bool shipmentAddress { get; set; }
            public bool returningAddress { get; set; }
            public bool invoiceAddress { get; set; }
        }

        public class Root
        {
            public List<SupplierAddress> supplierAddresses { get; set; }
            public DefaultShipmentAddress defaultShipmentAddress { get; set; }
            public DefaultInvoiceAddress defaultInvoiceAddress { get; set; }
            public DefaultReturningAddress defaultReturningAddress { get; set; }
        }

        public class SupplierAddress
        {
            public int id { get; set; }
            public string addressType { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public int cityCode { get; set; }
            public string district { get; set; }
            public int districtId { get; set; }
            public string postCode { get; set; }
            public string address { get; set; }
            public bool isDefault { get; set; }
            public string fullAddress { get; set; }
            public bool shipmentAddress { get; set; }
            public bool returningAddress { get; set; }
            public bool invoiceAddress { get; set; }
        }

        private void frmTrendyol_FirmaAdresBilgisi_Load(object sender, EventArgs e)
        {
            Adress();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Adress();
        }
        public void Adress()
        {
            var username = Properties.Settings.Default.TrendyolApi;
            var password = Properties.Settings.Default.TrendyolSecretkey;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));

            var url = "https://api.trendyol.com/sapigw/suppliers/" + Properties.Settings.Default.TrendyolId + "/addresses";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            var Adress = new List<trendyol_adress.Root2>();
            var suppliers = new List<trendyol_adress.SupplierAddress>();
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {


                var result = streamReader.ReadToEnd();
                trendyol_adress.Root myDeserializedClass = JsonConvert.DeserializeObject<trendyol_adress.Root>(result);

                var root2 = new trendyol_adress.Root2();
                var Invoice = new trendyol_adress.DefaultInvoiceAddress();
                var Shipmen = new trendyol_adress.DefaultShipmentAddress();
                var Returning = new trendyol_adress.DefaultReturningAddress();
                foreach (var item in myDeserializedClass.supplierAddresses)
                {
                    var supplier = new trendyol_adress.SupplierAddress();
                    supplier.id = item.id;
                    supplier.addressType = item.addressType;
                    supplier.country = item.country;
                    supplier.city = item.city;
                    supplier.cityCode = item.cityCode;
                    supplier.district = item.district;
                    supplier.districtId = item.districtId;
                    supplier.postCode = item.postCode;
                    supplier.address = item.address;
                    supplier.returningAddress = item.returningAddress;
                    supplier.fullAddress = item.fullAddress;
                    supplier.shipmentAddress = item.shipmentAddress;
                    supplier.invoiceAddress = item.invoiceAddress;
                    supplier.@default = item.@default;
                    suppliers.Add(supplier);
                }
                root2.supplierAddresses = suppliers;

                Invoice.id = myDeserializedClass.defaultInvoiceAddress.id;
                Invoice.addressType = myDeserializedClass.defaultInvoiceAddress.addressType;
                Invoice.country = myDeserializedClass.defaultInvoiceAddress.country;
                Invoice.city = myDeserializedClass.defaultInvoiceAddress.city;
                Invoice.cityCode = myDeserializedClass.defaultInvoiceAddress.cityCode;
                Invoice.district = myDeserializedClass.defaultInvoiceAddress.district;
                Invoice.districtId = myDeserializedClass.defaultInvoiceAddress.districtId;
                Invoice.postCode = myDeserializedClass.defaultInvoiceAddress.postCode;
                Invoice.address = myDeserializedClass.defaultInvoiceAddress.address;
                Invoice.returningAddress = myDeserializedClass.defaultInvoiceAddress.returningAddress;
                Invoice.fullAddress = myDeserializedClass.defaultInvoiceAddress.fullAddress;
                Invoice.shipmentAddress = myDeserializedClass.defaultInvoiceAddress.shipmentAddress;
                Invoice.invoiceAddress = myDeserializedClass.defaultInvoiceAddress.invoiceAddress;
                Invoice.@default = myDeserializedClass.defaultInvoiceAddress.@default;
                root2.defaultInvoiceAddress = Invoice;

                Shipmen.id = myDeserializedClass.defaultShipmentAddress.id;
                Shipmen.addressType = myDeserializedClass.defaultShipmentAddress.addressType;
                Shipmen.country = myDeserializedClass.defaultShipmentAddress.country;
                Shipmen.city = myDeserializedClass.defaultShipmentAddress.city;
                Shipmen.cityCode = myDeserializedClass.defaultShipmentAddress.cityCode;
                Shipmen.district = myDeserializedClass.defaultShipmentAddress.district;
                Shipmen.districtId = myDeserializedClass.defaultShipmentAddress.districtId;
                Shipmen.postCode = myDeserializedClass.defaultShipmentAddress.postCode;
                Shipmen.address = myDeserializedClass.defaultShipmentAddress.address;
                Shipmen.returningAddress = myDeserializedClass.defaultShipmentAddress.returningAddress;
                Shipmen.fullAddress = myDeserializedClass.defaultShipmentAddress.fullAddress;
                Shipmen.shipmentAddress = myDeserializedClass.defaultShipmentAddress.shipmentAddress;
                Shipmen.invoiceAddress = myDeserializedClass.defaultShipmentAddress.invoiceAddress;
                Shipmen.@default = myDeserializedClass.defaultShipmentAddress.@default;
                root2.defaultShipmentAddress = Shipmen;

                Returning.present = myDeserializedClass.defaultReturningAddress.present;
                root2.defaultReturningAddress = Returning;

                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                var dt = converter.ToDataTable(suppliers);
                gridAddress.DataSource = suppliers;
                foreach (var item in suppliers)
                {
                    Dictionary<string, string> depolar = new Dictionary<string, string>();
                    depolar.Add("@id", item.id.ToString());
                    depolar.Add("@addressType", item.addressType);
                    depolar.Add("@country", item.country);
                    depolar.Add("@city", item.city);
                    depolar.Add("@cityCode", item.cityCode.ToString());
                    depolar.Add("@district", item.district);
                    depolar.Add("@districtId", item.districtId.ToString());
                    depolar.Add("@postCode", item.postCode);
                    depolar.Add("@address", item.address);
                    depolar.Add("@returningAddress", item.returningAddress.ToString());
                    depolar.Add("@fullAddress", item.fullAddress);
                    depolar.Add("@shipmentAddress", item.shipmentAddress.ToString());
                    depolar.Add("@invoiceAddress", item.invoiceAddress.ToString());
                    depolar.Add("@default", item.@default.ToString());
                    conn.DfInsert("Entegref_Adress", depolar);
                }
            }
        }

    }
}