using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace Logica
{
    public class Usuario
    {
        public Int32 Id { get; set; }
        public Int32 Id_rol { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public static string SHA256Encripta(string input)
        {
            var provider = new SHA256Managed();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public static Usuario GetByLogin(String username, String password)
        {
            var Usuario = new Usuario();

            using (var data = Data.Usuario.GetByLogin(username, password))
            {
                if (data.Rows.Count == 0)
                    Usuario = null;

                foreach (DataRow row in data.Rows)
                {
                    Usuario = new Usuario();
                    Usuario.Id = Int32.Parse(row["Id"].ToString());
                    Usuario.Id_rol = Int32.Parse(row["Id_rol"].ToString());
                    Usuario.Username = row["Username"].ToString();
                    Usuario.Password = row["Password"].ToString();
                }
            }

            return Usuario;
        }
        public static Int32 GetIntentos(String username)
        {
            DataTable data = Data.Usuario.GetIntentos(username);
            Int32 result = 0;
            foreach (DataRow row in data.Rows)
            {
                result = Int32.Parse(row["INTENTOSFALLIDOS"].ToString());
            }
            return result;
        }

        public static void SetIntentos(String username, Int32 intentos)
        {
            Data.Usuario.SetIntentos(username, intentos);
        }


    }
}
