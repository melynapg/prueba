using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
    public sealed class Funcionalidad
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public Boolean Activo { get; set; }

        public Funcionalidad()
        {

        }

        public Funcionalidad(int id, string nombre)
            : this()
        {
            Id = id;
            Nombre = nombre;
        }

        public static List<Funcionalidad> Get(Int32 rolId)
        {
            var dt = Data.Funcionalidad.Get(rolId);
            var funcionalidades = new List<Funcionalidad>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
                funcionalidades.Add(CrearFuncionalidad(row));

            dt.Dispose();

            return funcionalidades;
        }

        public static List<Funcionalidad> Get()
        {
            var dt = Data.Funcionalidad.Get();
            var funcionalidades = new List<Funcionalidad>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
                funcionalidades.Add(CrearFuncionalidad(row));

            dt.Dispose();

            return funcionalidades;
        }

        private static Funcionalidad CrearFuncionalidad(DataRow row)
        {
            var func = new Funcionalidad();
            func.Id = Int32.Parse(row["Id"].ToString());
            func.Nombre = row["Nombre"].ToString();
            if (Int32.Parse(row["Seleccionado"].ToString()) == 0)
                func.Activo = false;
            else
                func.Activo = true;

            return func;
        }
    }
}
