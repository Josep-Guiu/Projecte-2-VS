using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class RolsOrm
    {
        public static List<rols> SelectRols(bool actiu)
        {
            List<rols> _rols = Orm.bd.rols
                .Where(x => x.actiu == actiu)
                .OrderBy(x => x.id)
                .ToList();
            return _rols;
        }
        public static List<rols> SelectRols()
        {
            List<rols> _rols = Orm.bd.rols
                .OrderBy(x => x.id)
                .ToList();
            return _rols;
        }
    }
}
