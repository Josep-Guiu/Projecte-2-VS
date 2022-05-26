using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class CursosOrm
    {
        public static List<cursos> SelectCursos(bool actiu) {
            List<cursos> _cursos = Orm.bd.cursos
                .Where(x => x.actiu == actiu)
                .OrderByDescending(x => x.curs_inici)
                .ToList();
            return _cursos;
        }

        public static cursos SelectCursosAct(bool actiu)
        {
            cursos _cursos = Orm.bd.cursos
                .Where(x => x.actiu == actiu)
                .FirstOrDefault();
            return _cursos;
        }

        public static String Nombre(int id) {
            cursos _cursos = Orm.bd.cursos
                .Where(x => x.id == id)
                .FirstOrDefault();
            String inici = _cursos.curs_inici.ToString();
            return inici;
        }

        public static List<cursos> SelectCursos()
        {
            List<cursos> _cursos = Orm.bd.cursos
                .OrderByDescending(x => x.curs_inici)
                .ToList();
            return _cursos;
        }

        public static String Insert(cursos _curs)
        {
            String missatge = "";
            Orm.bd.cursos.Add(_curs);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Delete(cursos _curso) {
            String missatge = "";
            Orm.bd.cursos.Remove(_curso);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Update(cursos _curso)
        {
            //Orm.bd.Entry<cursos>(_curso);
            String missatge = "";
            //Orm.bd.SaveChanges();
            missatge = Orm.MySaveChanges();
            return missatge;
        }
    }
    
}
