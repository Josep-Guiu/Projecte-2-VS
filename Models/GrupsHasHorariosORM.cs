using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class GrupsHasHorariosORM
    {

        public static String Insert(grups_has_horaris x)
        {
            String missatge = "";
            Orm.bd.grups_has_horaris.Add(x);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static List<dias> ReturnDiasDeGrupo(int idGrupo, int idHorari, String dia) {
            List<dias> _dias = new List<dias>();
            dias _dia;
            List<grups_has_horaris> _grups_has_horaris = Orm.bd.grups_has_horaris
            .Where(x => x.id_grups == idGrupo && x.id_horari == idHorari)
            .ToList();

            foreach (grups_has_horaris item in _grups_has_horaris)
            {
                _dia = Orm.bd.dias
                    .Where(x => x.id == item.id_dias && x.dia.Equals(dia)).FirstOrDefault();
                if (_dia != null)
                {
                    if (_dia.dia.Equals(dia))
                    {
                        _dias.Add(_dia);
                    }
                }
                
                
            }

            _dias.OrderBy(x => x.inici);
            _dias.OrderBy(x => x.dia);
            return _dias;

        }
        public static grups_has_horaris ReturnDiaDeGrupo(int idGrupo, int idHorari, int idDia) {
            grups_has_horaris _grups_has_horaris = Orm.bd.grups_has_horaris
            .Where(x => x.id_grups == idGrupo && x.id_horari == idHorari && x.id_dias == idDia)
            .FirstOrDefault();

            return _grups_has_horaris;

        }

        public static String Delete(grups_has_horaris x)
        {
            String missatge = "";
            Orm.bd.grups_has_horaris.Remove(x);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

    }
}
