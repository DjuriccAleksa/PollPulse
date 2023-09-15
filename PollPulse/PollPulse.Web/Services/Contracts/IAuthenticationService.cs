using PollPulse.Common.DTOResults;
using PollPulse.Web.Models.Authentication;

namespace PollPulse.Web.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<UserLoginResultDTO> Login(UserLoginModel userLoginDTO);
        Task Logout();
        Task<UserRegisterResultDTO> Register(UserRegisterModel userRegisterDTO);
        Task<UserResetPasswordResultDTO> ResetPassword(UserResetPasswordModel userResetPassword);
        Task<bool> SendResetLink(UserForgotPasswordModel userForgotPasswordDTO);
    }
}
