using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace KEService.Models.Data
{
    public class SQLConnection
    {

        static string _staticConnectionString;

        public static SqlConnection StaticSqlConnection
        {
            get
            {

                SqlConnection staticConnection = new SqlConnection();
                staticConnection.ConnectionString = StaticConnectionString;
                return staticConnection;
            }
        }

        public static string StaticConnectionString
        {
            set { _staticConnectionString = value; }
            get
            {
                if (!string.IsNullOrEmpty(_staticConnectionString))
                    return _staticConnectionString;

                string con = ConfigurationManager.AppSetting["ConnectionStrings:KeConnection"];
                //string con = ConfigurationManager.AppSetting["KeConnection"];

                return con;
            }


        }
    }
}
