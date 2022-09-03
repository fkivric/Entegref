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
    public partial class frmTrendyol_Siparis : DevExpress.XtraEditors.XtraForm
    {
        public frmTrendyol_Siparis()
        {
            InitializeComponent();
        }
        
        private void frmTrendyol_Siparis_Load(object sender, EventArgs e)
        {
            dteStartDate.DateTime = DateTime.Now;
            dteEndDate.DateTime = DateTime.Now;
            simpleButton2.Enabled = true;
        }
        long tarih1;
        long tarih2;
        SqlConnectionObject conn = new SqlConnectionObject();
        public void SiparisCek()
        {
            var username = Properties.Settings.Default.TrendyolApi;
            var password = Properties.Settings.Default.TrendyolSecretkey;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));

            var url = "https://api.trendyol.com/sapigw/suppliers/" + Properties.Settings.Default.TrendyolId + "/orders";

            string durum="";
            for (int i = 0; i < chkstatus.Items.Count; i++)
            {
                if (chkstatus.Items[i].CheckState == CheckState.Checked)
                {
                    if (durum == "")
                    {
                        durum = chkstatus.Items[i].Value.ToString();
                    }
                    else
                    {
                        durum = durum+","+chkstatus.Items[i].Value.ToString();
                    }
                }
                
            }
            url = url + "?status=" + durum;
            if (cnhTarih.Checked == true)
            {
                url = url + "&startDate =" + tarih1 + "&endDate ="+ tarih2;
            }
            if (txtorderNumber.Text != "")
            {
                url = url + "&orderNumber=" + txtorderNumber.Text;
            }
            if (txtshipmentPackageIds.Text != "")
            {
                url = url + "&shipmentPackageIds=" + txtshipmentPackageIds.Text;
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var siparisler = new List<Trednyol_Siparisler.Content>();

                var result = streamReader.ReadToEnd();
                Trednyol_Siparisler.Root myDeserializedClass = JsonConvert.DeserializeObject<Trednyol_Siparisler.Root>(result);
                foreach (var item in myDeserializedClass.content)
                {
                    var hat = new List<Trednyol_Siparisler.Line>();
                    var disds = new List<Trednyol_Siparisler.DiscountDetail>();
                    var sip = new Trednyol_Siparisler.Content();
                    var shipadres = new Trednyol_Siparisler.ShipmentAddress();
                    shipadres.id = item.shipmentAddress.id;
                    shipadres.firstName = item.shipmentAddress.firstName;
                    shipadres.lastName = item.shipmentAddress.lastName;
                    shipadres.address1 = item.shipmentAddress.address1;
                    shipadres.address2 = item.shipmentAddress.address2;
                    shipadres.city = item.shipmentAddress.city;
                    shipadres.cityCode = item.shipmentAddress.cityCode;
                    shipadres.district = item.shipmentAddress.district;
                    shipadres.postalCode = item.shipmentAddress.postalCode;
                    shipadres.countryCode = item.shipmentAddress.countryCode;
                    shipadres.neighborhoodId = item.shipmentAddress.neighborhoodId;
                    shipadres.neighborhood = item.shipmentAddress.neighborhood;
                    shipadres.phone = item.shipmentAddress.phone;
                    shipadres.fullAddress = item.shipmentAddress.fullAddress;
                    shipadres.fullName = item.shipmentAddress.fullName;
                    sip.shipmentAddress = shipadres;
                    sip.orderNumber = item.orderNumber;
                    sip.grossAmount = item.grossAmount;
                    sip.totalDiscount = item.totalDiscount;
                    sip.totalTyDiscount = item.totalTyDiscount;
                    sip.taxNumber = item.taxNumber;
                    var invadres = new Trednyol_Siparisler.InvoiceAddress();
                    invadres.id = invadres.id;
                    invadres.firstName = item.invoiceAddress.firstName;
                    invadres.lastName = item.invoiceAddress.lastName;
                    invadres.company = item.invoiceAddress.company;
                    invadres.address1 = item.invoiceAddress.address1;
                    invadres.address2 = item.invoiceAddress.address2;
                    invadres.city = item.invoiceAddress.city;
                    invadres.cityCode = item.invoiceAddress.cityCode;
                    invadres.district = item.invoiceAddress.district;
                    invadres.districtId = item.invoiceAddress.districtId;
                    invadres.postalCode = item.invoiceAddress.postalCode;
                    invadres.countryCode = item.invoiceAddress.countryCode;
                    invadres.neighborhoodId = item.invoiceAddress.neighborhoodId;
                    invadres.neighborhood = item.invoiceAddress.neighborhood;
                    invadres.phone = item.invoiceAddress.phone;
                    invadres.fullAddress = item.invoiceAddress.fullAddress;
                    invadres.fullName = item.invoiceAddress.fullName;
                    sip.invoiceAddress = invadres;
                    sip.customerFirstName = item.customerFirstName;
                    sip.customerEmail = item.customerEmail;
                    sip.customerId = item.customerId;
                    sip.customerLastName = item.customerLastName;
                    sip.id = item.id;
                    sip.cargoTrackingNumber = item.cargoTrackingNumber;
                    sip.cargoProviderName = item.cargoProviderName;
                    foreach (var item2 in item.lines)
                    {
                        var ln = new Trednyol_Siparisler.Line();
                        ln.quantity = item2.quantity;
                        ln.salesCampaignId = item2.salesCampaignId;
                        ln.productSize = item2.productSize;
                        ln.productName = item2.productName;
                        ln.productCode = item2.productCode;
                        ln.merchantId = item2.merchantId;
                        ln.amount = item2.amount;
                        ln.discount = item2.discount;
                        ln.tyDiscount = item2.tyDiscount;
                        foreach (var item3 in item2.discountDetails)
                        {
                            var disd = new Trednyol_Siparisler.DiscountDetail();
                            disd.lineItemPrice = item3.lineItemPrice;
                            disd.lineItemDiscount = item3.lineItemDiscount;
                            disd.lineItemTyDiscount = item3.lineItemTyDiscount;
                            disds.Add(disd);
                        }
                        ln.discountDetails = disds;
                        ln.currencyCode = item2.currencyCode;
                        ln.productColor = item2.productColor;
                        ln.id = item2.id;
                        ln.sku = item2.sku;
                        ln.vatBaseAmount = item2.vatBaseAmount;
                        ln.barcode = item2.barcode;
                        ln.orderLineItemStatusName = item2.orderLineItemStatusName;
                        ln.price = item2.price;
                        hat.Add(ln);
                    }
                    sip.lines = hat;
                    sip.orderDate = item.orderDate;
                    sip.tcIdentityNumber = item.tcIdentityNumber;
                    sip.currencyCode = item.currencyCode;
                    sip.shipmentPackageStatus = item.shipmentPackageStatus;
                    sip.status = item.status;
                    sip.deliveryType = item.deliveryType;
                    sip.timeSlotId = item.timeSlotId;
                    sip.scheduledDeliveryStoreId = item.scheduledDeliveryStoreId;
                    sip.estimatedDeliveryStartDate = item.estimatedDeliveryStartDate;
                    sip.estimatedDeliveryEndDate = item.estimatedDeliveryEndDate;
                    sip.totalPrice = item.totalPrice;
                    sip.deliveryAddressType = item.deliveryAddressType;
                    sip.agreedDeliveryDate = item.agreedDeliveryDate;
                    sip.fastDelivery = item.fastDelivery;
                    sip.originShipmentDate = item.originShipmentDate;
                    sip.lastModifiedDate = item.lastModifiedDate;
                    sip.commercial = item.commercial;
                    sip.fastDeliveryType = item.fastDeliveryType;
                    sip.deliveredByService = item.deliveredByService;
                    sip.agreedDeliveryDateExtendible = item.agreedDeliveryDateExtendible;
                    sip.extendedAgreedDeliveryDate = item.extendedAgreedDeliveryDate;
                    sip.agreedDeliveryExtensionEndDate = item.agreedDeliveryExtensionEndDate;
                    sip.agreedDeliveryExtensionStartDate = item.agreedDeliveryExtensionStartDate;
                    siparisler.Add(sip);
                }
                gridControl1.DataSource = siparisler;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            SiparisCek();
        }

        private void dteStartDate_EditValueChanged(object sender, EventArgs e)
        {
            var yıl = int.Parse(Convert.ToDateTime(dteStartDate.EditValue).ToString("yyyy"));
            var ay = int.Parse(Convert.ToDateTime(dteStartDate.EditValue).ToString("MM"));
            var gun = int.Parse(Convert.ToDateTime(dteStartDate.EditValue).ToString("dd"));
            DateTime firstDate = new DateTime(yıl, ay, gun, 0, 0, 0);
            TimeZoneInfo tzo = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTimeOffset firstDateUtc = TimeZoneInfo.ConvertTime(firstDate, tzo, TimeZoneInfo.Utc);
            DateTimeOffset[] utcDates = Enumerable.Range(0, 7).Select(r => firstDateUtc.AddHours(r)).ToArray();
            DateTimeOffset[] offsets = Array.ConvertAll(utcDates, d => TimeZoneInfo.ConvertTime(d, tzo));
            tarih1 = offsets[0].ToUnixTimeMilliseconds();
        }

        private void dteEndDate_EditValueChanged(object sender, EventArgs e)
        {
            var yıl = int.Parse(Convert.ToDateTime(dteEndDate.EditValue).ToString("yyyy"));
            var ay = int.Parse(Convert.ToDateTime(dteEndDate.EditValue).ToString("MM"));
            var gun = int.Parse(Convert.ToDateTime(dteEndDate.EditValue).ToString("dd"));
            DateTime firstDate = new DateTime(yıl, ay, gun, 0, 0, 0);
            TimeZoneInfo tzo = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTimeOffset firstDateUtc = TimeZoneInfo.ConvertTime(firstDate, tzo, TimeZoneInfo.Utc);
            DateTimeOffset[] utcDates = Enumerable.Range(0, 7).Select(r => firstDateUtc.AddHours(r)).ToArray();
            DateTimeOffset[] offsets = Array.ConvertAll(utcDates, d => TimeZoneInfo.ConvertTime(d, tzo));
            tarih2 = offsets[0].ToUnixTimeMilliseconds();
        }

        private void cnhTarih_CheckedChanged(object sender, EventArgs e)
        {
            if (cnhTarih.Checked == true)
            {
                dteStartDate.Enabled = true;
                dteEndDate.Enabled = true;
            }
            else
            {
                dteStartDate.Enabled = false;
                dteEndDate.Enabled = false;
            }
        }
    }
}