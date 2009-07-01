using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

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

        // Ajoutez des opérations supplémentaires ici et marquez-les avec [OperationContract]
    }
}
