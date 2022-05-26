using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class ListasOrm
    {
        public static List<llistes_skills> Select()
        {
            List<llistes_skills> _lista = Orm.bd.llistes_skills.ToList();

            return _lista;
        }

        public static llistes_skills SelectPorGrupo(grups_has_llistes_skills y)
        {
            llistes_skills llista = Orm.bd.llistes_skills
                .Where(x => x.id == y.llistes_skills_id)
                .FirstOrDefault();
            return llista;
        }
        public static List<llistes_skills> QuitarListasQueTieneGrupo(List<llistes_skills> y)
        {
            List<llistes_skills> llista = Select();
            foreach (llistes_skills item in y)
            {
                if (llista.Contains(item))
                {
                    llista.Remove(item);
                }
            }
            return llista;
        }

        public static int TotalListas()
        {
            int totalListas = Orm.bd.llistes_skills.Count();

            return totalListas;
        }
        //public static llistes_skills SelectUna()
        //{
        //    llistes_skills _lista = Orm.bd.llistes_skills
        //        .Where
        //        .ToList();

        //    return _lista;
        //}
        public static List<llistes_skills> Select(bool actiu)
        {
            List<llistes_skills> _lista = Orm.bd.llistes_skills
                .Where(x => x.actiu == actiu)
                .OrderBy(x => x.id)
                .ToList();

            return _lista;
        }



        public static String Insert(llistes_skills _lista)
        {
            String missatge = "";
            Orm.bd.llistes_skills.Add(_lista);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String Delete(llistes_skills _lista)
        {
            String missatge = "";
            Orm.bd.llistes_skills.Remove(_lista);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Update()
        {
            String missatge = "";
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        //public static llistes_skills SelectID(String busca)
        //{
        //    llistes_skills a = Orm.bd.llistes_skills
        //        .Where(x => x.nom == busca).FirstOrDefault();

        //    return a;
        //}

        public static int SelectID(String busca)
        {
            llistes_skills a = Orm.bd.llistes_skills
                .Where(x => x.nom == busca).FirstOrDefault();
            int b = a.id;

            //var c = Orm.bd.llistes_skills
            //    .Select(s => s.id).First();

            return b;
        }
    }
}

