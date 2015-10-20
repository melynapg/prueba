using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
//using System.Data;

namespace AerolineaFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////el using es para que apenas termine de usarse se ejecute el dispose , que limpia el recurso en memoria y demas.
            //using (var con = DataAccess.GetConnection())
            //{
            //    //elegi la sp mas pelotuda posible
            //    var cmd = new SqlCommand("[HAY_TABLA].sp_insertar_rol", con);
            //    //el default es plain text , si no se lo pones la consulta explota
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    //nombre es unique asi que le enchufo la fecha
            //    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = "rol insertado en " + DateTime.Now.ToString();
            //    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = 0;


            //    //aca sucede la magia
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}

            //MessageBox.Show("ejecute la sp mas pelotuda");

            Application.Run(new Inicial());
        }
    }
}
