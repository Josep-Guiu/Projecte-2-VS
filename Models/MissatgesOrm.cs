using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class MissatgesOrm
    {
        public static List<missatges> Select() {
            List<missatges> _missateges = Orm.bd.missatges
                .ToList();
            return _missateges;
        }
        public static missatges Select(int id) {
            missatges _missatges = Orm.bd.missatges
                .FirstOrDefault();
            return _missatges;
        }
        public static String Insert(missatges _mis)
        {
            String missatge = "";
            Orm.bd.missatges.Add(_mis);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
    }
}
