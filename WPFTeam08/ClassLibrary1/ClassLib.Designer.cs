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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.11.0.0")]
    public sealed partial class ClassLib : global::System.Configuration.ApplicationSettingsBase {
        
        private static ClassLib defaultInstance = ((ClassLib)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ClassLib())));
        
        public static ClassLib Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("TrustServerCertificate=True; Server=10.128.4.7; Database=Db2025Team_08; User Id=P" +
            "xlUser_08; Password=GoTeam08")]
        public string SQLServerConnect {
            get {
                return ((string)(this["SQLServerConnect"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Trusted_Connection=True; TrustServerCertificate=true; Server=DESKTOP-VE15COE\\SQLE" +
            "XPRESS; Database=DataEssentials; user id = sa; Password = digital@PXL")]
        public string SaschaLocalDataBase {
            get {
                return ((string)(this["SaschaLocalDataBase"]));
            }
            set {
                this["SaschaLocalDataBase"] = value;
            }
        }
    }
}
