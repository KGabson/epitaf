﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :2.0.50727.3074
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 2.0.5.0
// 
namespace MyLiveMesh.UserDirectoryServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="UserDirectoryServiceReference.UserDirectory")]
    public interface UserDirectory {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:UserDirectory/CreateDirectoryOnServer", ReplyAction="urn:UserDirectory/CreateDirectoryOnServerResponse")]
        System.IAsyncResult BeginCreateDirectoryOnServer(string path, System.AsyncCallback callback, object asyncState);
        
        bool EndCreateDirectoryOnServer(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:UserDirectory/getDirectoryTreeFromPath", ReplyAction="urn:UserDirectory/getDirectoryTreeFromPathResponse")]
        System.IAsyncResult BegingetDirectoryTreeFromPath(string path, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<string> EndgetDirectoryTreeFromPath(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:UserDirectory/getFilesFromPath", ReplyAction="urn:UserDirectory/getFilesFromPathResponse")]
        System.IAsyncResult BegingetFilesFromPath(string path, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>> EndgetFilesFromPath(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:UserDirectory/ShareFolder", ReplyAction="urn:UserDirectory/ShareFolderResponse")]
        System.IAsyncResult BeginShareFolder(int ownerId, string shareLogin, string folderPath, bool friendIsOwner, System.AsyncCallback callback, object asyncState);
        
        Common.BusinessObjects.ServiceResult EndShareFolder(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:UserDirectory/GetSharedFolders", ReplyAction="urn:UserDirectory/GetSharedFoldersResponse")]
        System.IAsyncResult BeginGetSharedFolders(int userId, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder> EndGetSharedFolders(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:UserDirectory/deletePath", ReplyAction="urn:UserDirectory/deletePathResponse")]
        System.IAsyncResult BegindeletePath(string path, System.AsyncCallback callback, object asyncState);
        
        bool EnddeletePath(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface UserDirectoryChannel : MyLiveMesh.UserDirectoryServiceReference.UserDirectory, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CreateDirectoryOnServerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CreateDirectoryOnServerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class getDirectoryTreeFromPathCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getDirectoryTreeFromPathCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<string> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<string>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class getFilesFromPathCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getFilesFromPathCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ShareFolderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ShareFolderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Common.BusinessObjects.ServiceResult Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Common.BusinessObjects.ServiceResult)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetSharedFoldersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetSharedFoldersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class deletePathCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public deletePathCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class UserDirectoryClient : System.ServiceModel.ClientBase<MyLiveMesh.UserDirectoryServiceReference.UserDirectory>, MyLiveMesh.UserDirectoryServiceReference.UserDirectory {
        
        private BeginOperationDelegate onBeginCreateDirectoryOnServerDelegate;
        
        private EndOperationDelegate onEndCreateDirectoryOnServerDelegate;
        
        private System.Threading.SendOrPostCallback onCreateDirectoryOnServerCompletedDelegate;
        
        private BeginOperationDelegate onBegingetDirectoryTreeFromPathDelegate;
        
        private EndOperationDelegate onEndgetDirectoryTreeFromPathDelegate;
        
        private System.Threading.SendOrPostCallback ongetDirectoryTreeFromPathCompletedDelegate;
        
        private BeginOperationDelegate onBegingetFilesFromPathDelegate;
        
        private EndOperationDelegate onEndgetFilesFromPathDelegate;
        
        private System.Threading.SendOrPostCallback ongetFilesFromPathCompletedDelegate;
        
        private BeginOperationDelegate onBeginShareFolderDelegate;
        
        private EndOperationDelegate onEndShareFolderDelegate;
        
        private System.Threading.SendOrPostCallback onShareFolderCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetSharedFoldersDelegate;
        
        private EndOperationDelegate onEndGetSharedFoldersDelegate;
        
        private System.Threading.SendOrPostCallback onGetSharedFoldersCompletedDelegate;
        
        private BeginOperationDelegate onBegindeletePathDelegate;
        
        private EndOperationDelegate onEnddeletePathDelegate;
        
        private System.Threading.SendOrPostCallback ondeletePathCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public UserDirectoryClient() {
        }
        
        public UserDirectoryClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserDirectoryClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserDirectoryClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserDirectoryClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<CreateDirectoryOnServerCompletedEventArgs> CreateDirectoryOnServerCompleted;
        
        public event System.EventHandler<getDirectoryTreeFromPathCompletedEventArgs> getDirectoryTreeFromPathCompleted;
        
        public event System.EventHandler<getFilesFromPathCompletedEventArgs> getFilesFromPathCompleted;
        
        public event System.EventHandler<ShareFolderCompletedEventArgs> ShareFolderCompleted;
        
        public event System.EventHandler<GetSharedFoldersCompletedEventArgs> GetSharedFoldersCompleted;
        
        public event System.EventHandler<deletePathCompletedEventArgs> deletePathCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.BeginCreateDirectoryOnServer(string path, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateDirectoryOnServer(path, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool MyLiveMesh.UserDirectoryServiceReference.UserDirectory.EndCreateDirectoryOnServer(System.IAsyncResult result) {
            return base.Channel.EndCreateDirectoryOnServer(result);
        }
        
        private System.IAsyncResult OnBeginCreateDirectoryOnServer(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string path = ((string)(inValues[0]));
            return ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).BeginCreateDirectoryOnServer(path, callback, asyncState);
        }
        
        private object[] OnEndCreateDirectoryOnServer(System.IAsyncResult result) {
            bool retVal = ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).EndCreateDirectoryOnServer(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCreateDirectoryOnServerCompleted(object state) {
            if ((this.CreateDirectoryOnServerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateDirectoryOnServerCompleted(this, new CreateDirectoryOnServerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateDirectoryOnServerAsync(string path) {
            this.CreateDirectoryOnServerAsync(path, null);
        }
        
        public void CreateDirectoryOnServerAsync(string path, object userState) {
            if ((this.onBeginCreateDirectoryOnServerDelegate == null)) {
                this.onBeginCreateDirectoryOnServerDelegate = new BeginOperationDelegate(this.OnBeginCreateDirectoryOnServer);
            }
            if ((this.onEndCreateDirectoryOnServerDelegate == null)) {
                this.onEndCreateDirectoryOnServerDelegate = new EndOperationDelegate(this.OnEndCreateDirectoryOnServer);
            }
            if ((this.onCreateDirectoryOnServerCompletedDelegate == null)) {
                this.onCreateDirectoryOnServerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateDirectoryOnServerCompleted);
            }
            base.InvokeAsync(this.onBeginCreateDirectoryOnServerDelegate, new object[] {
                        path}, this.onEndCreateDirectoryOnServerDelegate, this.onCreateDirectoryOnServerCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.BegingetDirectoryTreeFromPath(string path, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetDirectoryTreeFromPath(path, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<string> MyLiveMesh.UserDirectoryServiceReference.UserDirectory.EndgetDirectoryTreeFromPath(System.IAsyncResult result) {
            return base.Channel.EndgetDirectoryTreeFromPath(result);
        }
        
        private System.IAsyncResult OnBegingetDirectoryTreeFromPath(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string path = ((string)(inValues[0]));
            return ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).BegingetDirectoryTreeFromPath(path, callback, asyncState);
        }
        
        private object[] OnEndgetDirectoryTreeFromPath(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<string> retVal = ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).EndgetDirectoryTreeFromPath(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetDirectoryTreeFromPathCompleted(object state) {
            if ((this.getDirectoryTreeFromPathCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getDirectoryTreeFromPathCompleted(this, new getDirectoryTreeFromPathCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getDirectoryTreeFromPathAsync(string path) {
            this.getDirectoryTreeFromPathAsync(path, null);
        }
        
        public void getDirectoryTreeFromPathAsync(string path, object userState) {
            if ((this.onBegingetDirectoryTreeFromPathDelegate == null)) {
                this.onBegingetDirectoryTreeFromPathDelegate = new BeginOperationDelegate(this.OnBegingetDirectoryTreeFromPath);
            }
            if ((this.onEndgetDirectoryTreeFromPathDelegate == null)) {
                this.onEndgetDirectoryTreeFromPathDelegate = new EndOperationDelegate(this.OnEndgetDirectoryTreeFromPath);
            }
            if ((this.ongetDirectoryTreeFromPathCompletedDelegate == null)) {
                this.ongetDirectoryTreeFromPathCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetDirectoryTreeFromPathCompleted);
            }
            base.InvokeAsync(this.onBegingetDirectoryTreeFromPathDelegate, new object[] {
                        path}, this.onEndgetDirectoryTreeFromPathDelegate, this.ongetDirectoryTreeFromPathCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.BegingetFilesFromPath(string path, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetFilesFromPath(path, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>> MyLiveMesh.UserDirectoryServiceReference.UserDirectory.EndgetFilesFromPath(System.IAsyncResult result) {
            return base.Channel.EndgetFilesFromPath(result);
        }
        
        private System.IAsyncResult OnBegingetFilesFromPath(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string path = ((string)(inValues[0]));
            return ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).BegingetFilesFromPath(path, callback, asyncState);
        }
        
        private object[] OnEndgetFilesFromPath(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>> retVal = ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).EndgetFilesFromPath(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetFilesFromPathCompleted(object state) {
            if ((this.getFilesFromPathCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getFilesFromPathCompleted(this, new getFilesFromPathCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getFilesFromPathAsync(string path) {
            this.getFilesFromPathAsync(path, null);
        }
        
        public void getFilesFromPathAsync(string path, object userState) {
            if ((this.onBegingetFilesFromPathDelegate == null)) {
                this.onBegingetFilesFromPathDelegate = new BeginOperationDelegate(this.OnBegingetFilesFromPath);
            }
            if ((this.onEndgetFilesFromPathDelegate == null)) {
                this.onEndgetFilesFromPathDelegate = new EndOperationDelegate(this.OnEndgetFilesFromPath);
            }
            if ((this.ongetFilesFromPathCompletedDelegate == null)) {
                this.ongetFilesFromPathCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetFilesFromPathCompleted);
            }
            base.InvokeAsync(this.onBegingetFilesFromPathDelegate, new object[] {
                        path}, this.onEndgetFilesFromPathDelegate, this.ongetFilesFromPathCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.BeginShareFolder(int ownerId, string shareLogin, string folderPath, bool friendIsOwner, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginShareFolder(ownerId, shareLogin, folderPath, friendIsOwner, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Common.BusinessObjects.ServiceResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.EndShareFolder(System.IAsyncResult result) {
            return base.Channel.EndShareFolder(result);
        }
        
        private System.IAsyncResult OnBeginShareFolder(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int ownerId = ((int)(inValues[0]));
            string shareLogin = ((string)(inValues[1]));
            string folderPath = ((string)(inValues[2]));
            bool friendIsOwner = ((bool)(inValues[3]));
            return ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).BeginShareFolder(ownerId, shareLogin, folderPath, friendIsOwner, callback, asyncState);
        }
        
        private object[] OnEndShareFolder(System.IAsyncResult result) {
            Common.BusinessObjects.ServiceResult retVal = ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).EndShareFolder(result);
            return new object[] {
                    retVal};
        }
        
        private void OnShareFolderCompleted(object state) {
            if ((this.ShareFolderCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ShareFolderCompleted(this, new ShareFolderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ShareFolderAsync(int ownerId, string shareLogin, string folderPath, bool friendIsOwner) {
            this.ShareFolderAsync(ownerId, shareLogin, folderPath, friendIsOwner, null);
        }
        
        public void ShareFolderAsync(int ownerId, string shareLogin, string folderPath, bool friendIsOwner, object userState) {
            if ((this.onBeginShareFolderDelegate == null)) {
                this.onBeginShareFolderDelegate = new BeginOperationDelegate(this.OnBeginShareFolder);
            }
            if ((this.onEndShareFolderDelegate == null)) {
                this.onEndShareFolderDelegate = new EndOperationDelegate(this.OnEndShareFolder);
            }
            if ((this.onShareFolderCompletedDelegate == null)) {
                this.onShareFolderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnShareFolderCompleted);
            }
            base.InvokeAsync(this.onBeginShareFolderDelegate, new object[] {
                        ownerId,
                        shareLogin,
                        folderPath,
                        friendIsOwner}, this.onEndShareFolderDelegate, this.onShareFolderCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.BeginGetSharedFolders(int userId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetSharedFolders(userId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder> MyLiveMesh.UserDirectoryServiceReference.UserDirectory.EndGetSharedFolders(System.IAsyncResult result) {
            return base.Channel.EndGetSharedFolders(result);
        }
        
        private System.IAsyncResult OnBeginGetSharedFolders(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int userId = ((int)(inValues[0]));
            return ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).BeginGetSharedFolders(userId, callback, asyncState);
        }
        
        private object[] OnEndGetSharedFolders(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder> retVal = ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).EndGetSharedFolders(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetSharedFoldersCompleted(object state) {
            if ((this.GetSharedFoldersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetSharedFoldersCompleted(this, new GetSharedFoldersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetSharedFoldersAsync(int userId) {
            this.GetSharedFoldersAsync(userId, null);
        }
        
        public void GetSharedFoldersAsync(int userId, object userState) {
            if ((this.onBeginGetSharedFoldersDelegate == null)) {
                this.onBeginGetSharedFoldersDelegate = new BeginOperationDelegate(this.OnBeginGetSharedFolders);
            }
            if ((this.onEndGetSharedFoldersDelegate == null)) {
                this.onEndGetSharedFoldersDelegate = new EndOperationDelegate(this.OnEndGetSharedFolders);
            }
            if ((this.onGetSharedFoldersCompletedDelegate == null)) {
                this.onGetSharedFoldersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetSharedFoldersCompleted);
            }
            base.InvokeAsync(this.onBeginGetSharedFoldersDelegate, new object[] {
                        userId}, this.onEndGetSharedFoldersDelegate, this.onGetSharedFoldersCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MyLiveMesh.UserDirectoryServiceReference.UserDirectory.BegindeletePath(string path, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegindeletePath(path, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool MyLiveMesh.UserDirectoryServiceReference.UserDirectory.EnddeletePath(System.IAsyncResult result) {
            return base.Channel.EnddeletePath(result);
        }
        
        private System.IAsyncResult OnBegindeletePath(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string path = ((string)(inValues[0]));
            return ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).BegindeletePath(path, callback, asyncState);
        }
        
        private object[] OnEnddeletePath(System.IAsyncResult result) {
            bool retVal = ((MyLiveMesh.UserDirectoryServiceReference.UserDirectory)(this)).EnddeletePath(result);
            return new object[] {
                    retVal};
        }
        
        private void OndeletePathCompleted(object state) {
            if ((this.deletePathCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.deletePathCompleted(this, new deletePathCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void deletePathAsync(string path) {
            this.deletePathAsync(path, null);
        }
        
        public void deletePathAsync(string path, object userState) {
            if ((this.onBegindeletePathDelegate == null)) {
                this.onBegindeletePathDelegate = new BeginOperationDelegate(this.OnBegindeletePath);
            }
            if ((this.onEnddeletePathDelegate == null)) {
                this.onEnddeletePathDelegate = new EndOperationDelegate(this.OnEnddeletePath);
            }
            if ((this.ondeletePathCompletedDelegate == null)) {
                this.ondeletePathCompletedDelegate = new System.Threading.SendOrPostCallback(this.OndeletePathCompleted);
            }
            base.InvokeAsync(this.onBegindeletePathDelegate, new object[] {
                        path}, this.onEnddeletePathDelegate, this.ondeletePathCompletedDelegate, userState);
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
        
        protected override MyLiveMesh.UserDirectoryServiceReference.UserDirectory CreateChannel() {
            return new UserDirectoryClientChannel(this);
        }
        
        private class UserDirectoryClientChannel : ChannelBase<MyLiveMesh.UserDirectoryServiceReference.UserDirectory>, MyLiveMesh.UserDirectoryServiceReference.UserDirectory {
            
            public UserDirectoryClientChannel(System.ServiceModel.ClientBase<MyLiveMesh.UserDirectoryServiceReference.UserDirectory> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginCreateDirectoryOnServer(string path, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = path;
                System.IAsyncResult _result = base.BeginInvoke("CreateDirectoryOnServer", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndCreateDirectoryOnServer(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("CreateDirectoryOnServer", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegingetDirectoryTreeFromPath(string path, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = path;
                System.IAsyncResult _result = base.BeginInvoke("getDirectoryTreeFromPath", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<string> EndgetDirectoryTreeFromPath(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<string> _result = ((System.Collections.ObjectModel.ObservableCollection<string>)(base.EndInvoke("getDirectoryTreeFromPath", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegingetFilesFromPath(string path, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = path;
                System.IAsyncResult _result = base.BeginInvoke("getFilesFromPath", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>> EndgetFilesFromPath(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>> _result = ((System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>)(base.EndInvoke("getFilesFromPath", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginShareFolder(int ownerId, string shareLogin, string folderPath, bool friendIsOwner, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = ownerId;
                _args[1] = shareLogin;
                _args[2] = folderPath;
                _args[3] = friendIsOwner;
                System.IAsyncResult _result = base.BeginInvoke("ShareFolder", _args, callback, asyncState);
                return _result;
            }
            
            public Common.BusinessObjects.ServiceResult EndShareFolder(System.IAsyncResult result) {
                object[] _args = new object[0];
                Common.BusinessObjects.ServiceResult _result = ((Common.BusinessObjects.ServiceResult)(base.EndInvoke("ShareFolder", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetSharedFolders(int userId, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = userId;
                System.IAsyncResult _result = base.BeginInvoke("GetSharedFolders", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder> EndGetSharedFolders(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder> _result = ((System.Collections.ObjectModel.ObservableCollection<Common.BusinessObjects.SharedFolder>)(base.EndInvoke("GetSharedFolders", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegindeletePath(string path, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = path;
                System.IAsyncResult _result = base.BeginInvoke("deletePath", _args, callback, asyncState);
                return _result;
            }
            
            public bool EnddeletePath(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("deletePath", _args, result)));
                return _result;
            }
        }
    }
}
