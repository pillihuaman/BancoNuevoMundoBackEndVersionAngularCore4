using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
    public class BEemail
    {
        public string FromName { get; set; }
        public string FromAdress { get; set; }
        public List<string> EmailList { get; set; }
        public string USerID { get; set; }
        public string UserPassword { get; set; }
        public string DominioLocal { get; set; }
        public string MailPuerto { get; set; }
        public string MailHost { get; set; }
        public string Html { get; set; }
        public string ToAdress { get; set; }
         public string Subject { get; set; }
    }
}
