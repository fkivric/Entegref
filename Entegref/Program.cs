using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Entegref
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //selam yunus naber notebook üzerinden eklendi
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.XtraEditors.WindowsFormsSettings.AllowDefaultSvgImages = DevExpress.Utils.DefaultBoolean.False;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("tr");
            RegistryKey key2 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Entegref");

            var sonuc = key2.GetValue("ApplicationSetupComplate");
            if (sonuc == null)
            {
                bool acikmi = false;
                Mutex mtex = new Mutex(true, "Program", out acikmi);
                if (acikmi)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmYapılandırma());

                }
                else
                {
                    MessageBox.Show("Program Çalışıyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (sonuc.ToString() != "true")
                {
                    bool acikmi = false;
                    Mutex mtex = new Mutex(true, "Program", out acikmi);
                    if (acikmi)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmYapılandırma());

                    }
                    else
                    {
                        MessageBox.Show("Program Çalışıyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool acikmi = false;
                    Mutex mtex = new Mutex(true, "Program", out acikmi);
                    if (acikmi)
                    {
                        var db1 = Properties.Settings.Default.connectionstring;
                        db1 = "Server=185.184.26.245;Database="+ Properties.Settings.Default.VKN+"; User Id=fatih; Password=05101981;";
                        Properties.Settings.Default.connectionstring = db1;
                        Properties.Settings.Default.Save();
                        Application.EnableVisualStyles();
                        //Application.SetCompatibleTextRenderingDefault(false);
                        //Application.Run(new frmYapılandırma());
                        Application.Run(new frmLogin(Properties.Settings.Default.VKN));
                    }
                    else
                    {
                        MessageBox.Show("Program Çalışıyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
