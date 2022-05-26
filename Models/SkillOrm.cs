using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class SkillOrm
    {
        public static List<skills> Select()
        {
            List<skills> _skill = Orm.bd.skills.ToList();

            return _skill;
        }
        public static int TotalSkills()
        {
            int totalSkills = Orm.bd.skills.Count();

            return totalSkills;
        }

            public static List<skills> Select(bool actiu)
        {
            List<skills> _skill = Orm.bd.skills
                .Where(x => x.actiu == actiu)
                .OrderBy(x => x.id)
                .ToList();

            return _skill;
        }

        public static List<skills> SelectConListas(llistes_skills _llistes)
        {
            List<skills> _skill = Orm.bd.skills
                .Where(x => x.llistes_skills_id == _llistes.id)
                .OrderBy(x => x.id)
                .ToList();

            return _skill;
        }
        //public static skills SelectID(String busca)
        //{
        //    skills a = (skills)Orm.bd.skills
        //        .Where(x => x.nom == busca).FirstOrDefault<skills>();

        //    return a;
        //}
        public static String Insert(skills _skill)
        {
            String missatge = "";
            Orm.bd.skills.Add(_skill);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String Delete(skills _skill)
        {
            String missatge = "";
            Orm.bd.skills.Remove(_skill);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Update()
        {
            String missatge = "";
            missatge = Orm.MySaveChanges();
            return missatge;
        }
    }
}
