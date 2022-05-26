using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class FormacionOrm
    {
        public static List<formacion> SelectFormaciones()
        {
            List<formacion> _formacion = Orm.bd.formacion
                .OrderBy(x => x.id)
                .ToList();
            return _formacion;
        }
    }
}
