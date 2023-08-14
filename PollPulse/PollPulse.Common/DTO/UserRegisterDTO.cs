using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO
{
    public record UserRegisterDTO(string FirstName, string LastName, string Username, string Email, string Password);
 }
