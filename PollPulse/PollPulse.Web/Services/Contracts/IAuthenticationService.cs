using PollPulse.Common.DTO.UsersDTOs;

namespace PollPulse.Web.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task Login(UserLoginDTO userLoginDTO);
    }
}
