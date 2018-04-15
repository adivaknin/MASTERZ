using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Masterz_N.Classes;

namespace Masterz_N.Interface
{
     [ServiceContract]
    interface IMasterz
    {
       [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
         bool CreateUser(string clientName);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<User> GetUsers(int statusid);

        [OperationContract]
        [WebGet]
        User GetCurentUser(int statusid);

        [OperationContract]
        [WebGet]
        User GetNextUser(int currentUserID);
    }
}
