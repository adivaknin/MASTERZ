using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Masterz_N.Classes
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserFirstName { get; set; }
        [DataMember]
        public string UserLastName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string UserEmail { get; set; }
        [DataMember]
        public string UserPhone { get; set; }
        [DataMember]
        public string UserHotemHoze { get; set; }
        [DataMember]
        public string UserHozeName { get; set; }
        [DataMember]
        public string UserCity { get; set; }
        [DataMember]
        public string SugZiudBeBaaluto { get; set; }
        [DataMember]
        public string DateEntered { get; set; }
        [DataMember]
        public string DateUpdated { get; set; }
        [DataMember]
        public string RoleName { get; set; }
    }
}