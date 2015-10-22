using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Funcionalidad
    {
        private const String SP_GET = "[HAY_TABLA].sp_select_funcionalidades_de_rol";
        private const String SP_GET_NEW = "[HAY_TABLA].sp_select_funcionalidades_de_rol_nuevo";
        private const String SP_INSERT = "[HAY_TABLA].sp_insertar_funcionalidad_en_rol";
        private const string SP_DELETE = "[HAY_TABLA].sp_borrar_funcionalidades_de_rol";

        public static DataTable Get(int rolId)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = rolId;
                //cmd.Parameters.Add("@nombre", SqlDbType.Int).Value = DBNull.Value;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable Get()
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_NEW, con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static void Insert(SqlConnection con, SqlTransaction trans, Int32 rolId, Int32 id)
        {
            var cmd = new SqlCommand(SP_INSERT, con, trans);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = rolId;
            cmd.Parameters.Add("@idFuncionalidad", SqlDbType.Int).Value = id;

            cmd.ExecuteNonQuery();
        }

        public static void Delete(SqlConnection con, SqlTransaction trans, Int32 rolId)
        {
            var cmd = new SqlCommand(SP_DELETE, con, trans);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@idrol", SqlDbType.Int).Value = rolId;

            cmd.ExecuteNonQuery();
        }
    }

}
