using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using MyLiveMesh.Web.LinqToSql;
using Common.BusinessObjects;

namespace MyLiveMesh.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AccountService
    {
        private MyLiveMeshDBDataContext dbm = new MyLiveMeshDBDataContext();

        [OperationContract]
        public UserInfo Authentify(string login, string password)
        {
            var users = from q in dbm.users where q.login == login && q.password == password select q;
            UserInfo uInfo = null;
            foreach (user u in users)
            {
                uInfo = new UserInfo();
                uInfo.Id = u.id;
                uInfo.Login = u.login;
                uInfo.Email = u.email;
                break;
            }
            return uInfo;
        }

        [OperationContract]
        public void CreateAccount(string login, string password, string email)
        {
            user newUser = new user();
            //newUser.id 
            newUser.login = login;
            newUser.password = password;
            newUser.email = email;

            dbm.users.InsertOnSubmit(newUser);
            dbm.SubmitChanges();
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
