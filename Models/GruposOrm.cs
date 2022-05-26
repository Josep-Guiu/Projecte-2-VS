using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class GruposOrm
    {
        public static List<grups> Select()
        {
            List<grups> _grups = Orm.bd.grups.ToList();

            return _grups;
        }

        public static int TotalGrupos()
        {
            int totalGrupos = Orm.bd.grups
                .Count();

            return totalGrupos;
        }

            public static grups SelectID(int id)
        {
           grups _grups = Orm.bd.grups
                .Where(x => x.id == id)
                .FirstOrDefault();

            return _grups;
        }
        

        public static List<grups> SelectGruposConAlumnos(List<grups_has_alumnes> _grup_has_alumnes)
        {
            List<grups> _grups = new List<grups>();
            foreach (grups_has_alumnes grupsHas in _grup_has_alumnes)
            {
                grups x = Orm.bd.grups
                    .Where(v => v.id == grupsHas.grups_id)
                    .FirstOrDefault();
                _grups.Add(x);
            }
                

            return _grups;
        }


        public static String Insert(grups _grup)
        {
            String missatge = "";
            Orm.bd.grups.Add(_grup);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Delete(grups _grup)
        {
            String missatge = "";
            Orm.bd.grups.Remove(_grup);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static List<grups> SeleccionarGruposDeCurso(List<grups_has_alumnes> llista) {
            List<grups> _grups = new List<grups>();
            List<int> idCurs = new List<int>();
            int id;
            foreach (grups_has_alumnes item in llista)
            {
               id = item.grups_id;
                if (!idCurs.Contains(id))
                {
                    idCurs.Add(id);
                }
            }

            foreach (int item2 in idCurs)
            {
                _grups.Add(SelectID(item2));
            }

            return _grups;
        }

        public static List<grups> SeleccionarMismoGrupoPorAnio(List<grups_has_alumnes> llista)
        {
            List<grups> _grups = new List<grups>();
            List<int> idCurs = new List<int>();
            int idC;
            foreach (grups_has_alumnes item in llista)
            {
                idC = item.curs_id;
                if (/*!idGrup.Contains(id) &&*/ !idCurs.Contains(idC))
                {
                    idCurs.Add(idC);

                    _grups.Add(GrupPerHas(item));
                }
            }

            return _grups;
        }
        public static List<int> IDCursosContarPersonas(List<grups_has_alumnes> llista)
        {
            List<int> idCurs = new List<int>();
            int idC;
            foreach (grups_has_alumnes item in llista)
            {
                idC = item.curs_id;
                if (!idCurs.Contains(idC))
                {
                    idCurs.Add(idC);
                }
            }

            return idCurs;
        }

        public static grups GrupPerHas(grups_has_alumnes has) {
            grups _grup = Orm.bd.grups
                .Where(x => x.id == has.grups_id)
                .FirstOrDefault();
            return _grup;
        }

        public static List<grups> SelectActivosYPoranio(cursos _curs)
        {
            List<grups_has_alumnes> _grupsHas = new List<grups_has_alumnes>();
            if (_curs != null)
            {
                _grupsHas = Orm.bd.grups_has_alumnes
                .Where(x => x.curs_id == _curs.id)
                .ToList();
            }

            List<int> control = new List<int>();
            foreach (grups_has_alumnes item in _grupsHas)
            {
                if (!control.Contains(item.grups_id) && item.cursos.actiu == true)
                {
                    control.Add(item.grups_id);
                }
            }
            List<grups> llistaGrup = new List<grups>();
            foreach (int item in control)
            {
                llistaGrup.Add(Orm.bd.grups.Where(x => x.id == item).FirstOrDefault());
            }
            return llistaGrup;
        }

    }
}
