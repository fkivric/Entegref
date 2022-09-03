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
    public partial class frmTrendyol_Finans : DevExpress.XtraEditors.XtraForm
    {
        private long tarih1;
        private long tarih2;
        SqlConnectionObject conn = new SqlConnectionObject();
        Trendyol_finans.Root Root = new Trendyol_finans.Root();
        Trendyol_finans.Content Content = new Trendyol_finans.Content();
        bool finans;
        public frmTrendyol_Finans(bool _finans)
        {
            InitializeComponent();
            finans = _finans;
        }

        private void frmTrendyol_Finans_Load(object sender, EventArgs e)
        {
            if (finans == true)
            {
                navigationFrame1.SelectedPage = navigationPage1;
            }
            else
            {
                navigationFrame1.SelectedPage = navigationPage2;
            }
            dteStartDate.DateTime = DateTime.Now;
            dteStartDate.Properties.MaxValue = DateTime.Now;
            dteEndDate.DateTime = DateTime.Now;
            dteStartDate2.DateTime = DateTime.Now;
            dteStartDate2.Properties.MaxValue = DateTime.Now;
            dteEndDate2.DateTime = DateTime.Now;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Finans();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Fatura_Odemeleri();
        }

        public void Finans()
        {
            var username = Properties.Settings.Default.TrendyolApi;
            var password = Properties.Settings.Default.TrendyolSecretkey;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));
            var url = "https://api.trendyol.com/integration/finance/che/sellers/" + Properties.Settings.Default.TrendyolId + "/otherfinancials";
            string durum = "";
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
                        durum = durum + "," + chkstatus.Items[i].Value.ToString();
                    }
                }
            }
            url = url + "?transactionType=" + durum;
            if (cnhTarih.Checked == true)
            {
                url = url + "&startDate=" + tarih1 + "&endDate=" + tarih2;
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var Faturalar = new List<Trendyol_finans.Content2>();
                var result = streamReader.ReadToEnd();
                Trendyol_finans.Root myDeserializedClass = JsonConvert.DeserializeObject<Trendyol_finans.Root>(result);
                foreach (var item in myDeserializedClass.content)
                {
                    var Fatura = new Trendyol_finans.Content2();
                    Fatura.id = item.id;
                    Fatura.transactionDate = UnixTimeStampToDateTime(item.transactionDate);
                    Fatura.transactionType = item.transactionType;
                    Fatura.debt = item.debt;
                    Fatura.credit = item.credit;
                    Fatura.paymentOrderId = item.paymentOrderId;
                    Fatura.sellerId = item.sellerId;
                    Faturalar.Add(Fatura);
                }
                gridControl1.DataSource = Faturalar;
            }
        }
        public void Fatura_Odemeleri()
        {
            var username = Properties.Settings.Default.TrendyolApi;
            var password = Properties.Settings.Default.TrendyolSecretkey;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));

            var url = "https://api.trendyol.com/integration/finance/che/sellers/" + Properties.Settings.Default.TrendyolId + "/settlements";
            string durum = "";
            for (int i = 0; i < chkstatus.Items.Count; i++)
            {
                if (chkstatus2.Items[i].CheckState == CheckState.Checked)
                {
                    if (durum == "")
                    {
                        durum = chkstatus2.Items[i].Value.ToString();
                    }
                    else
                    {
                        durum = durum + "," + chkstatus2.Items[i].Value.ToString();
                    }
                }

            }
            url = url + "?transactionType=" + durum;
            url = url + "&startDate=" + tarih1 + "&endDate=" + tarih2;
            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Trendyol_finans.Root myDeserializedClass = JsonConvert.DeserializeObject<Trendyol_finans.Root>(result);
                var Faturalar = new List<Trendyol_finans.Content3>();
                foreach (var item in myDeserializedClass.content)
                {
                    var Fatura = new Trendyol_finans.Content3();
                    Fatura.id = item.id;
                    Fatura.transactionDate = UnixTimeStampToDateTime(item.transactionDate);
                    Fatura.barcode = item.barcode;
                    Fatura.transactionType = item.transactionType;
                    Fatura.receiptId = item.receiptId;
                    Fatura.description = item.description;
                    Fatura.debt = item.debt;
                    Fatura.credit = item.credit;
                    Fatura.paymentPeriod = item.paymentPeriod;
                    Fatura.commissionRate = item.commissionRate;
                    Fatura.commissionAmount = item.commissionAmount;
                    Fatura.sellerRevenue = item.sellerRevenue;
                    Fatura.orderNumber = item.orderNumber;
                    Fatura.paymentOrderId = item.paymentOrderId;
                    Fatura.paymentDate = UnixTimeStampToDateTime(item.paymentDate);
                    Fatura.sellerId = item.sellerId;
                    Faturalar.Add(Fatura);
                }
                gridControl2.DataSource = Faturalar;
            }
        }
        private void dteStartDate_EditValueChanged(object sender, EventArgs e)
        {
            dteEndDate.Properties.MaxValue = dteStartDate.DateTime.AddDays(14);
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
        private void dteStartDate2_EditValueChanged(object sender, EventArgs e)
        {
            dteEndDate2.Properties.MaxValue = dteStartDate2.DateTime.AddDays(14);
            var yıl = int.Parse(Convert.ToDateTime(dteStartDate2.EditValue).ToString("yyyy"));
            var ay = int.Parse(Convert.ToDateTime(dteStartDate2.EditValue).ToString("MM"));
            var gun = int.Parse(Convert.ToDateTime(dteStartDate2.EditValue).ToString("dd"));
            DateTime firstDate = new DateTime(yıl, ay, gun, 0, 0, 0);
            TimeZoneInfo tzo = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTimeOffset firstDateUtc = TimeZoneInfo.ConvertTime(firstDate, tzo, TimeZoneInfo.Utc);
            DateTimeOffset[] utcDates = Enumerable.Range(0, 7).Select(r => firstDateUtc.AddHours(r)).ToArray();
            DateTimeOffset[] offsets = Array.ConvertAll(utcDates, d => TimeZoneInfo.ConvertTime(d, tzo));
            tarih1 = offsets[0].ToUnixTimeMilliseconds();
        }
        private void dteEndDate2_EditValueChanged(object sender, EventArgs e)
        {
            var yıl = int.Parse(Convert.ToDateTime(dteEndDate2.EditValue).ToString("yyyy"));
            var ay = int.Parse(Convert.ToDateTime(dteEndDate2.EditValue).ToString("MM"));
            var gun = int.Parse(Convert.ToDateTime(dteEndDate2.EditValue).ToString("dd"));
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
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime rslt = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp).DateTime;
            return rslt;
        }
    }
}