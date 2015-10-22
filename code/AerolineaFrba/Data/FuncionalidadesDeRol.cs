using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public sealed class FuncionalidadDeRol
    {
        private const String SP_GET_BY_ID = "[HAY_TABLA].sp_select_funcionalidades_de_rol";
        private const String SP_INSERT = "[HAY_TABLA].sp_insertar_funcionalidad_a_rol";
        private const String SP_DELETE = "[HAY_TABLA].sp_borrar_funcionalidades_de_rol";

        /// <summary>
        /// Devuelve la tabla de las funcionalidades del rol
        /// </summary>
        /// <param name="rolId"></param>
        /// <param name="nombre">puede filtrar por nombre tambien</param>
        /// <returns></returns>
        public static DataTable GetById(Int32 rolId, String nombre)
        {
            var table = new DataTable();

            using (var con = DataAccess.GetConnection())
            {
                var cmd = new SqlCommand(SP_GET_BY_ID, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = rolId;

                if (String.IsNullOrEmpty(nombre))
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;

                con.Open();
                table.Load(cmd.ExecuteReader());
                con.Close();
            }
            return table;
        }

        /// <summary>
        /// Inserta en la tabla FUNCIONALIDAD_ROL las funcionalidades seleccionadas que se van a usar en un rol.
        /// </summary>
        /// <param name="rolId"></param>
        /// <param name="funcionalidades"></param>
        public static void Insertar(Int32 rolId, List<Int32> funcionalidades)
        {
            using (var con = DataAccess.GetConnection())
            {
                var delete = new SqlCommand(SP_DELETE, con);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.Add("@idrol", SqlDbType.Int).Value = rolId;

                SqlCommand insert = null;

                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    //En 1 sola transaccion , borro todas los registros viejos e inserto los seleccionados.
                    //Borron y cuenta nueva.
                    delete.Transaction = trans;
                    delete.ExecuteNonQuery();

                    foreach (var id in funcionalidades)
                    {
                        //aca probe reusando la variable y modificando solo el valor del parametro.
                        //no quiso andar asi que lo martilleamos y listo.
                        insert = new SqlCommand(SP_INSERT, con, trans);
                        insert.CommandType = CommandType.StoredProcedure;
                        insert.Parameters.Add("@id_rol", SqlDbType.Int).Value = rolId;
                        insert.Parameters.Add("@id_funcionalidad", SqlDbType.Int).Value = id;

                        insert.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                con.Close();
            }
        }

    }

}
