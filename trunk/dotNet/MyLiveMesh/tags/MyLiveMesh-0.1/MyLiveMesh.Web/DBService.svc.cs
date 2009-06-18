using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLiveMesh.Web
{
    // NOTE: If you change the class name "DBService" here, you must also update the reference to "DBService" in Web.config.
    public class DBService : IDBService
    {
        public bool Authentify(string login, string pass)
        {
            DBManagerDataContext dbm = new DBManagerDataContext();

            var nb_results = (from q in dbm.users where q.login.ToString() == login && q.password.ToString() == pass select q.id).Count();
            if (nb_results == 1)
                return true;
            return false;
        }
    }
}
