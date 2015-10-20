using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
        public static class DataAccess
        {
            private static string GetConnectionString()
            {
                //esto esta configurado en la app.config
                return ConfigurationManager.ConnectionStrings["gdd"].ConnectionString;
            }

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(GetConnectionString());
            }       
    }
}
