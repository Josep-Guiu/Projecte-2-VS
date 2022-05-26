using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class HorarisOrm
    {

        public static List<horari> RecibirTodosHorarios()
        {
            List<horari> _horaris = Orm.bd.horari.OrderBy(x => x.id).ToList();
            return _horaris;
        }

        public static grups grupDeHorari(horari _horaris) {
            grups _grups = new grups();
            if (_horaris!=null)
            {
                grups_has_horaris _grups_has_horaris = Orm.bd.grups_has_horaris
                .Where(x => x.id_horari == _horaris.id)
                .FirstOrDefault();
                if (_grups_has_horaris != null)
                {
                    _grups = Orm.bd.grups
                .Where(x => x.id == _grups_has_horaris.id_grups)
                .FirstOrDefault();
                }
                 
                
            }

            return _grups;
        }

        public static String Insert(horari x)
        {
            String missatge = "";
            Orm.bd.horari.Add(x);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Update()
        {
            String missatge = "";
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static String Delete(horari x)
        {
            String missatge = "";
            Orm.bd.horari.Remove(x);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

    }
}
