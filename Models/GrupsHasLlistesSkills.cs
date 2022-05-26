using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class GrupsHasLlistesSkills
    {
        public static List<grups_has_llistes_skills> SeleccionarListasXCursoGrupo(grups _grup, cursos _curs)
        {
            List<grups_has_llistes_skills> lista = Orm.bd.grups_has_llistes_skills
                .Where(x => x.grups_id == _grup.id && x.curs_id == _curs.id)
                .ToList();
            return lista;
        }
        public static List<grups_has_llistes_skills> SeleccionarTodasListas()
        {
            List<grups_has_llistes_skills> lista = Orm.bd.grups_has_llistes_skills
                .ToList();
            return lista;
        }

        public static List<llistes_skills> SelectGrupsLlistes(grups grups)
        {
            List<grups_has_llistes_skills> _grups_alumnes = Orm.bd.grups_has_llistes_skills
               .Where(x => x.grups.id == grups.id)
               .ToList();
            List<llistes_skills> _llistes = new List<llistes_skills>();
            foreach (grups_has_llistes_skills item in _grups_alumnes)
            {
                llistes_skills _llista = Orm.bd.llistes_skills
                    .Where(x => x.id == item.llistes_skills_id)
                    .FirstOrDefault();

                _llistes.Add(_llista);
            }
            return _llistes;
        }
        public static bool SelectControlRepeticion(grups_has_llistes_skills grups_Has_Llistes_Skills)
        {
            bool control = true;
            List<grups_has_llistes_skills> _grups_has_this_list = Orm.bd.grups_has_llistes_skills
               .Where(x => x.grups_id == grups_Has_Llistes_Skills.grups_id && x.llistes_skills_id == grups_Has_Llistes_Skills.llistes_skills_id
               && x.curs_id == grups_Has_Llistes_Skills.curs_id)
               .ToList();
            if (_grups_has_this_list.Count != 0)
            {
                control = false;
            }

            return control;
        }

        public static String Insert(grups_has_llistes_skills grups_Has_Llistes_Skills)
        {
            String missatge = "";
            Orm.bd.grups_has_llistes_skills.Add(grups_Has_Llistes_Skills);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String Delete(grups_has_llistes_skills grupLlistaBorrar)
        {
            String missatge = "";
            grups_has_llistes_skills borrar = Orm.bd.grups_has_llistes_skills
                .Where(x => x.curs_id == grupLlistaBorrar.curs_id && x.grups_id == grupLlistaBorrar.grups_id && x.llistes_skills_id == grupLlistaBorrar.llistes_skills_id)
                .FirstOrDefault();
            Orm.bd.grups_has_llistes_skills.Remove(borrar);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
    }
}
