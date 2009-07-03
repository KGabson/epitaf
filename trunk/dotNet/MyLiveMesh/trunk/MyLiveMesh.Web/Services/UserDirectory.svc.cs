using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Web.UI.WebControls;
using Common.BusinessObjects;
using MyLiveMesh.Web.LinqToSql;

namespace MyLiveMesh.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserDirectory : System.Web.Services.WebService
    {
        private MyLiveMeshDBDataContext dbm = new MyLiveMeshDBDataContext();

        [OperationContract]
        public bool CreateDirectoryOnServer(string path)
        {
            string dirname = Server.MapPath("~") + @"\" + path.Replace("/", @"\");
            Debug.WriteLine("creation de " + dirname);
            if (File.Exists(path))
                return false;
            Directory.CreateDirectory(dirname);
            return true;
        }

        [OperationContract]
        public List<string> getDirectoryTreeFromPath(string path)
        {
            TreeNode node = new TreeNode();
            string fullpath = Server.MapPath("~") + @"\" + path.Replace("/", @"\");
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            List<string> listdirs = new List<string>();
            if (Directory.Exists(fullpath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullpath);
                dirs = new List<DirectoryInfo>(dirInfo.GetDirectories());
                listdirs.Add(path);
                foreach (DirectoryInfo dir in dirs)
                {
                    listdirs.Add(dir.Name);
                }
            }
            return listdirs;
        }

        [OperationContract]
        public List<List<string>> getFilesFromPath(string path)
        {
            List<List<string>> listFiles = new List<List<string>>();
            string fullpath = Server.MapPath("~") + @"\" + path.Replace("/", @"\");
            if (Directory.Exists(fullpath))
            {
                int i = 0;
                DirectoryInfo dirinfo = new DirectoryInfo(fullpath);
                foreach (DirectoryInfo dir in dirinfo.GetDirectories())
                {
                    listFiles.Add(new List<string>());
                    listFiles[i].Add(dir.Name);
                    listFiles[i].Add(".folder");
                    listFiles[i].Add("");
                    ++i;
                }
                foreach (FileInfo file in dirinfo.GetFiles())
                {
                    listFiles.Add(new List<string>());
                    listFiles[i].Add(file.Name);
                    listFiles[i].Add(file.Extension);
                    listFiles[i].Add(file.Length.ToString());
                    ++i;
                }
            }
            return listFiles;
        }

        [OperationContract]
        public ServiceResult ShareFolder(int ownerId, String shareLogin, String folderPath, bool friendIsOwner)
        {
            ServiceResult res = new ServiceResult();
            res.Success = false;

            //Checking given login
            //user friend = dbm.users.First(u => u.login == shareLogin);
            user friend = dbm.users.FirstOrDefault(u => u.login == shareLogin);
            if (friend == null)
            {
                res.ErrorMsg = "No such user in database";
                return res;
            }

            if (friend.id == ownerId)
            {
                res.ErrorMsg = "You cannot share a directory with yourself";
                return res;
            }

            //Checking existing sharings
            sharing existing_sharing = dbm.sharings.FirstOrDefault(s => s.folder_path.ToString() == folderPath && s.owner_id == ownerId && s.friend_id == friend.id);
            if (existing_sharing != null)
            {
                bool fio = (existing_sharing.friend_is_owner == 0) ? false : true;
                if (fio != friendIsOwner)
                {
                    existing_sharing.friend_is_owner = (friendIsOwner) ? 1 : 0;
                    dbm.SubmitChanges();
                    res.Success = true;
                    return res;
                }
                res.ErrorMsg = "This folder is already shared with " + shareLogin;
                return res;
            }

            //Creating new sharing
            sharing new_sharing = new sharing();
            new_sharing.owner_id = ownerId;
            new_sharing.friend_id = friend.id;
            new_sharing.friend_is_owner = (friendIsOwner) ? 1 : 0;
            new_sharing.folder_path = folderPath;
            dbm.sharings.InsertOnSubmit(new_sharing);
            dbm.SubmitChanges();
            res.Success = true;
            return res;
        }

        [OperationContract]
        public List<SharedFolder> GetSharedFolders(int userId)
        {
            List<SharedFolder> res = new List<SharedFolder>();

            var dir_entries = from q in dbm.sharings where q.friend_id == userId select q;
            foreach (sharing share in dir_entries)
            {
                SharedFolder sf = new SharedFolder();
                sf.RootPath = share.folder_path;
                sf.FolderName = share.folder_path.Substring(share.folder_path.LastIndexOf('/'));
                if (sf.FolderName != "/" && sf.FolderName.Length > 1)
                    sf.FolderName = sf.FolderName.Substring(1);
                sf.IsOwner = (share.friend_is_owner == 1) ? true : false;
                user u = dbm.users.First(f => f.id == share.owner_id);
                sf.Owner = new UserInfo(u.id, u.login, u.email);
                res.Add(sf);
            }
            return res;
        }

        [OperationContract]
        public bool deletePath(string path)
        {
            string fullPath = Server.MapPath("~") + @"\" + path.Replace("/", @"\");
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                if (File.Exists(fullPath))
                    return false;
                return true;
            }
            else if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath);
                if (Directory.Exists(fullPath))
                    return false;
                return true;
            }
            return true;
        }
    }
}
