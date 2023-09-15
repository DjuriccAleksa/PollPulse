using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Authentication
{
    public class UserResetPasswordModel
    {
        [Required(ErrorMessage = "Password can't be empty")]
        [MinLength(8, ErrorMessage = "Password need atleast 8 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password can't be empty")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
        public string Guid { get; set; }

    }
}
