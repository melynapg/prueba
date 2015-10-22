using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Rol
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Boolean Estado { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }

        public void Insertate()
        {
            Validate();
            Rol.Insertar(this);
        }

        public void Actualizate()
        {
            Validate();
            Rol.Actualizar(this);
        }
        public void Eliminate()
        {
            Rol.Eliminar(this);
        }

        public static Rol GetById(Int32 id)
        {
            var rol = new Rol();

            using (var data = Data.Rol.GetById(id))
            {
                rol.Id = Int32.Parse(data.Rows[0][data.Columns["Id"].Ordinal].ToString());
                rol.Nombre = data.Rows[0][data.Columns["Nombre"].Ordinal].ToString();
                rol.Estado = Boolean.Parse(data.Rows[0][data.Columns["Status"].Ordinal].ToString());

                rol.Funcionalidades = Funcionalidad.Get(rol.Id);
            }

            return rol;
        }

        public static List<Rol> Get(String nombreFiltro)
        {
            var dt = Data.Rol.Get(nombreFiltro);
            var roles = new List<Rol>(dt.Rows.Count);
            Rol rol = null;

            foreach (DataRow row in dt.Rows)
            {
                rol = new Rol();
                rol.Id = Int32.Parse(row["Id"].ToString());
                rol.Nombre = row["Nombre"].ToString();
                rol.Estado = Boolean.Parse(row["Status"].ToString());

                roles.Add(rol);
            }

            dt.Dispose();

            return roles;
        }

        public static Dictionary<Int32, string> GetActivosListados()
        {
            var dt = Data.Rol.Get(null);
            var roles = new Dictionary<Int32, string>();

            foreach (DataRow row in dt.Rows)
            {
                roles.Add(Int32.Parse(row["Id"].ToString()), row["Nombre"].ToString());
            }

            dt.Dispose();

            return roles;
        }

        private static void Insertar(Rol rol)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {

                con = Data.DataAccess.GetConnection();
                con.Open();
                trans = con.BeginTransaction();

                rol.Id = Data.Rol.Insertar(rol.Nombre, rol.Estado);

                foreach (var func in rol.Funcionalidades)
                    Data.Funcionalidad.Insert(con, trans, rol.Id, func.Id);

                trans.Commit();
                con.Close();

            }
            catch (Exception)
            {
                if (trans != null)
                    trans.Rollback();

                if (con != null)
                    con.Close();

                throw;
            }
        }

        private static void Actualizar(Rol rol)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {

                con = Data.DataAccess.GetConnection();
                con.Open();
                trans = con.BeginTransaction();

                Data.Rol.Actualizar(rol.Id, rol.Nombre, rol.Estado);
                Data.Funcionalidad.Delete(con, trans, rol.Id);

                foreach (var func in rol.Funcionalidades)
                    Data.Funcionalidad.Insert(con, trans, rol.Id, func.Id);

                trans.Commit();
                con.Close();

            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();

                if (con != null)
                    con.Close();

                throw;
            }
        }

        private static void Eliminar(Rol rol)
        {
            Data.Rol.Eliminar(rol.Id);
        }
        private void Validate()
        {
            if (String.IsNullOrEmpty(this.Nombre))
                throw new ArgumentException("El nombre del rol no puede estar vacio");
        }

    }
}
