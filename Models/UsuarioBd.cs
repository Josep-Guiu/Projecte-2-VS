using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class UsuarioBd
    {
        public static String SelectUsers(String correoElectronico)
        {
            SqlCommand sentencia = new SqlCommand();
            String password;
            sentencia.Connection = Bd.conexio;

            sentencia.CommandText = "select contrasenia from Frase_alu.dbo.usuaris where Frase_alu.dbo.usuaris.correu = @correoElectronico";
            sentencia.Parameters.Clear();
            sentencia.Parameters.AddWithValue("@correoElectronico", correoElectronico);

            Bd.conexio.Open();
            if (sentencia.ExecuteScalar() == null)
            {
                password = "NO EXISTE";
            }
            else
            {
                password = sentencia.ExecuteScalar().ToString();
            }

            Bd.conexio.Close();
            return password;
        }
    }
}

