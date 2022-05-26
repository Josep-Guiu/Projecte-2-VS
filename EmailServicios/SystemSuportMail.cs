using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.EmailServicios
{
    public class SystemSuportMail : MasterEmailServices
    {
        public SystemSuportMail()
        {
            senderMail = "soportesystemskillup@gmail.com";
            password = "@admin1803";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            iniciarSmtpClient();
            
        }
    }
}
