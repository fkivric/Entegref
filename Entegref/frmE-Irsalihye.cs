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
using Entegref.tr.com.parkentegrasyon.Irsaliye_test;
using Entegref.tr.com.parkentegrasyon.Goruntu;
using System.Threading;
using System.IO;
using iTextSharp.text.pdf;

namespace Entegref
{
    public partial class frmE_Irsalihye : DevExpress.XtraEditors.XtraForm
    {
        public frmE_Irsalihye()
        {
            InitializeComponent();
        }
        private BackgroundWorker _backgroundWorker;
        private ManualResetEvent _workerCompletedEvent = new ManualResetEvent(false);
        private const string READY_TEXT = "Hazır";
        private void executeBackground(Action doWorkAction, Action progressAction = null, Action completedAction = null)
        {
            try
            {
                if (_backgroundWorker != null)
                {


                    if (_backgroundWorker.IsBusy)
                    {
                        string subPathXSLT = rootPath1 + @"\\Faturalar\";
                        Directory.Delete(subPathXSLT);
                        directoryCreator(subPathXSLT);
                        string[] dosyalar = Directory.GetFiles(subPathXSLT);

                        foreach (string dosya in dosyalar)
                        {
                            File.Delete(dosya);
                        }

                        XtraMessageBox.Show("Her oturum açıldığında 1 işlem yapacak. Eğer bu girişteki ilk işlemse uygulama çalışmaktadır. Lütfen Bekleyiniz");
                        return;
                    }
                }
                _backgroundWorker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true
                };
                _backgroundWorker.DoWork += (x, y) =>
                {
                    try
                    {
                        doWorkAction.Invoke();
                    }
                    catch (Exception ex)
                    {
                        y.Cancel = true;
                        XtraMessageBox.Show("Bilinmeyen Hata. Detay : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // throw;
                    }
                };
                if (progressAction != null)
                {
                    _backgroundWorker.ProgressChanged += (x, y) =>
                    {
                        progressAction.Invoke();
                    };
                }
                if (completedAction != null)
                {
                    _backgroundWorker.RunWorkerCompleted += (x, y) =>
                    {
                        completedAction.Invoke();
                    };
                }
                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception)
            {

            }

        }
        private void directoryCreator(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private void completeProgress()
        {
            try
            {
                _backgroundWorker.Dispose();
                _backgroundWorker = null;
                if (!this.Enabled)
                {
                    this.Enabled = true;
                }

            }
            finally
            {
                //this.Cursor = Cursors.Default;
                _workerCompletedEvent.Set();

            }
        }
        public static void Merge(List<String> InFiles, String OutFile)
        {
            using (FileStream stream = new FileStream(OutFile, FileMode.Create))
            using (iTextSharp.text.Document doc = new iTextSharp.text.Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream))
            {
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                //fixed typo
                InFiles.ForEach(file =>
                {
                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }

                    pdf.FreeReader(reader);
                    reader.Close();
                });
            }
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        EIrsaliyeService client = new EIrsaliyeService();
        private string rootPath1;
        private string soforAdi;
        private string soforSoyadi;
        private string soforTckn;

        private void frmE_Irsalihye_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<string> tmpPdf = new List<string>();
            string subPathXSLT = rootPath1 + @"\\Irsaliyeler\";
            directoryCreator(subPathXSLT);
            Random rnd = new Random();
            var randomNumber = rnd.Next();
            try
            {
                string[] dosyalar = Directory.GetFiles(subPathXSLT);
                foreach (string dosya in dosyalar)
                {
                    File.Delete(dosya);
                }

            }
            catch (Exception)
            {

            }
            List<string> uuid = new List<string>();
            var token = client.Login(Entegref.Properties.Settings.Default.ParkKullaniciAdi, Entegref.Properties.Settings.Default.ParkParola);
            var selectedRows = viewIrsaliyeListesi.GetSelectedRows();

            List<string> alisverisId = new List<string>();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                var id = viewIrsaliyeListesi.GetRowCellValue(selectedRows[i], "nAlisverisID").ToString();
                alisverisId.Add(id);
            }
            var irsaliyeId = alisverisId.Distinct().ToList();
            ProgressBarFrm progressForm = new ProgressBarFrm()
            {
                Start = 0,
                Finish = irsaliyeId.Count,
                Position = 0,
            };

            int success = 0;
            int error = 0;
            this.Enabled = false;

            executeBackground(
       () =>
       {
           progressForm.Show(this);



           for (int i = 0; i < irsaliyeId.Count; i++)
           {
               tr.com.parkentegrasyon.Irsaliye_test.PARKDespatchType types = new tr.com.parkentegrasyon.Irsaliye_test.PARKDespatchType();
               Dictionary<string, string> param = new Dictionary<string, string>();
               param.Add("@nAlisverisID", irsaliyeId[i]);
               var alici = conn.DfQuery("Portal_Irsaliye_Alisveris_Musteri", param);
               var urunler = conn.DfQuery("Portal_Irsaliye_Alisveris_Satirlar", param);
               var not = conn.DfQuery("Portal_Irsaliye_Alisveris_Aciklama", param);
               types.AliciFirmaBilgileri = new tr.com.parkentegrasyon.Irsaliye_test.FirmaBilgileri
               {
                   VergiDairesi = alici.Rows[0]["VergiDairesi"].ToString(),
                   Il = alici.Rows[0]["Il"].ToString(),
                   Ilce = alici.Rows[0]["Ilce"].ToString(),
                   VergiNumarasi = alici.Rows[0]["VergiNumarasi"].ToString().Length == 11 ? alici.Rows[0]["VergiNumarasi"].ToString() : "55555555555",
                   Telefon = alici.Rows[0]["Telefon"].ToString(),
                   Adi = alici.Rows[0]["VergiNumarasi"].ToString().Length == 10 ? null : alici.Rows[0]["Adi"].ToString(),
                   Soyadi = alici.Rows[0]["VergiNumarasi"].ToString().Length == 10 ? null : alici.Rows[0]["Soyadi"].ToString(),
                   FirmaAdi = alici.Rows[0]["VergiNumarasi"].ToString().Length == 11 ? null : alici.Rows[0]["Unvan"].ToString(),
                   Eposta = alici.Rows[0]["Eposta"].ToString(),
                   Sokak = alici.Rows[0]["Adres"].ToString(),
                   Apartman = "",
                   ApartmanNo = "",
                   Cadde = "",
                   Fax = "",
                   PostaKodu = "",
                   Ulke = "TR",
                   WebSitesi = "",

               };

               types.Tipi = "SEVK";
               types.Profil = "TEMELIRSALIYE";
               types.IrsaliyeTarihi = DateTime.Now;
               types.IrsaliyeZamani = DateTime.Now;
               types.SevkTarihi = DateTime.Now;
               types.SevkZamani = DateTime.Now;
               types.SoforBilgileri = new tr.com.parkentegrasyon.Irsaliye_test.SoforBilgileriObj[]
               {
                    new  tr.com.parkentegrasyon.Irsaliye_test.SoforBilgileriObj
                    {
                           SoforAdi = soforAdi,
                           SoforSoyadi = soforSoyadi,
                           Tckn = soforTckn
                    }
               };
               types.MalHizmetToplamTutari = 0;
               var notlar = new List<string>();
               notlar.Add(not.Rows[0]["nots"].ToString());

               types.Notes = notlar.ToArray();
               types.ParaBirimi = "TRY";
               types.SiparisNumarasi = "";
               types.SiparisTarihi = DateTime.Now;
               types.TasiyiciPlaka = "";
               types.TasiyiciUnvan = "";
               types.TasiyiciVknTckn = "";
               types.TaslaklaraGonderilsin = false;
               types.DorsePlaka = new List<tr.com.parkentegrasyon.Irsaliye_test.DorsePlakaObj>().ToArray();
               types.IrsaliyeGibNumarasi = null;
               types.MalHizmetToplamTutari = 0;
               List<tr.com.parkentegrasyon.Irsaliye_test.IrsaliyeSatirlari> satirtmp = new List<tr.com.parkentegrasyon.Irsaliye_test.IrsaliyeSatirlari>();
               List<string> nislemId = new List<string>();

               for (int j = 0; j < selectedRows.Length; j++)
               {
                   var selectedRowsId = viewIrsaliyeListesi.GetRowCellValue(selectedRows[j], "nAlisverisID").ToString();
                   if (irsaliyeId[i].ToString() == selectedRowsId)
                   {

                       nislemId.Add(viewIrsaliyeListesi.GetRowCellValue(selectedRows[j], "ID").ToString());
                       tr.com.parkentegrasyon.Irsaliye_test.IrsaliyeSatirlari satir = new tr.com.parkentegrasyon.Irsaliye_test.IrsaliyeSatirlari();
                       satir.Birim = "C62";
                       satir.ParaBirimi = "TRY";
                       satir.BirimFiyat = 0;
                       satir.SonraTeslimEdilecekMiktar = 0;
                       satir.StokKodu = viewIrsaliyeListesi.GetRowCellValue(selectedRows[j], "StokKodu").ToString();
                       satir.UrunAdi = viewIrsaliyeListesi.GetRowCellValue(selectedRows[j], "StokAdi").ToString();
                       satir.TeslimedilecekMiktar = Convert.ToDecimal(viewIrsaliyeListesi.GetRowCellValue(selectedRows[j], "Adet").ToString());
                       satir.Tutar = 0;
                       satir.SatirNo = j + 1;
                       satirtmp.Add(satir);
                   }
               }

               types.IrsaliyeSatirlari = satirtmp.ToArray();
               types.XsltName = "EFATURA";
               string onEk = "EF";
               if (onEk.Length == 2)
               {
                   onEk = "I" + onEk;
               }
               types.Uuid = Guid.NewGuid().ToString();
               var document = new List<tr.com.parkentegrasyon.Irsaliye_test.AdditionalDocumentReferenceDespatchObj>();

               document.Add(new tr.com.parkentegrasyon.Irsaliye_test.AdditionalDocumentReferenceDespatchObj
               {
                   ID = irsaliyeId[i],
                   DocumentType = "QRCODE",
                   DocumentTypeCode = "QRCODE",
                   IssueDate = types.IrsaliyeTarihi,
                   Attachment = new tr.com.parkentegrasyon.Irsaliye_test.Attachment
                   {

                       EmbeddedDocumentBinaryObject = new tr.com.parkentegrasyon.Irsaliye_test.EmbeddedDocumentBinaryObject
                       {
                           fileName = "BARKOD",
                           mimeCode = "application/xml",
                           characterSetCode = "UTF-8",
                           encodingCode = "Base64",
                           Value = client.IrsaliyeQRCodeCreate(types.Uuid, token.SessionId),
                       },
                   }
               });
               types.AdditionalDocumentReferences = document.ToArray();

               var issuccess = client.ParkObjectSendIrsaliye(types, onEk, nislemId.First(), token.SessionId);

               if (issuccess.isSuccess)
               {
                   for (int d = 0; d < nislemId.Count; d++)
                   {
                       param = new Dictionary<string, string>();
                       param.Add("@nAlisverisID", irsaliyeId[i].Replace(" ", ""));
                       param.Add("@nIslemID", nislemId[d]);
                       param.Add("@UUID", issuccess.Uuid);
                       param.Add("@ID", issuccess.InvoiceRef);
                       conn.DfInsert("Portal_Irsaliye_Alisveris_complate", param);
                   }
                   success++;
                   uuid.Add(issuccess.Uuid);

               }
               else
               {
                   XtraMessageBox.Show("Gönderim Esnasında Hata Alındı : nAlisverisId  " + irsaliyeId[i] + " - " + issuccess.DetailsDesc);
                   error++;
               }
               progressForm.PerformStep(this);
           }

           //PdfConvertHtml convert = new PdfConvertHtml();
           EFaturaIntegration client2 = new EFaturaIntegration();
           for (int i = 0; i < uuid.Count; i++)
           {
               var content = client2.IrsaliyeHtmlAl(uuid[i], token.SessionId);
               //var contentPdf = convert.HTMLToPDF(Encoding.UTF8.GetBytes(content));
               //File.WriteAllBytes(subPathXSLT + @"\" + uuid[i] + ".pdf", contentPdf);
               tmpPdf.Add(subPathXSLT + @"\" + uuid[i] + ".pdf");
           }


           if (tmpPdf.Count > 0)
           {
               Merge(tmpPdf, subPathXSLT + @"\" + randomNumber.ToString() + ".pdf");
               //PdfViewer print = new PdfViewer();
               ////var printerSettings = new PrinterSettings();
               ////Process process = new Process();
               ////process.StartInfo.FileName = subPathXSLT + @"\" + randomNumber.ToString() + ".pdf";// pdf file to print 
               ////                                         //print to specified printer
               ////process.StartInfo.Verb = "PrintTo";
               ////process.StartInfo.CreateNoWindow = true;

               ////process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

               //////Printer name
               ////process.StartInfo.Arguments = printerSettings.PrinterName;
               ////process.Start();
               ////process.WaitForExit();

               //print.LoadDocument(subPathXSLT + @"\" + randomNumber.ToString() + ".pdf");
               //print.Print();
               //print.Dispose();
               try
               {
                   for (int i = 0; i < uuid.Count; i++)
                   {
                       File.Delete(subPathXSLT + @"\" + uuid[i] + ".pdf");
                   }

               }
               catch (Exception)
               {

               }

               System.Diagnostics.Process.Start(subPathXSLT + @"\");

           }
       },
                     null,
                     () =>
                     {
                         completeProgress();
                         progressForm.Hide(this);
                         XtraMessageBox.Show("Gönderim tamamlandı. Toplam Başarılı : ." + success + " Toplam Hatalı : " + error, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         try
                         {
                             foreach (var item in tmpPdf)
                             {
                                 File.Delete(item);
                             }
                             File.Delete(subPathXSLT + @"\" + randomNumber.ToString() + ".pdf");
                         }
                         catch (Exception ex)
                         {

                         }
                     });


        }
    }
}