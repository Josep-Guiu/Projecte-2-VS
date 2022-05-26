using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proyecto2.Models
{
    public class ImagenOrm
    {
        public static String Insert(imatge_usuari _imatge)
        {
            String missatge = "";
            Orm.bd.imatge_usuari.Add(_imatge);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static imatge_usuari CargarImatgeUsuari(usuaris _usuari) {
            imatge_usuari _imatge = Orm.bd.imatge_usuari
                .Where(x => x.id_usuari == _usuari.id && x.imatge_nom != null)
                .FirstOrDefault();
            return _imatge;
        }

        //public static void MatarFoto(usuaris _usuari)
        //{
        //    imatge_usuari _imatge = Orm.bd.imatge_usuari
        //        .Where(x => x.id_usuari == _usuari.id)
        //        .FirstOrDefault();
        //    UpdateImatgeUsuari();
            
        //}

        public static bool IsInUsuari(usuaris _usuari)
        {
            bool control = true;
            imatge_usuari _imatge = Orm.bd.imatge_usuari
                .Where(x => x.id_usuari == _usuari.id)
                .FirstOrDefault();
            if (_imatge == null)
            {
                control = false;
            }
            return control;
        }

        public static String UpdateImatgeUsuari()
        {
            String missatge;
            missatge = Orm.MySaveChanges();
            return missatge;
        }
    }
}
