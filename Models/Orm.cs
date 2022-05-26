using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class Orm
    {
        public static frase_aluEntities1 bd = new frase_aluEntities1();

        public static String Errores(SqlException sqlException)
        {
            String msm = "";

            switch (sqlException.Number)
            {
                case 2:
                    msm = "El servidor no está operativo";
                    break;
                case 547:
                    msm = "El registro tiene datos relacionados";
                    break;
                case 2601:
                    msm = "Registro duplicado";
                    break;
                case 2627:
                    msm = "Registro duplicado";
                    break;
                case 4060:
                    msm = "No se puede abrir la base de datos";
                    break;
                case 18456:
                    msm = "Error al iniciar sesión";
                    break;
                default:
                    msm = sqlException.Number + "-" + sqlException.Message;
                    break;
            }

            return msm;
        }

        public static String MySaveChanges(){
            String msm = "";
            try{
                Orm.bd.SaveChanges();
            }catch (DbUpdateException ex){
                SqlException excepcion = (SqlException)ex.InnerException.InnerException;
                msm = Orm.Errores(excepcion);
                RejectedChanges();
            }
            
            return msm;
        }

        public static void RejectedChanges()
        {
            foreach (DbEntityEntry item in bd.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case System.Data.Entity.EntityState.Detached:
                        break;
                    case System.Data.Entity.EntityState.Unchanged:
                        break;
                    case System.Data.Entity.EntityState.Added:
                        item.State = System.Data.Entity.EntityState.Detached;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        item.Reload();
                        break;
                    case System.Data.Entity.EntityState.Modified:
                        item.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    default:
                        break;
                }
            }
        }



    }
}
