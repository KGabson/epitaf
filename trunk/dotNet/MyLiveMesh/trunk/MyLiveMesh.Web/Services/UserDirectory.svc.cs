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
            string fullpath = Server.MapPath("~") + @"\" + path.Replace("/", @"\");
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            List<string> listdirs = new List<string>();
            if (Directory.Exists(fullpath))
            {
                Debug.WriteLine("je vais chercher dans " + fullpath);
                DirectoryInfo dirInfo = new DirectoryInfo(fullpath);
                dirs = new List<DirectoryInfo>(dirInfo.GetDirectories());
                foreach (DirectoryInfo dir in dirs)
                {
                    Debug.WriteLine("dir = " + dir.Name);
                    listdirs.Add(dir.Name);
                }
            }
            return listdirs;
        }

        // Ajoutez des opérations supplémentaires ici et marquez-les avec [OperationContract]
    }
}
