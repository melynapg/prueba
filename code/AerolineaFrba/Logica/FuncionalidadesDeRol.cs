using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
    /// <summary>
    /// Representa una funcionalidad de un rol y si esta o no asociado al mismo. Es una metaclase para la UI de seleccion 
    /// </summary>
    public sealed class FuncionalidadDeRol
    {
        public Funcionalidad Funcionalidad { get; set; }
        public Boolean Seleccionado { get; set; }

        /// <summary>
        /// Devuelve la lista de Funcionalidades y su estado de un rol
        /// </summary>
        /// <param name="rolId"></param>
        /// <param name="filtro">Filtra por nombre de funcionalidad.</param>
        /// <returns></returns>
        public static List<FuncionalidadDeRol> GetById(Int32 rolId, String filtro)
        {
            var funcs = new List<FuncionalidadDeRol>();

            using (var data = Data.FuncionalidadDeRol.GetById(rolId, filtro))
            {
                String nombre = String.Empty;
                Int32 id = 0;
                Boolean seleccionado = false;

                foreach (DataRow row in data.Rows)
                {
                    id = Int32.Parse(row["Id"].ToString());
                    nombre = row["Nombre"].ToString();

                    if (0 == Int32.Parse(row["Seleccionado"].ToString()))
                        seleccionado = false;
                    else
                        seleccionado = true;

                    funcs.Add(new FuncionalidadDeRol(new Funcionalidad(id, nombre), seleccionado));
                }
            }

            return funcs;
        }

        /// <summary>
        /// Inserta en la base de datos todas las relaciones de funcionalidades SELECCIONADAS con el rol especificado
        /// </summary>
        /// <param name="rol"></param>
        /// <param name="idsFuncionalidades"></param>
        public static void Insertar(Rol rol, List<Int32> idsFuncionalidades)
        {
            Data.FuncionalidadDeRol.Insertar(rol.Id, idsFuncionalidades);
        }

        public FuncionalidadDeRol(Funcionalidad funcionalidad, Boolean seleccionado)
        {
            Funcionalidad = funcionalidad;
            Seleccionado = seleccionado;
        }
    }
}
