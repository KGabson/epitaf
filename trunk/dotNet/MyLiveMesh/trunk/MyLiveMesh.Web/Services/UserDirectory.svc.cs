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

namespace MyLiveMesh.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserDirectory : System.Web.Services.WebService
    {
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
        // Ajoutez des opérations supplémentaires ici et marquez-les avec [OperationContract]
    }
}
