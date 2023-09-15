using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Authentication
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [MinLength(4, ErrorMessage = "Password need atleast 4 characters")]
        public string Password { get; set; }
    }
}
