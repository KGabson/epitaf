using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.BusinessObjects
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        public String Email { get; set; }

        public UserInfo()
        {
        }

        public UserInfo(int id, String login, String email)
        {
            Id = id;
            Login = login;
            Email = email;
        }
    }
}
