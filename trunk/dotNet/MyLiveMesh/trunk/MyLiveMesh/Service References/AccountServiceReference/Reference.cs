﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 2.0.5.0
// 
namespace MyLiveMesh.AccountServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="AccountServiceReference.AccountService")]
    public interface AccountService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:AccountService/Authentify", ReplyAction="urn:AccountService/AuthentifyResponse")]
        System.IAsyncResult BeginAuthentify(string login, string password, System.AsyncCallback callback, object asyncState);
        
        Common.BusinessObjects.UserInfo EndAuthentify(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:AccountService/CreateAccount", ReplyAction="urn:AccountService/CreateAccountResponse")]
        System.IAsyncResult BeginCreateAccount(string login, string password, string email, System.AsyncCallback callback, object asyncState);
        
        void EndCreateAccount(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface AccountServiceChannel : MyLiveMesh.AccountServiceReference.AccountService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class AuthentifyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public AuthentifyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Common.BusinessObjects.UserInfo Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Common.BusinessObjects.UserInfo)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class AccountServiceClient : System.ServiceModel.ClientBase<MyLiveMesh.AccountServiceReference.AccountService>, MyLiveMesh.AccountServiceReference.AccountService {
        
        private BeginOperationDelegate onBeginAuthentifyDelegate;
        
        private EndOperationDelegate onEndAuthentifyDelegate;
        
        private System.Threading.SendOrPostCallback onAuthentifyCompletedDelegate;
        
        private BeginOperationDelegate onBeginCreateAccountDelegate;
        
        private EndOperationDelegate onEndCreateAccountDelegate;
        
        private System.Threading.SendOrPostCallback onCreateAccountCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public AccountServiceClient() {
        }
        
        public AccountServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<AuthentifyCompletedEventArgs> AuthentifyCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CreateAccountCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.AccountServiceReference.AccountService.BeginAuthentify(string login, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAuthentify(login, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Common.BusinessObjects.UserInfo MyLiveMesh.AccountServiceReference.AccountService.EndAuthentify(System.IAsyncResult result) {
            return base.Channel.EndAuthentify(result);
        }
        
        private System.IAsyncResult OnBeginAuthentify(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((MyLiveMesh.AccountServiceReference.AccountService)(this)).BeginAuthentify(login, password, callback, asyncState);
        }
        
        private object[] OnEndAuthentify(System.IAsyncResult result) {
            Common.BusinessObjects.UserInfo retVal = ((MyLiveMesh.AccountServiceReference.AccountService)(this)).EndAuthentify(result);
            return new object[] {
                    retVal};
        }
        
        private void OnAuthentifyCompleted(object state) {
            if ((this.AuthentifyCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AuthentifyCompleted(this, new AuthentifyCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AuthentifyAsync(string login, string password) {
            this.AuthentifyAsync(login, password, null);
        }
        
        public void AuthentifyAsync(string login, string password, object userState) {
            if ((this.onBeginAuthentifyDelegate == null)) {
                this.onBeginAuthentifyDelegate = new BeginOperationDelegate(this.OnBeginAuthentify);
            }
            if ((this.onEndAuthentifyDelegate == null)) {
                this.onEndAuthentifyDelegate = new EndOperationDelegate(this.OnEndAuthentify);
            }
            if ((this.onAuthentifyCompletedDelegate == null)) {
                this.onAuthentifyCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAuthentifyCompleted);
            }
            base.InvokeAsync(this.onBeginAuthentifyDelegate, new object[] {
                        login,
                        password}, this.onEndAuthentifyDelegate, this.onAuthentifyCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.AccountServiceReference.AccountService.BeginCreateAccount(string login, string password, string email, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateAccount(login, password, email, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void MyLiveMesh.AccountServiceReference.AccountService.EndCreateAccount(System.IAsyncResult result) {
            base.Channel.EndCreateAccount(result);
        }
        
        private System.IAsyncResult OnBeginCreateAccount(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            string email = ((string)(inValues[2]));
            return ((MyLiveMesh.AccountServiceReference.AccountService)(this)).BeginCreateAccount(login, password, email, callback, asyncState);
        }
        
        private object[] OnEndCreateAccount(System.IAsyncResult result) {
            ((MyLiveMesh.AccountServiceReference.AccountService)(this)).EndCreateAccount(result);
            return null;
        }
        
        private void OnCreateAccountCompleted(object state) {
            if ((this.CreateAccountCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateAccountCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateAccountAsync(string login, string password, string email) {
            this.CreateAccountAsync(login, password, email, null);
        }
        
        public void CreateAccountAsync(string login, string password, string email, object userState) {
            if ((this.onBeginCreateAccountDelegate == null)) {
                this.onBeginCreateAccountDelegate = new BeginOperationDelegate(this.OnBeginCreateAccount);
            }
            if ((this.onEndCreateAccountDelegate == null)) {
                this.onEndCreateAccountDelegate = new EndOperationDelegate(this.OnEndCreateAccount);
            }
            if ((this.onCreateAccountCompletedDelegate == null)) {
                this.onCreateAccountCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateAccountCompleted);
            }
            base.InvokeAsync(this.onBeginCreateAccountDelegate, new object[] {
                        login,
                        password,
                        email}, this.onEndCreateAccountDelegate, this.onCreateAccountCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override MyLiveMesh.AccountServiceReference.AccountService CreateChannel() {
            return new AccountServiceClientChannel(this);
        }
        
        private class AccountServiceClientChannel : ChannelBase<MyLiveMesh.AccountServiceReference.AccountService>, MyLiveMesh.AccountServiceReference.AccountService {
            
            public AccountServiceClientChannel(System.ServiceModel.ClientBase<MyLiveMesh.AccountServiceReference.AccountService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginAuthentify(string login, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = login;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("Authentify", _args, callback, asyncState);
                return _result;
            }
            
            public Common.BusinessObjects.UserInfo EndAuthentify(System.IAsyncResult result) {
                object[] _args = new object[0];
                Common.BusinessObjects.UserInfo _result = ((Common.BusinessObjects.UserInfo)(base.EndInvoke("Authentify", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginCreateAccount(string login, string password, string email, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[3];
                _args[0] = login;
                _args[1] = password;
                _args[2] = email;
                System.IAsyncResult _result = base.BeginInvoke("CreateAccount", _args, callback, asyncState);
                return _result;
            }
            
            public void EndCreateAccount(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("CreateAccount", _args, result);
            }
        }
    }
}
