using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class KpiOrm
    {
        public static List<kpis> Select()
        {
            List<kpis> _kpis = Orm.bd.kpis.ToList();

            return _kpis;
        }
        public static int TotalKPIS()
        {
            int totalKPIS = Orm.bd.kpis.Count();

            return totalKPIS;
        }
            public static List<kpis> Select(bool actiu)
        {
            List<kpis> _kpis = Orm.bd.kpis
                .Where(x => x.actiu == actiu)
                .OrderBy(x => x.id)
                .ToList();

            return _kpis;
        }

        public static List<kpis> SelectConSkill(skills _skill)
        {
            List<kpis> _kpis = Orm.bd.kpis
                .Where(x => x.skills_id == _skill.id)
                .OrderBy(x => x.id)
                .ToList();

            return _kpis;
        }
        public static String Insert(kpis _kpi)
        {
            String missatge = "";
            Orm.bd.kpis.Add(_kpi);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String Delete(kpis _kpi)
        {
            String missatge = "";
            Orm.bd.kpis.Remove(_kpi);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Update()
        {
            String missatge = "";
            Orm.bd.SaveChanges();
            return missatge;
        }
    }
}
