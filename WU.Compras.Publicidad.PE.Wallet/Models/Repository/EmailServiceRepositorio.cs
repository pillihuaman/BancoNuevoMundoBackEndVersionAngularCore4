using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;
using WU.Compras.Publicidad.PE.Wallet.Config;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using System.Net;
using System.Net.Mail;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Repository
{
    public class EmailServiceRepositorio : IEmailService
    {

        //private readonly EmailConfig ec;

        //public EmailServiceRepositorio(IOptions<EmailConfig> emailConfig)
        //{
        //    this.ec = emailConfig.Value;
        //}
        //public EmailServiceRepositorio()
        //{
        //}
        public bool SendEmailASync(BEemail email, EmailConfig ec)
        {
            bool estado = true;
            try
            {
                
              
                Attachment Attach;
                MailMessage mailMessage = new MailMessage();
                SmtpClient SMtCliente = new SmtpClient(ec.MailHost);
                mailMessage.From = new MailAddress(ec.FromAdress, ec.FromName);
                //foreach (string s in objMail._ListaCorreos)
                //{
                    mailMessage.To.Add(email.ToAdress);

                //}
                mailMessage.Subject = email.Subject;
                mailMessage.IsBodyHtml =true;
                mailMessage.Body = email.Html;
                SMtCliente.Port = int.Parse(ec.MailPuerto);
                SMtCliente.Credentials = new System.Net.NetworkCredential(ec.USerID,ec.UserPassword);
                SMtCliente.EnableSsl = true;

                SMtCliente.Send(mailMessage);
 
            }
            catch (SmtpFailedRecipientsException ex1)
            {
                estado = false;
                throw new Exception(ex1.Message);
            }
            catch (Exception ex2)
            {
                estado = false;
                throw new Exception(ex2.Message);
            }
            return estado;
        }

    
    }
}
