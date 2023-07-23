using System.Threading.Tasks;
using MVCTrial.Models;


namespace MVCTrial.Helper
{
    public interface IMyCustomEmailService
    {
        Task TestingForEmail(UserEmailOption info);

         string getbody(string templatename);

        Task SendEmailConfirmation(UserEmailOption info);


    }
}