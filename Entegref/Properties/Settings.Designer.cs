﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entegref.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=185.184.26.206;Database=39391097764; User Id=fatih; Password=05101981;")]
        public string connectionstring {
            get {
                return ((string)(this["connectionstring"]));
            }
            set {
                this["connectionstring"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=185.184.26.206;Database=Netbil_Connector; User ID=fatih;Password=05101981;" +
            "")]
        public string connectionstring2 {
            get {
                return ((string)(this["connectionstring2"]));
            }
            set {
                this["connectionstring2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("387607")]
        public string TrendyolId {
            get {
                return ((string)(this["TrendyolId"]));
            }
            set {
                this["TrendyolId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GOD4ohApME0Y1r5YBnmv")]
        public string TrendyolApi {
            get {
                return ((string)(this["TrendyolApi"]));
            }
            set {
                this["TrendyolApi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("lx6cAnNSJQjKBUaZ3Q9W")]
        public string TrendyolSecretkey {
            get {
                return ((string)(this["TrendyolSecretkey"]));
            }
            set {
                this["TrendyolSecretkey"] = value;
            }
        }
    }
}
