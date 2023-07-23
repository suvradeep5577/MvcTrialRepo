using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.Models
{
    public class SMTPEmailModel
    {

        public string SenderAddress { get; set; }

        public string SenderDisplayName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string host { get; set; }

        public int Port { get; set; }

        public bool EnableSSL { get; set; }

        public bool UseDefaultCredentials { get; set; }

        public bool IsBodyHTML { get; set; }

        
    }
}
