using Microsoft.AspNetCore.Identity;
using PollPulse.Entities.Models;
using PollPulse.Repository.Interfaces;

namespace PollPulse.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> RegisterUser(User user, string password) =>
             await _userManager.CreateAsync(user, password);

        public async Task<SignInResult> LoginUser(string username, string password) => await _signInManager.PasswordSignInAsync(username, password, false, true);

        public async Task<string> GenerateTokenForEmailConfirmation(User user) => await _userManager.GenerateEmailConfirmationTokenAsync(user);

        public async Task<User?> GetUserById(int id) => await _userManager.FindByIdAsync(id.ToString());

        public async Task<User?> GetUserByUsername(string username) => await _userManager.FindByNameAsync(username);

        public async Task<IdentityResult> ConfirmUserEmail(User user, string token) => await _userManager.ConfirmEmailAsync(user, token);
    }
}
