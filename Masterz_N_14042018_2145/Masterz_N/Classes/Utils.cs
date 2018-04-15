using Masterz_N.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Masterz_N
{
    internal static class Utils
    {
        public static List<User> DtTolist(DataTable dt, ref List<User> list)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    list = dt.AsEnumerable().Select(user => new User()
                    {
                        UserId = user.Field<int>("UserId"),
                        UserFirstName = user.Field<string>("UserFirstName"),
                        UserLastName = user.Field<string>("UserLastName"),
                        UserName = user.Field<string>("UserName"),
                        UserPassword = user.Field<string>("UserPassword"),
                        UserEmail = user.Field<string>("UserEmail"),
                        UserPhone = user.Field<string>("UserPhone"),
                        UserHotemHoze = user.Field<string>("UserHotemHoze"),
                        UserHozeName = user.Field<string>("UserHozeName"),
                        UserCity = user.Field<string>("UserCity"),
                        SugZiudBeBaaluto = user.Field<string>("SugZiudBeBaaluto"),
                        DateEntered = user.Field<string>("DateEntered"),
                        DateUpdated = user.Field<string>("DateUpdated")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return list;
        }


        public static void DataTableToList<T>(DataTable table, ref  List<T> lstT) where T : new()
        {
            try
            {
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    if (obj != null)
                    {
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            try
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                if (propertyInfo != null && propertyInfo.CanWrite)
                                {
                                    if (!row.Table.Columns.Contains(prop.Name))
                                    {
                                        continue;
                                    }
                                    if (row[prop.Name] == DBNull.Value)
                                    {
                                        continue;
                                    }
                                    
                                    object objRow = row[prop.Name];
                                    if (objRow.GetType() == typeof(System.Guid))
                                    {
                                        objRow = row[prop.Name].ToString();
                                    }
                                    propertyInfo.SetValue(obj, Convert.ChangeType(objRow, propertyInfo.PropertyType), null);
                                }
                            }
                            catch (Exception ex)
                            {
                               //log
                                continue;
                            }
                        }
                        lstT.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }
}
