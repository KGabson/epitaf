using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using MyLiveMesh.Web.LinqToSql;

namespace MyLiveMesh.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AccountService
    {
        [OperationContract]
        public bool Authentify(string login, string password)
        {
            MyLiveMeshDBDataContext dbm = new MyLiveMeshDBDataContext();

            var user_count = (from q in dbm.users where q.login == login && q.password == password select q).Count();
            return (user_count == 1);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
