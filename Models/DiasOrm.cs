using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class DiasOrm
    {
        public static List<dias> RecibirTodosDias() {
            List<dias> _dias = Orm.bd.dias.OrderBy(x => x.id).ToList();
            return _dias;
        }

        public static String Insert(dias dias)
        {
            String missatge = "";
            Orm.bd.dias.Add(dias);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Update()
        {
            String missatge = "";
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Delete(dias _dia)
        {
            String missatge = "";
            Orm.bd.dias.Remove(_dia);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

    }
}
