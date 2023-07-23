using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCTrial.Models;
using System.IO;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace MVCTrial.Helper
{
    public class MyCustomEmailService : IMyCustomEmailService
    {
        private readonly SMTPEmailModel smobj;

        private readonly IConfiguration conobj;

        private const string templatepath = @"EmailTemplate/{0}.html";

        public MyCustomEmailService(IOptions<SMTPEmailModel> obj, IConfiguration conobj2)
        {
            //smobj = obj.Value;
            conobj = conobj2;
        }

        public async Task TestingForEmail(UserEmailOption info)
        {
            //info.Body = getbody("TestEmail");
            info.Body =updateplaceholder( getbody("TestEmail"), info.Placeholders);
            info.Subject = "Testing MVC Trial Mail";
            await SendEmail(info);
        }
        public async Task SendEmailConfirmation(UserEmailOption info)
        {
            //info.Body = getbody("TestEmail");
            info.Body = updateplaceholder(getbody("EmailConfirm"), info.Placeholders);
            info.Subject = "Confirmation Email";
            await SendEmail(info);
        }
        private async Task SendEmail(UserEmailOption info)
        {
            SMTPEmailModel eobj = new SMTPEmailModel();  
            conobj.Bind("SMTPConfig", eobj);

           // conobj.Bind("SMTPConfig", smobj);
            MailMessage Email = new MailMessage()
            {
                Subject =info.Subject ,
                Body = info.Body,
                From = new MailAddress(eobj.SenderAddress, eobj.SenderDisplayName),
                //To="suvradeep.sr@gmail.com",
                IsBodyHtml = true
            };
            Email.To.Add("suvradeep.sr@gail.com");

            NetworkCredential ntwork = new NetworkCredential(eobj.UserName, eobj.Password);

            SmtpClient smcl = new SmtpClient()
            {
                Host = eobj.host,
                Port = eobj.Port,
                EnableSsl = eobj.EnableSSL,
                UseDefaultCredentials = eobj.UseDefaultCredentials,
                Credentials = ntwork
            };

            Email.BodyEncoding = Encoding.Default;

            await smcl.SendMailAsync(Email);


        }


        public string getbody(string templatename)
        {
            var body = File.ReadAllText(string.Format(templatepath,templatename));
            return body;
        }

        public string updateplaceholder(string text, List<KeyValuePair<string,string>> keyvaluepair)
        {

            if(keyvaluepair!=null && !string.IsNullOrEmpty(text))
            {
                foreach(var item in keyvaluepair)
                {
                    if(text.Contains(item.Key))
                    {
                        text = text.Replace(item.Key, item.Value);
                    }
                }
            }

            return text;

        }
    }
}
