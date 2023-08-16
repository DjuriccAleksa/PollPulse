using Microsoft.AspNetCore.Identity;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(User user, string password);
        Task<SignInResult> LoginUser(string username, string password);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByGuid(Guid guid);
        Task<string> GenerateTokenForEmailConfirmation(User user);
        Task<IdentityResult> ConfirmUserEmail(User user, string token);
    }
}
