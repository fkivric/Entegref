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
            //selam yunus naber
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
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmYapılandırma());
                        //Application.Run(new frmLogin());
                        
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
