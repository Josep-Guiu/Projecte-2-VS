using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class GrupHasWhatOrm
    {
        public static List<grups_has_alumnes> SelectGruposAlumnos()
        {
            List<grups_has_alumnes> _grups = Orm.bd.grups_has_alumnes.ToList();
            return _grups;
        }
        public static String Delete(grups_has_alumnes hasAlumne)
        {
            String missatge = "";
            Orm.bd.grups_has_alumnes.Remove(hasAlumne);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String Delete(grups_has_docents hasAlumne)
        {
            String missatge = "";
            Orm.bd.grups_has_docents.Remove(hasAlumne);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static int CuentaAlumnosPorIdCurso(int idCurso, grups _grup)
        {
            int cuenta = Orm.bd.grups_has_alumnes
                .Where(x => x.curs_id == idCurso && x.grups_id == _grup.id)
                .Count();
            return cuenta;
        }

        public static int SumaDeTodasLasNotasDeTodosAlumnos(int idCurso, grups _grup)
        {
            List<grups_has_alumnes> grupUsers = Orm.bd.grups_has_alumnes
                .Where(x => x.curs_id == idCurso && x.grups_id == _grup.id)
                .ToList();

            List<usuaris> _users = new List<usuaris>();
            foreach (grups_has_alumnes item in grupUsers)
            {
                _users.Add(Orm.bd.usuaris.Where(x => x.id == item.usuaris_id).FirstOrDefault());
            }

            //List<valoracions> _valoracions = new List<valoracions>();
            List<valoracions> _valoracions = new List<valoracions>();
            foreach (usuaris item in _users)
            {
                List<valoracions> val = Orm.bd.valoracions.Where(x => x.usuari_valorat_id == item.id).ToList();
                //_valoracions.Add();
                foreach (valoracions item2 in val)
                {
                    _valoracions.Add(item2);
                }
            }

            List<int> suma = new List<int>();
            foreach (valoracions item in _valoracions)
            {
                suma.Add(item.nota);
            }
            int total = suma.Sum();
            return total;
        }


        public static String InsertAlumnoAGrupo(grups_has_alumnes x)
        {
            String missatge = "";
            Orm.bd.grups_has_alumnes.Add(x);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String InsertProfeAGrupo(grups_has_docents x)
        {
            String missatge = ""; 
            Orm.bd.grups_has_docents.Add(x);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String InsertAlumnesGrup(List<usuaris> _usuaris, grups _grup, cursos _curs)
        {
            String missatge = "";
            foreach (var alumne in _usuaris)
            {
                grups_has_alumnes grupHasAlumne = new grups_has_alumnes();
                grupHasAlumne.grups_id = _grup.id;
                grupHasAlumne.usuaris_id = alumne.id;
                grupHasAlumne.curs_id = _curs.id;
                Orm.bd.grups_has_alumnes.Add(grupHasAlumne);
                //Orm.bd.SaveChanges();
                missatge = Orm.MySaveChanges();
            }
            return missatge;
        }
        public static List<usuaris> InsertProfesGrup(List<usuaris> _usuaris, grups _grup, cursos _curs)
        {
            List<usuaris> profesNoInsertados = new List<usuaris>();
            int contadorSuperProfesor = 0;
            foreach (var docent in _usuaris)
            {
                grups_has_docents grupHasDocents = new grups_has_docents();
                if (docent.rols_id == 2)
                {
                    contadorSuperProfesor++;
                }
                if (contadorSuperProfesor <= 1)
                {
                    grupHasDocents.grups_id = _grup.id;
                    grupHasDocents.usuaris_id = docent.id;
                    grupHasDocents.curs_id = _curs.id;
                    Orm.bd.grups_has_docents.Add(grupHasDocents);
                }
                else
                {
                    profesNoInsertados.Add(docent);
                }

            }
            Orm.bd.SaveChanges();
            return profesNoInsertados;
        }
        // APlicar pero tambien controlando el id de curso i el id de grupo
        public static bool SelectHaySuperprofes(usuaris _user, grups _grup, cursos _curs)
        {
            bool isInList = false;
            List<grups_has_docents> _usuaris = Orm.bd.grups_has_docents
                .Where(x => x.usuaris_id == 2 && x.usuaris_id == _user.id && x.grups_id == _grup.id && x.curs_id == _curs.id)
                .ToList();
            if (_usuaris != null)
            {
                isInList = true;
            }

            return isInList;
        }
        public static bool SelectHayEsteUsuario(usuaris _user, grups _grup, cursos _curs)
        {
            bool isInList = false;
            List<grups_has_alumnes> _usuaris = Orm.bd.grups_has_alumnes
               .Where(x => x.usuaris_id == _user.id && x.grups_id == _grup.id && x.curs_id == _curs.id)
               .ToList();
            if (_usuaris.Count == 0)
            {
                isInList = false;
            }
            else
            {
                isInList = true;
            }

            return isInList;
        }

        public static List<int> SelectIdUsers(grups _grup)
        {
            List<int> _ids = new List<int>();
            List<grups_has_alumnes> ids = Orm.bd.grups_has_alumnes
                .Where(x => x.grups_id == _grup.id)
                .ToList();
            foreach (var grup in ids)
            {
                _ids.Add(grup.usuaris_id);
            }

            return _ids;
        }

        public static List<grups_has_alumnes> SelectGrups(int anio)
        {
            List<grups_has_alumnes> _grups_alumnes = Orm.bd.grups_has_alumnes
                .Where(x => x.cursos.curs_inici == anio)
                .ToList();
            List<grups_has_alumnes> devuelta = new List<grups_has_alumnes>();
            grups_has_alumnes Control = new grups_has_alumnes();
            foreach (grups_has_alumnes item in _grups_alumnes)
            {

                if (devuelta.Count == 0)
                {
                    devuelta.Add(item);
                    Control = item;
                }
                else if (Control.grups_id != item.grups_id)
                {
                    devuelta.Add(item);
                }
                else
                {
                    Control = item;
                }

            }

            return devuelta;
        }
        public static List<usuaris> SelectGrupsUsers(grups grups)
        {
            List<grups_has_alumnes> _grups_alumnes = Orm.bd.grups_has_alumnes
               .Where(x => x.grups.id == grups.id)
               .ToList();
            List<usuaris> _users = new List<usuaris>();
            foreach (grups_has_alumnes item in _grups_alumnes)
            {
                usuaris usuari = Orm.bd.usuaris
                    .Where(x => x.id == item.usuaris_id)
                    .FirstOrDefault();

                _users.Add(usuari);
            }
            return _users;
        }

    }
}
