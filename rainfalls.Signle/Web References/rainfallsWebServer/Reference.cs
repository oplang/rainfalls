﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace rainfalls.Rtu.Single.rainfallsWebServer {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="rainfallsSoap", Namespace="http://tempuri.org/")]
    public partial class rainfalls : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback EchoMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback getDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback getChildSiteOperationCompleted;
        
        private System.Threading.SendOrPostCallback checkUpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback registerOperationCompleted;
        
        private System.Threading.SendOrPostCallback loginOperationCompleted;
        
        private System.Threading.SendOrPostCallback rebindDevicedOperationCompleted;
        
        private System.Threading.SendOrPostCallback getIMEIOperationCompleted;
        
        private System.Threading.SendOrPostCallback getSiteBaseOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public rainfalls() {
            this.Url = global::rainfalls.Rtu.Single.Properties.Settings.Default.rainfalls_Signle_rainfallsWebServer_rainfalls;
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
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event EchoMessageCompletedEventHandler EchoMessageCompleted;
        
        /// <remarks/>
        public event getDataCompletedEventHandler getDataCompleted;
        
        /// <remarks/>
        public event getChildSiteCompletedEventHandler getChildSiteCompleted;
        
        /// <remarks/>
        public event checkUpdateCompletedEventHandler checkUpdateCompleted;
        
        /// <remarks/>
        public event registerCompletedEventHandler registerCompleted;
        
        /// <remarks/>
        public event loginCompletedEventHandler loginCompleted;
        
        /// <remarks/>
        public event rebindDevicedCompletedEventHandler rebindDevicedCompleted;
        
        /// <remarks/>
        public event getIMEICompletedEventHandler getIMEICompleted;
        
        /// <remarks/>
        public event getSiteBaseCompletedEventHandler getSiteBaseCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EchoMessage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string EchoMessage(string msg) {
            object[] results = this.Invoke("EchoMessage", new object[] {
                        msg});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void EchoMessageAsync(string msg) {
            this.EchoMessageAsync(msg, null);
        }
        
        /// <remarks/>
        public void EchoMessageAsync(string msg, object userState) {
            if ((this.EchoMessageOperationCompleted == null)) {
                this.EchoMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEchoMessageOperationCompleted);
            }
            this.InvokeAsync("EchoMessage", new object[] {
                        msg}, this.EchoMessageOperationCompleted, userState);
        }
        
        private void OnEchoMessageOperationCompleted(object arg) {
            if ((this.EchoMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EchoMessageCompleted(this, new EchoMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public rtuClick[] getData(string term_sn, long lastTime) {
            object[] results = this.Invoke("getData", new object[] {
                        term_sn,
                        lastTime});
            return ((rtuClick[])(results[0]));
        }
        
        /// <remarks/>
        public void getDataAsync(string term_sn, long lastTime) {
            this.getDataAsync(term_sn, lastTime, null);
        }
        
        /// <remarks/>
        public void getDataAsync(string term_sn, long lastTime, object userState) {
            if ((this.getDataOperationCompleted == null)) {
                this.getDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetDataOperationCompleted);
            }
            this.InvokeAsync("getData", new object[] {
                        term_sn,
                        lastTime}, this.getDataOperationCompleted, userState);
        }
        
        private void OngetDataOperationCompleted(object arg) {
            if ((this.getDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getDataCompleted(this, new getDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getChildSite", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public childStruct[] getChildSite(string siteId) {
            object[] results = this.Invoke("getChildSite", new object[] {
                        siteId});
            return ((childStruct[])(results[0]));
        }
        
        /// <remarks/>
        public void getChildSiteAsync(string siteId) {
            this.getChildSiteAsync(siteId, null);
        }
        
        /// <remarks/>
        public void getChildSiteAsync(string siteId, object userState) {
            if ((this.getChildSiteOperationCompleted == null)) {
                this.getChildSiteOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetChildSiteOperationCompleted);
            }
            this.InvokeAsync("getChildSite", new object[] {
                        siteId}, this.getChildSiteOperationCompleted, userState);
        }
        
        private void OngetChildSiteOperationCompleted(object arg) {
            if ((this.getChildSiteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getChildSiteCompleted(this, new getChildSiteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/checkUpdate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string checkUpdate(string siteId, long curVersion) {
            object[] results = this.Invoke("checkUpdate", new object[] {
                        siteId,
                        curVersion});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void checkUpdateAsync(string siteId, long curVersion) {
            this.checkUpdateAsync(siteId, curVersion, null);
        }
        
        /// <remarks/>
        public void checkUpdateAsync(string siteId, long curVersion, object userState) {
            if ((this.checkUpdateOperationCompleted == null)) {
                this.checkUpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OncheckUpdateOperationCompleted);
            }
            this.InvokeAsync("checkUpdate", new object[] {
                        siteId,
                        curVersion}, this.checkUpdateOperationCompleted, userState);
        }
        
        private void OncheckUpdateOperationCompleted(object arg) {
            if ((this.checkUpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.checkUpdateCompleted(this, new checkUpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/register", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int register(string tel, string pwd, string imei) {
            object[] results = this.Invoke("register", new object[] {
                        tel,
                        pwd,
                        imei});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void registerAsync(string tel, string pwd, string imei) {
            this.registerAsync(tel, pwd, imei, null);
        }
        
        /// <remarks/>
        public void registerAsync(string tel, string pwd, string imei, object userState) {
            if ((this.registerOperationCompleted == null)) {
                this.registerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnregisterOperationCompleted);
            }
            this.InvokeAsync("register", new object[] {
                        tel,
                        pwd,
                        imei}, this.registerOperationCompleted, userState);
        }
        
        private void OnregisterOperationCompleted(object arg) {
            if ((this.registerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.registerCompleted(this, new registerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/login", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int login(string tel, string pwd, string imei) {
            object[] results = this.Invoke("login", new object[] {
                        tel,
                        pwd,
                        imei});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void loginAsync(string tel, string pwd, string imei) {
            this.loginAsync(tel, pwd, imei, null);
        }
        
        /// <remarks/>
        public void loginAsync(string tel, string pwd, string imei, object userState) {
            if ((this.loginOperationCompleted == null)) {
                this.loginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnloginOperationCompleted);
            }
            this.InvokeAsync("login", new object[] {
                        tel,
                        pwd,
                        imei}, this.loginOperationCompleted, userState);
        }
        
        private void OnloginOperationCompleted(object arg) {
            if ((this.loginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.loginCompleted(this, new loginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/rebindDeviced", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int rebindDeviced(string tel, string pwd, string imei) {
            object[] results = this.Invoke("rebindDeviced", new object[] {
                        tel,
                        pwd,
                        imei});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void rebindDevicedAsync(string tel, string pwd, string imei) {
            this.rebindDevicedAsync(tel, pwd, imei, null);
        }
        
        /// <remarks/>
        public void rebindDevicedAsync(string tel, string pwd, string imei, object userState) {
            if ((this.rebindDevicedOperationCompleted == null)) {
                this.rebindDevicedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnrebindDevicedOperationCompleted);
            }
            this.InvokeAsync("rebindDeviced", new object[] {
                        tel,
                        pwd,
                        imei}, this.rebindDevicedOperationCompleted, userState);
        }
        
        private void OnrebindDevicedOperationCompleted(object arg) {
            if ((this.rebindDevicedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.rebindDevicedCompleted(this, new rebindDevicedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getIMEI", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getIMEI(string tel) {
            object[] results = this.Invoke("getIMEI", new object[] {
                        tel});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getIMEIAsync(string tel) {
            this.getIMEIAsync(tel, null);
        }
        
        /// <remarks/>
        public void getIMEIAsync(string tel, object userState) {
            if ((this.getIMEIOperationCompleted == null)) {
                this.getIMEIOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetIMEIOperationCompleted);
            }
            this.InvokeAsync("getIMEI", new object[] {
                        tel}, this.getIMEIOperationCompleted, userState);
        }
        
        private void OngetIMEIOperationCompleted(object arg) {
            if ((this.getIMEICompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getIMEICompleted(this, new getIMEICompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getSiteBase", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getSiteBase() {
            object[] results = this.Invoke("getSiteBase", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getSiteBaseAsync() {
            this.getSiteBaseAsync(null);
        }
        
        /// <remarks/>
        public void getSiteBaseAsync(object userState) {
            if ((this.getSiteBaseOperationCompleted == null)) {
                this.getSiteBaseOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetSiteBaseOperationCompleted);
            }
            this.InvokeAsync("getSiteBase", new object[0], this.getSiteBaseOperationCompleted, userState);
        }
        
        private void OngetSiteBaseOperationCompleted(object arg) {
            if ((this.getSiteBaseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getSiteBaseCompleted(this, new getSiteBaseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class rtuClick {
        
        private long tmField;
        
        private string voltageField;
        
        /// <remarks/>
        public long tm {
            get {
                return this.tmField;
            }
            set {
                this.tmField = value;
            }
        }
        
        /// <remarks/>
        public string voltage {
            get {
                return this.voltageField;
            }
            set {
                this.voltageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class childStruct {
        
        private string tERM_SNField;
        
        private string site_kmField;
        
        private string qjField;
        
        private string site_nameField;
        
        private string site_idField;
        
        /// <remarks/>
        public string TERM_SN {
            get {
                return this.tERM_SNField;
            }
            set {
                this.tERM_SNField = value;
            }
        }
        
        /// <remarks/>
        public string site_km {
            get {
                return this.site_kmField;
            }
            set {
                this.site_kmField = value;
            }
        }
        
        /// <remarks/>
        public string qj {
            get {
                return this.qjField;
            }
            set {
                this.qjField = value;
            }
        }
        
        /// <remarks/>
        public string site_name {
            get {
                return this.site_nameField;
            }
            set {
                this.site_nameField = value;
            }
        }
        
        /// <remarks/>
        public string site_id {
            get {
                return this.site_idField;
            }
            set {
                this.site_idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void EchoMessageCompletedEventHandler(object sender, EchoMessageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EchoMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EchoMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void getDataCompletedEventHandler(object sender, getDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public rtuClick[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((rtuClick[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void getChildSiteCompletedEventHandler(object sender, getChildSiteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getChildSiteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getChildSiteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public childStruct[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((childStruct[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void checkUpdateCompletedEventHandler(object sender, checkUpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class checkUpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal checkUpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void registerCompletedEventHandler(object sender, registerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class registerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal registerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void loginCompletedEventHandler(object sender, loginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class loginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal loginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void rebindDevicedCompletedEventHandler(object sender, rebindDevicedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class rebindDevicedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal rebindDevicedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void getIMEICompletedEventHandler(object sender, getIMEICompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getIMEICompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getIMEICompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void getSiteBaseCompletedEventHandler(object sender, getSiteBaseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getSiteBaseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getSiteBaseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591