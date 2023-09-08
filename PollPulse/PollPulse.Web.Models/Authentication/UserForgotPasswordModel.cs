using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Authentication
{
    public class UserForgotPasswordModel
    {
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Enter a email address in valid format (example@gmail.com)")]
        public string Email { get; set; }
    }
}
