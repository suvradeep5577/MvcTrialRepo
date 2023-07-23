using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCTrial.Models;

namespace MVCTrial.BookRepositary
{
    public interface IAccountRepositary
    {
        Task logout();
        Task<SignInResult> PasswordCheck(LoginModel info);
        Task<IdentityResult> SignUpData(SignUpUserData info);
        Task<IdentityResult> EmailConfirm(string uid, string token);
    }
}