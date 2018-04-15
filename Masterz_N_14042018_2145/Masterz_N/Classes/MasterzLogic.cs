using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Masterz_N.Classes;
using MySql.Data.MySqlClient;

namespace Masterz_N
{
    public class MasterzLogic
    {
        public List<User> GetUsers(int statusid)
        {

            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            dicParam.Add("@status", statusid.ToString());

            DataTable dt = DataManager.Instance.GetData("usp_GetUsers", dicParam);
            List<User> list = new List<User>();
            //Utils.DtTolist(dt, ref  list);
            Utils.DataTableToList<User>(dt, ref list);
            return list;
        }
        public User GetUser(int statusid)
        {

            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            dicParam.Add("@status", statusid.ToString());

            DataTable dt = DataManager.Instance.GetData("usp_GetCurentUser", dicParam);
            List<User> list = new List<User>();
            //Utils.DtTolist(dt, ref  list);
            Utils.DataTableToList<User>(dt, ref list);
            //if (list.Count>0)
            //{
            //    UpdateUser(list[0].UserID, 1);
            //    list[0].StatusID = 1;
            //}

            return list.Count > 0 ? list[0] : new User();
        }
        public User GetNextUser(int currentUserID)
        {

            UpdateUser(currentUserID, 2);
            SetNextUser();
            return GetUser(1);
        }
        public bool CreateUser(string clientname)
        {
            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            dicParam.Add("@clientName", clientname);
            bool res = DataManager.Instance.InsertUpdate("usp_InsertUsers", dicParam);
            return res;
        }
        public bool UpdateUser(int userID, int statusid)
        {

            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            dicParam.Add("@userID", userID.ToString());
            dicParam.Add("@status", statusid.ToString());

            bool res = DataManager.Instance.InsertUpdate("usp_UpdateUsers", dicParam);
            return res;
        }
        public bool SetNextUser()
        {
            Dictionary<string, string> dicParam = new Dictionary<string, string>();            
            dicParam.Add("@status", "1");

            bool res = DataManager.Instance.InsertUpdate("usp_UpdateNextUser", dicParam);
            return res;
        }
    }
}
