﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1 {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.13.0.0")]
    internal sealed partial class Connecties : global::System.Configuration.ApplicationSettingsBase {
        
        private static Connecties defaultInstance = ((Connecties)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Connecties())));
        
        public static Connecties Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("TrustServerCertificate=True;Server=10.128.4.7;Database=Db2025Team_08;User Id=PxlU" +
            "ser_08;Password=41FFVf7!")]
        public string PxlServerConn {
            get {
                return ((string)(this["PxlServerConn"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TrustServerCertificate=True;Server=IMKE\\SQLEXPRESS;Database=DataEssantials;User I" +
            "d=sa;Password=digital@PXL")]
        public string ImkeServerConn {
            get {
                return ((string)(this["ImkeServerConn"]));
            }
            set {
                this["ImkeServerConn"] = value;
            }
        }
    }
}
