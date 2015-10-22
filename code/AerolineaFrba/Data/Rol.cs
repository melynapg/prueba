using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public static class Rol
    {
        private const String SP_GET_BY_ID = "[HAY_TABLA].sp_get_rol_by_id";
        private const String SP_GET_BY_NAME = "[HAY_TABLA].sp_select_roles";
        private const String SP_INSERT = "[HAY_TABLA].sp_insertar_Rol";
        private const String SP_UPDATE = "[HAY_TABLA].sp_modificacion_Rol";
        private const String SP_DELETE = "[HAY_TABLA].sp_baja_Rol";
        //private const String SP_GET_FUNCIONALIDADES = "sp_select_funcionalidades_de_rol";

        public static DataTable GetById(int id)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_ID, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        public static DataTable Get(String nombreFiltro)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_NAME, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (String.IsNullOrEmpty(nombreFiltro))
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombreFiltro;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }

        /*public static DataTable GetFuncionalidades(Int32 idRol)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_FUNCIONALIDADES, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = idRol;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }

            return table;
        }*/

        public static int Insertar(String nombre, Boolean activo)
        {
            int id_insertado = -1;
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_INSERT, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = activo;

                con.Open();
                id_insertado = (int)cmd.ExecuteScalar();
                con.Close();
            }

            return id_insertado;
        }
        public static void Actualizar(int id, String nombre, Boolean activo)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_UPDATE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = activo;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Eliminar(int id)
        {
            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_DELETE, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
