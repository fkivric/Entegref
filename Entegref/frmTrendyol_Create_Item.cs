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
using System.Data.SqlClient;
using Entegref.Class;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Entegref
{
    public partial class frmTrendyol_Create_Item : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        long tarih2;
        public frmTrendyol_Create_Item()
        {
            InitializeComponent();
        }

        private void frmTrendyol_Create_Item_Load(object sender, EventArgs e)
        {
            string q = " select s.sModel" +
                " ,sKodu" +
                " ,s.sAciklama" +
                " ,f1.sAciklama as Urun_Grubu" +
                " ,substring(sKisaAdi, CHARINDEX('-', sKisaAdi) + 1, 10) as Marka" +
                " ,u.sUzunNot" +
                " ,(select lFiyat from tbStokFiyati where nStokID = s.nStokID and sFiyatTipi = 'PS') as Satis_Fiyati" +
                " ,(select lFiyat from tbStokFiyati where nStokID = s.nStokID and sFiyatTipi = 'TRD') as Trendyol_Satis_Fiyati" +
                " ,case when TrendyolID != 0 then 'YÜKLÜ' else 'YOK' end Durum" +
                "  ,(select kalan from vwStokKalan where skodu = s.sKodu) as Kalan" +
                " from tbStokBarkodu b" +
                " inner join tbStok s on s.nStokID = b.nStokID" +
                " inner join tbStokSinifi f on f.nStokID = s.nStokID" +
                " inner join tbSSinif1 f1 on f.sSinifKodu1 = f1.sSinifKodu" +
                " inner join tbStokUzunNot u on u.sModel = s.sModel" +
                " inner join tbKdv k on k.sKdvTipi = s.sKdvTipi";
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridUrunler.DataSource = dt;


            string w = "select 0  as id,'Seçin' as adı union select id as id,[name] as adı from tbKargo";
            SqlCommand cmd1 = new SqlCommand(w, sql);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            
        }

        private void viewUrunler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                var Root = new List<Urunler.Item>();
                var Resimler = new List<Urunler.Image>();
                var Ozellikler = new List<Urunler.Attribute>();
                var Urun = new Urunler.Item();
                var ozellik = new Urunler.Attribute();
                var resim = new Urunler.Image();

                var id = viewUrunler.GetRowCellValue(e.RowHandle, "sModel").ToString();
                Dictionary<string, string> sec = new Dictionary<string, string>();
                sec.Add("@sModel", id.Replace(" ",""));
                var dt = conn.DfQuery("Entegref_Urun_Gonder", sec);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Urun.barcode = dt.Rows[i]["barcode"].ToString();
                    Urun.title = dt.Rows[i]["title"].ToString();
                    Urun.productMainId = id;
                    Urun.brandId = int.Parse(dt.Rows[i]["brandId"].ToString());
                    Urun.categoryId = int.Parse(dt.Rows[i]["categoryId"].ToString());
                    Urun.quantity = int.Parse(dt.Rows[i]["quantity"].ToString());
                    Urun.stockCode = dt.Rows[i]["stockCode"].ToString().Replace(" ","");
                    Urun.dimensionalWeight = 0;
                    Urun.description = dt.Rows[i]["description"].ToString();
                    Urun.currencyType = dt.Rows[i]["currencyType"].ToString();
                    Urun.listPrice = double.Parse(dt.Rows[i]["listPrice"].ToString());
                    Urun.salePrice = double.Parse(dt.Rows[i]["salePrice"].ToString());
                    Urun.cargoCompanyId = int.Parse(dt.Rows[i]["cargoCompanyId"].ToString());

                    string sorguimage = "select * from tbStokResim where sModel = '" + id +"'";
                    SqlCommand cmd = new SqlCommand(sorguimage, sql);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable image = new DataTable();
                    da.Fill(image);
                    for (int ii = 0; ii < image.Rows.Count; ii++)
                    {
                        resim.url = image.Rows[ii]["sResimAdi"].ToString();
                        Resimler.Add(resim);
                    }
                    Urun.images = Resimler;
                    Urun.vatRate = int.Parse(dt.Rows[i]["vatRate"].ToString());
                    Urun.shipmentAddressId = int.Parse(dt.Rows[i]["shipmentAddressId"].ToString());
                    Urun.returningAddressId = int.Parse(dt.Rows[i]["returningAddressId"].ToString());

                    string sorguatt = "select * from tbAttribute where sModel = '" + id + "'";
                    SqlCommand cmd2 = new SqlCommand(sorguatt, sql);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable attributes = new DataTable();
                    da2.Fill(attributes);
                    for (int ii = 0; ii < attributes.Rows.Count; ii++)
                    {
                        ozellik.attributeId = int.Parse(attributes.Rows[ii]["nAttributeID"].ToString());
                        ozellik.attributeValueId = int.Parse(attributes.Rows[ii]["nValueID"].ToString());
                        Ozellikler.Add(ozellik);
                    }
                    Urun.attributes = Ozellikler;
                    Urun.currencyType = dt.Rows[i]["currencyType"].ToString();
                    Root.Add(Urun);


                    var username = Properties.Settings.Default.TrendyolApi;
                    var password = Properties.Settings.Default.TrendyolSecretkey;
                    string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                                   .GetBytes(username + ":" + password));

                    var url = "https://api.trendyol.com/sapigw/suppliers/" + Properties.Settings.Default.TrendyolId + "/v2/products";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);                    


                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string jsonstring = JsonConvert.SerializeObject(Root);
                        streamWriter.Write(jsonstring);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
            }
        }
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime rslt = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp).DateTime;
            return rslt;
        }

        private void dteEndDate_EditValueChanged(object sender, EventArgs e)
        {
            var yıl = int.Parse(Convert.ToDateTime(DateTime.Now).ToString("yyyy"));
            var ay = int.Parse(Convert.ToDateTime(DateTime.Now).ToString("MM"));
            var gun = int.Parse(Convert.ToDateTime(DateTime.Now).ToString("dd"));
            DateTime firstDate = new DateTime(yıl, ay, gun, 0, 0, 0);
            TimeZoneInfo tzo = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTimeOffset firstDateUtc = TimeZoneInfo.ConvertTime(firstDate, tzo, TimeZoneInfo.Utc);
            DateTimeOffset[] utcDates = Enumerable.Range(0, 7).Select(r => firstDateUtc.AddHours(r)).ToArray();
            DateTimeOffset[] offsets = Array.ConvertAll(utcDates, d => TimeZoneInfo.ConvertTime(d, tzo));
            tarih2 = offsets[0].ToUnixTimeMilliseconds();
        }
    }
}