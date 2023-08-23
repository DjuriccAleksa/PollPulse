using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PollPulse.Entities.Models;
using PollPulse.Repository.Context;
using PollPulse.Repository.Interfaces;

namespace PollPulse.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RepositoryContext _context;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, RepositoryContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IdentityResult> RegisterUser(User user, string password) =>
             await _userManager.CreateAsync(user, password);

        public async Task<SignInResult> LoginUser(string username, string password) => await _signInManager.PasswordSignInAsync(username, password, false, true);

        public async Task<string> GenerateTokenForEmailConfirmation(User user) => await _userManager.GenerateEmailConfirmationTokenAsync(user);

        public async Task<string> GenerateTokenForPasswordResest(User user) => await _userManager.GeneratePasswordResetTokenAsync(user);

        public async Task<User?> GetUserById(int id) => await _userManager.FindByIdAsync(id.ToString());

        public async Task<User?> GetUserByGuid(Guid guid) => await _context.AppUsers.FirstOrDefaultAsync(u => u.Guid == guid);
        public async Task<User?> GetUserByEmail(string email) => await _userManager.FindByEmailAsync(email);

        public async Task<IdentityResult> ConfirmUserEmail(User user, string token) => await _userManager.ConfirmEmailAsync(user, token);

        public async Task<IdentityResult> ResetPassword(User user, string token, string password) => await _userManager.ResetPasswordAsync(user, token, password);

        public async Task<User?> GetUserByUsername(string username) => await _userManager.FindByNameAsync(username);
    }
}
