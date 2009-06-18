using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLiveMesh.Web
{
    // NOTE: If you change the interface name "IDBService" here, you must also update the reference to "IDBService" in Web.config.
    [ServiceContract]
    public interface IDBService
    {
        [OperationContract]
        bool Authentify(string login, string pass);
        
    }
}
