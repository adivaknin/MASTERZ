using Masterz_N.Classes;
using Masterz_N.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Masterz_N
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MasterzAPI : IMasterz
    {
        public bool CreateUser(string clientName)
        {
            bool res = false;
            do
            {
                if (string.IsNullOrEmpty(clientName))
                {
                    break;
                }
                if (string.IsNullOrEmpty(clientName.Trim()))
                {
                    break;
                }
                MasterzLogic userLogic = new MasterzLogic();
                res = userLogic.CreateUser(clientName);

            } while (false);
            return res;
        }

        public List<User> GetUsers(int statusid)
        {
            List<User> res = new List<User>();
            do
            {
                if (statusid < 0)
                {
                    break;
                }
                MasterzLogic userLogic = new MasterzLogic();
                res = userLogic.GetUsers(statusid);

            } while (false);
            return res;
        }
        public User GetCurentUser(int statusid)
        {
            User res = new User();
            do
            {
                if (statusid < 0)
                {
                    break;
                }
                MasterzLogic userLogic = new MasterzLogic();
                res = userLogic.GetUser(statusid);

            } while (false);
            return res;
        }
        //public bool UpdateUser(int UserID, int statusid)
        //{
        //    bool res = false;
        //    do
        //    {
        //        if (UserID <= 0)
        //        {
        //            break;
        //        }
        //        if (statusid < 0)
        //        {
        //            break;
        //        }

        //        UserLogic userLogic = new UserLogic();
        //        res = userLogic.UpdateUser(userID,statusid);

        //    } while (false);
        //    return res;
        //}


        public User GetNextUser(int currentUserID)
        {
            User res = new User();
            do
            {
                if (currentUserID < 0)
                {
                    break;
                }
                MasterzLogic userLogic = new MasterzLogic();
                res = userLogic.GetNextUser(currentUserID);

            } while (false);
            return res;
        }
    }
}
