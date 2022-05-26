using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class Bd
    {
        public static SqlConnection conexio = new SqlConnection("Server=localhost\\sqlexpress;DataBase=Frase_alu;User Id=sa;Password=politecnics");
    }
}
