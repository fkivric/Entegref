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

namespace Entegref
{
    public partial class frmTrendyol_FirmaAdresBilgisi : DevExpress.XtraEditors.XtraForm
    {
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

        }
    }
}