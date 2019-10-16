﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace RSELFANG.swflup {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SWFRFLUPSoap", Namespace="http://seven/")]
    public partial class SWFRFLUP : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback EnviarWFOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SWFRFLUP() {
            this.Url = global::RSELFANG.Properties.Settings.Default.RSELFANG_swflup_SWFRFLUP;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event EnviarWFCompletedEventHandler EnviarWFCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://seven/EnviarWF", RequestNamespace="http://seven/", ResponseNamespace="http://seven/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TSalida EnviarWF(TOWfRflup toWfRflup) {
            object[] results = this.Invoke("EnviarWF", new object[] {
                        toWfRflup});
            return ((TSalida)(results[0]));
        }
        
        /// <remarks/>
        public void EnviarWFAsync(TOWfRflup toWfRflup) {
            this.EnviarWFAsync(toWfRflup, null);
        }
        
        /// <remarks/>
        public void EnviarWFAsync(TOWfRflup toWfRflup, object userState) {
            if ((this.EnviarWFOperationCompleted == null)) {
                this.EnviarWFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEnviarWFOperationCompleted);
            }
            this.InvokeAsync("EnviarWF", new object[] {
                        toWfRflup}, this.EnviarWFOperationCompleted, userState);
        }
        
        private void OnEnviarWFOperationCompleted(object arg) {
            if ((this.EnviarWFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EnviarWFCompleted(this, new EnviarWFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3062.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://seven/")]
    public partial class TOWfRflup {
        
        private int emp_codiField;
        
        private string cas_descField;
        
        private string usu_codiField;
        
        private string pro_codiField;
        
        private string frm_codiField;
        
        private string tbl_nameField;
        
        private string cam_nameField;
        
        private string num_contField;
        
        private string cas_narcField;
        
        private byte[] cas_archField;
        
        /// <comentarios/>
        public int emp_codi {
            get {
                return this.emp_codiField;
            }
            set {
                this.emp_codiField = value;
            }
        }
        
        /// <comentarios/>
        public string cas_desc {
            get {
                return this.cas_descField;
            }
            set {
                this.cas_descField = value;
            }
        }
        
        /// <comentarios/>
        public string usu_codi {
            get {
                return this.usu_codiField;
            }
            set {
                this.usu_codiField = value;
            }
        }
        
        /// <comentarios/>
        public string pro_codi {
            get {
                return this.pro_codiField;
            }
            set {
                this.pro_codiField = value;
            }
        }
        
        /// <comentarios/>
        public string frm_codi {
            get {
                return this.frm_codiField;
            }
            set {
                this.frm_codiField = value;
            }
        }
        
        /// <comentarios/>
        public string tbl_name {
            get {
                return this.tbl_nameField;
            }
            set {
                this.tbl_nameField = value;
            }
        }
        
        /// <comentarios/>
        public string cam_name {
            get {
                return this.cam_nameField;
            }
            set {
                this.cam_nameField = value;
            }
        }
        
        /// <comentarios/>
        public string num_cont {
            get {
                return this.num_contField;
            }
            set {
                this.num_contField = value;
            }
        }
        
        /// <comentarios/>
        public string cas_narc {
            get {
                return this.cas_narcField;
            }
            set {
                this.cas_narcField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] cas_arch {
            get {
                return this.cas_archField;
            }
            set {
                this.cas_archField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3062.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://seven/")]
    public partial class TSalida {
        
        private string retornoField;
        
        private string txtErrorField;
        
        private string tra_contField;
        
        private string tra_numeField;
        
        /// <comentarios/>
        public string Retorno {
            get {
                return this.retornoField;
            }
            set {
                this.retornoField = value;
            }
        }
        
        /// <comentarios/>
        public string TxtError {
            get {
                return this.txtErrorField;
            }
            set {
                this.txtErrorField = value;
            }
        }
        
        /// <comentarios/>
        public string Tra_cont {
            get {
                return this.tra_contField;
            }
            set {
                this.tra_contField = value;
            }
        }
        
        /// <comentarios/>
        public string Tra_nume {
            get {
                return this.tra_numeField;
            }
            set {
                this.tra_numeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void EnviarWFCompletedEventHandler(object sender, EnviarWFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EnviarWFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EnviarWFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TSalida Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TSalida)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591