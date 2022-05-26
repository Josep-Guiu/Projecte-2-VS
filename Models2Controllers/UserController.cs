using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Proyecto2.Models;
using Proyecto2.Models2Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models2Controllers
{
    public static class UserController
    {
        public static List<UserReport> SeleccionarTodosUsuariosController() {
            List<UserReport> _users = Orm.bd.usuaris
                .Select(h => new UserReport { Id = h.id, Name = h.nom, Email = h.correu, Phone = h.telefono, Dni = h.dni, Name_Rol = h.rols.nom, Rol = h.rols_id })
                .ToList();

            return _users;
        }

        public static UserReport SeleccionarUnUsuarioController(String dni)
        {
            UserReport devuelto = new UserReport();
            usuaris _users = Orm.bd.usuaris
                .Where(x => x.dni.Equals(dni))
                .FirstOrDefault();
            if (_users != null)
            {
                 devuelto = new UserReport { Id = _users.id, Name = _users.nom, Email = _users.correu, Phone = _users.telefono, Dni = _users.dni, Name_Rol = _users.rols.nom, Rol = _users.rols_id };
            }

            return devuelto;
        }

        public static List<NotaUsuario> SeleccionarTodasNotasUsuari(int idUser)
        {
            List<NotaUsuario> notas = Orm.bd.usuaris
                .Join(
                    Orm.bd.valoracions,
                    usuaris => usuaris.id,
                    valoracions => valoracions.usuari_valorat_id,
                    (usuaris, valoracions) => new
                    {
                        Nota = valoracions.nota,
                        IdUser = usuaris.id,
                        IdKpi = valoracions.kpis_id
                    }
                )
                .Join(
                    Orm.bd.kpis,
                    usuaris => usuaris.IdKpi,
                    kpis => kpis.id,
                    (usuaris, kpis) => new NotaUsuario
                    {
                        Nota = usuaris.Nota,
                        IdUser = usuaris.IdUser,
                        IdKpi = usuaris.IdKpi,
                        NomKpi = kpis.nom
                    }
                )
                .Where(usuaris => usuaris.IdUser == idUser)
                .ToList();

            return notas;
        }

        public static List<UserReport> SeleccionarUsuariosPorGrupo(int idd) {

            List<UserReport> _usuaris = Orm.bd.grups

                .Where(grups => grups.id == idd)
                .Join(
                    Orm.bd.grups_has_alumnes,
                    grups => grups.id,
                    grups_has_alumnes => grups_has_alumnes.grups_id,
                    
                    (grups, grups_has_alumnes) => new 
                    { 
                        usuaris_id = grups_has_alumnes.usuaris_id    
                    }
                )
                .Join(
                    Orm.bd.usuaris,
                    grups_has_alumnes => grups_has_alumnes.usuaris_id,
                    usuaris => usuaris.id,
                    (grups_has_alumnes, usuaris) => new UserReport
                    { 
                        Id = usuaris.id,
                        Dni = usuaris.dni,
                        Name = usuaris.nom,
                        Email = usuaris.correu,
                        Name_Rol = usuaris.rols.nom,
                        Phone = usuaris.telefono,
                        Rol = usuaris.rols_id
                        
                    }
                )
                .OrderBy(grups => grups.Id)
                .ToList();

            return _usuaris;

        }

        public static List<NotaUsuario> SeleccionarNotasPorGrupo(int idd)
        {
            List<NotaUsuario> notas = Orm.bd.grups
                .Where(grups => grups.id == idd)
                .Join(
                    Orm.bd.grups_has_alumnes,
                    grups => grups.id,
                    grups_has_alumnes => grups_has_alumnes.grups_id,

                    (grups, grups_has_alumnes) => new
                    {
                        usuaris_id = grups_has_alumnes.usuaris_id
                    }
                )
                .Join(
                    Orm.bd.usuaris,
                    grups_has_alumnes => grups_has_alumnes.usuaris_id,
                    usuaris => usuaris.id,
                    (grups_has_alumnes, usuaris) => new 
                    {
                        IdUser = usuaris.id
                    }
                )
                .Join(
                    Orm.bd.valoracions,
                    usuaris => usuaris.IdUser,
                    valoracions => valoracions.usuari_valorat_id,
                    (usuaris, valoracions) => new 
                    {
                        IdUser = usuaris.IdUser,
                        Nota = valoracions.nota,
                        IdKpi = valoracions.kpis_id,
                    }
                )
                .Join(
                    Orm.bd.kpis,
                    usuaris => usuaris.IdKpi,
                    kpis => kpis.id,
                    (usuaris, kpis) => new NotaUsuario
                    {
                        IdUser = usuaris.IdUser,
                        Nota = usuaris.Nota,
                        IdKpi = usuaris.IdKpi,
                        NomKpi = kpis.nom,
                    }
                )
                .ToList();

            return notas;
        }

        }
}
