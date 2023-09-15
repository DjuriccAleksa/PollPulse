using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Authentication
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "First name is required and can't be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required and can't be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username is required and can't be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required and can't be empty")]
        [EmailAddress(ErrorMessage = "Email address is not in valid format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required and can't be empty")]
        [MinLength(8, ErrorMessage = "Password minimum length is 8 characters")]
        public string Password { get; set; }

    }
}
