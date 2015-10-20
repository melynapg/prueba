using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AerolineaFrba
{
    class DataAccess
    {
        private static string GetConnectionString()
        {
            //esto esta configurado en la app.config
            return ConfigurationManager.ConnectionStrings["gdd"].ConnectionString;
        }

        //internal es public para los de la solucion , private para los demas
        internal static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }


        //esto no lo termine usando asi simplifico el ejemplo de conexion a bd
        internal static int ExecuteStoredProcedure(String spName, SqlConnection connection, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(spName, connection);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());

            return cmd.ExecuteNonQuery();
        }
    }
}
