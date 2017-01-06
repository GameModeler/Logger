using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMLogger.Interfaces;
using System.Reflection;
using GMLogger.DataBase.Interfaces;

namespace GMLogger.DataBase.Utils
{
    public static class DataBaseUtils
    {
       /// <summary>
       /// Check if an object have all of its string properties empty
       /// </summary>
       /// <param name="myObject"></param>
       /// <returns>true if all of the object's string properties are empty,
       /// false otherwisse</returns>
        public static bool IsAllNullOrEmpty(IDbSettings myObject)
        {
            return !myObject.GetType().GetProperties()
                .Where(pi => pi.GetValue(myObject) is string)
                .Select(pi => (string)pi.GetValue(myObject))
                .Any(value => !string.IsNullOrEmpty(value));
        }

        public static string BuildDataSource(string server, string port)
        {
            return port != null ? server + ":" + port : server;
        }
    }
}
