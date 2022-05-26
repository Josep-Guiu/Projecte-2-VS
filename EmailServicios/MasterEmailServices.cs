using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Proyecto2.Models;

namespace Proyecto2.EmailServicios
{
    public abstract class MasterEmailServices
    {
        private SmtpClient smtpClient;
        protected String senderMail;
        protected String password;
        protected String host;
        protected int port;
        protected bool ssl;

        protected void iniciarSmtpClient() {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public void enviarMensajeACliente(String subject, String body, String reciverMail) {
            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(senderMail);
               
                mailMessage.To.Add(reciverMail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;

                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }
        //Para Grupos  de usuarios en teoria es mejor pasarle una lista de usuarios
        public void enviarComunicadosAClientes(String subject, String body, List<usuaris> reciverMail)
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(senderMail);
                foreach (var usuari in reciverMail)
                {
                    mailMessage.To.Add(usuari.correu);
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;

                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

    }
}
