﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Felhasznalo", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class Felhasznalo : Client.ServiceReference1.Record {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AktivField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BNevField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FNevField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JelszoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JogField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Aktiv {
            get {
                return this.AktivField;
            }
            set {
                if ((this.AktivField.Equals(value) != true)) {
                    this.AktivField = value;
                    this.RaisePropertyChanged("Aktiv");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BNev {
            get {
                return this.BNevField;
            }
            set {
                if ((object.ReferenceEquals(this.BNevField, value) != true)) {
                    this.BNevField = value;
                    this.RaisePropertyChanged("BNev");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FNev {
            get {
                return this.FNevField;
            }
            set {
                if ((object.ReferenceEquals(this.FNevField, value) != true)) {
                    this.FNevField = value;
                    this.RaisePropertyChanged("FNev");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Jelszo {
            get {
                return this.JelszoField;
            }
            set {
                if ((object.ReferenceEquals(this.JelszoField, value) != true)) {
                    this.JelszoField = value;
                    this.RaisePropertyChanged("Jelszo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Jog {
            get {
                return this.JogField;
            }
            set {
                if ((this.JogField.Equals(value) != true)) {
                    this.JogField = value;
                    this.RaisePropertyChanged("Jog");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Record", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.ServiceReference1.Felhasznalo))]
    public partial class Record : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class ServiceFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FelhasznaloiLista", ReplyAction="http://tempuri.org/IService1/FelhasznaloiListaResponse")]
        Client.ServiceReference1.Felhasznalo[] FelhasznaloiLista();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FelhasznaloiLista", ReplyAction="http://tempuri.org/IService1/FelhasznaloiListaResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.Felhasznalo[]> FelhasznaloiListaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.ServiceReference1.ServiceFault), Action="http://tempuri.org/IService1/LoginServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/Server")]
        string Login(string bNev, string jelszo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string bNev, string jelszo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Logout", ReplyAction="http://tempuri.org/IService1/LogoutResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.ServiceReference1.ServiceFault), Action="http://tempuri.org/IService1/LogoutServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/Server")]
        string Logout(string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Logout", ReplyAction="http://tempuri.org/IService1/LogoutResponse")]
        System.Threading.Tasks.Task<string> LogoutAsync(string uid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Client.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Client.ServiceReference1.IService1>, Client.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.ServiceReference1.Felhasznalo[] FelhasznaloiLista() {
            return base.Channel.FelhasznaloiLista();
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.Felhasznalo[]> FelhasznaloiListaAsync() {
            return base.Channel.FelhasznaloiListaAsync();
        }
        
        public string Login(string bNev, string jelszo) {
            return base.Channel.Login(bNev, jelszo);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string bNev, string jelszo) {
            return base.Channel.LoginAsync(bNev, jelszo);
        }
        
        public string Logout(string uid) {
            return base.Channel.Logout(uid);
        }
        
        public System.Threading.Tasks.Task<string> LogoutAsync(string uid) {
            return base.Channel.LogoutAsync(uid);
        }
    }
}
