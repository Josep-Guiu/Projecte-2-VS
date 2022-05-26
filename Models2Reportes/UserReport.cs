using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models2Reportes
{
    public class UserReport
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public String Dni { get; set; }

        public String Name_Rol { get; set; }

        public int Rol { get; set; }
    }
}
