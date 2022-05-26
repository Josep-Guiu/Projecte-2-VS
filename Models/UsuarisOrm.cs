using Proyecto2.EmailServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class UsuarisOrm
    {

        public static List<usuaris> Select()
        {
            //List<usuaris> _usuaris = (
            //        from x in Orm.bd.usuaris
            //        select x
            //    ).ToList();
            List<usuaris> _usuaris = Orm.bd.usuaris.ToList();

            return _usuaris;
        }

        public static List<usuaris> Select(bool actiu)
        {
            //List<usuaris> _usuaris = (
            //        from x in Orm.bd.usuaris
            //        where x.actiu == true
            //        select x
            //    ).ToList();

            List<usuaris> _usuaris = Orm.bd.usuaris
                .Where(x => x.actiu == actiu)
                .OrderBy(x => x.id)
                .ToList();

            return _usuaris;
        }
        public static List<usuaris> SelectUsers()
        {
            List<usuaris> _usuaris = Orm.bd.usuaris
                .Where(x => x.rols_id == 4)
                .OrderBy(x => x.id)
                .ToList();

            return _usuaris;
        }

        public static List<usuaris> SelectProfes()
        {
            List<usuaris> _usuaris = Orm.bd.usuaris
                .Where(x => x.rols_id >= 2 && x.rols_id <= 3)
                .OrderBy(x => x.id)
                .ToList();

            return _usuaris;
        }

        public static List<usuaris> SelectPorId()
        {
            //List<usuaris> _usuaris = (
            //        from x in Orm.bd.usuaris
            //        where x.actiu == true
            //        select x
            //    ).ToList();

            List<usuaris> _usuaris = Orm.bd.usuaris
                .Where(x => x.rols_id >= 3)
                .OrderBy(x => x.nom)
                .ToList();

            return _usuaris;
        }

        public static List<usuaris> SelectPorRoles()
        {
            List<usuaris> _usuaris = Orm.bd.usuaris
                .Where(x => x.rols_id == 1)
                .OrderBy(x => x.nom)
                .ToList();

            return _usuaris;
        }
        public static List<usuaris> SelectPorRoles(int idRol)
        {
            List<usuaris> _usuaris = Orm.bd.usuaris
                .Where(x => x.rols_id == idRol)
                .OrderBy(x => x.nom)
                .ToList();

            return _usuaris;
        }
        public static String Insert(usuaris _usuaris)
        {
            String missatge = "";
            Orm.bd.usuaris.Add(_usuaris);
            missatge = Orm.MySaveChanges();
            return missatge;
        }
        public static String Delete(usuaris _usuaris)
        {
            String missatge = "";
            //Orm.bd.usuaris.Remove(_usuaris);

            Cascada(_usuaris);
            
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        private static void Cascada(usuaris _usuaris) {
            grups_has_alumnes _grups_has_alumnes = Orm.bd.grups_has_alumnes.Where(x => x.usuaris_id == _usuaris.id).FirstOrDefault();
            grups_has_docents _grups_has_docents = Orm.bd.grups_has_docents.Where(x => x.usuaris_id == _usuaris.id).FirstOrDefault();
            valoracions _valoracions = Orm.bd.valoracions.Where(x => x.usuari_valorat_id == _usuaris.id).FirstOrDefault();
            missatges _missatges = Orm.bd.missatges.Where(x => x.id_usuari == _usuaris.id).FirstOrDefault();
            botchat _botchat = Orm.bd.botchat.Where(x => x.id_usuari == _usuaris.id).FirstOrDefault();
            imatge_usuari _imatge_usuari = Orm.bd.imatge_usuari.Where(x => x.id_usuari == _usuaris.id).FirstOrDefault();
            usuaris _user = Orm.bd.usuaris.Where(x => x.id == _usuaris.id).FirstOrDefault();
            if (_grups_has_alumnes != null)
            {
                Orm.bd.grups_has_alumnes.Remove(_grups_has_alumnes);
            }
            if (_grups_has_docents != null)
            {
                Orm.bd.grups_has_docents.Remove(_grups_has_docents);
            }
            if (_valoracions != null)
            {
                Orm.bd.valoracions.Remove(_valoracions);
            }
            if (_missatges != null)
            {
                Orm.bd.missatges.Remove(_missatges);
            }
            if (_botchat != null)
            {
                Orm.bd.botchat.Remove(_botchat);
            }
            if (_imatge_usuari != null)
            {
                Orm.bd.imatge_usuari.Remove(_imatge_usuari);
            }
            Orm.bd.usuaris.Remove(_user);
        }

        public static String Update()
        {
            String missatge = "";
            //Orm.bd.Entry<cursos>(_usuaris);
            missatge = Orm.MySaveChanges();
            return missatge;
        }

        public static int SelectLoginUser(String correo)
        {
            int id;
            usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.correu == correo).FirstOrDefault();
            id = _usuari.rols_id;
            return id;
        }
        public static usuaris SelectedUser(String correo)
        {
            usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.correu == correo).FirstOrDefault();
            return _usuari;
        }
        public static void RecuperarPassword(String correo)
        {
            String missatge = "";
            usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.correu == correo)
                .FirstOrDefault<usuaris>();

            if (_usuari != null)
            {
                String resetPwd = "reseteo1pswd";
                SystemSuportMail envio = new SystemSuportMail();
                envio.enviarMensajeACliente("Sistema --> Solicitud de recuperación de contraseña",
                    "Hola " + _usuari.nom + ", has solicitado recuperar tu contraseña\n"
                    + "Tu contraseña antigua era --> " + _usuari.contrasenia
                    + "\n Tu contraseña provisional serà --> " + resetPwd
                    + "\nTe recomendamos que una vez inicies sesión modifiques tu contraseña, de lo contrario,"
                    + "\nalguien podria iniciar sesión con tu usuario...",
                    _usuari.correu);
                resetPwd = BCrypt.Net.BCrypt.EnhancedHashPassword(resetPwd, BCrypt.Net.HashType.SHA512);
                _usuari.contrasenia = resetPwd;
                missatge = Update();
            }

        }

        public static List<usuaris> SelectedUsersPorGrupo(List<grups_has_alumnes> listaHas)
        {
            List<usuaris> _users = new List<usuaris>();
            foreach (grups_has_alumnes item in listaHas)
            {
                usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.id == item.usuaris_id)
                .FirstOrDefault();
                _users.Add(_usuari);
            }



            return _users;
        }

        public static List<usuaris> QuitarUsuariosDeListaTotal(List<grups_has_alumnes> listaHas)
        {
            List<usuaris> _users = SelectUsers();
            foreach (grups_has_alumnes item in listaHas)
            {
                usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.id == item.usuaris_id)
                .FirstOrDefault();
                _users.Remove(_usuari);
            }



            return _users;
        }
        public static List<usuaris> PonerUsuariosDeListaTotal(List<grups_has_alumnes> listaHas)
        {
            List<usuaris> _users = new List<usuaris>();
            foreach (grups_has_alumnes item in listaHas)
            {
                usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.id == item.usuaris_id)
                .FirstOrDefault();

                _users.Add(_usuari);

            }



            return _users;
        }
        public static List<usuaris> PonerUsuariosDeListaTotal(List<grups_has_docents> listaHas)
        {
            List<usuaris> _users = new List<usuaris>();
            foreach (grups_has_docents item in listaHas)
            {
                usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.id == item.usuaris_id)
                .FirstOrDefault();

                _users.Add(_usuari);

            }



            return _users;
        }
        public static List<usuaris> QuitarUsuariosDeListaTotal(List<grups_has_docents> listaHas)
        {
            List<usuaris> _users = SelectProfes();
            foreach (grups_has_docents item in listaHas)
            {
                usuaris _usuari = Orm.bd.usuaris
                .Where(x => x.id == item.usuaris_id)
                .FirstOrDefault();
                _users.Remove(_usuari);
            }



            return _users;
        }

        public static int ContarUsuarios(String usuario)
        {
            int total = 0;
            if (usuario.Equals("all"))
            {
                total = Orm.bd.usuaris.Count();
            }
            else if (usuario.Equals("admins"))
            {
                total = Orm.bd.usuaris
                    .Where(x => x.rols_id == 1)
                    .Count();
            }
            else if (usuario.Equals("profes"))
            {
                total = Orm.bd.usuaris
                    .Where(x => x.rols_id >= 2 && x.rols_id <= 3)
                    .Count();
            }
            else if (usuario.Equals("alumnos"))
            {
                total = Orm.bd.usuaris
                    .Where(x => x.rols_id == 4)
                    .Count();
            }

            return total;
        }

    }
}
