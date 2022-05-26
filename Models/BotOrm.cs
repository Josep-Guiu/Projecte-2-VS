using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public static class BotOrm
    {

        public static List<botchat> SelectRequestsPendientes(bool actiu)
        {
            List<botchat> _botchat = Orm.bd.botchat
                .Where(x => x.actiu == actiu)
                .OrderByDescending(x => x.id)
                .ToList();
            return _botchat;
        }

        public static String Update(botchat _botchat)
        {
            String missatge = "";
            missatge = Orm.MySaveChanges();
            return missatge;
        }

    }
}
