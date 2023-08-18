using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO.UsersDTOs
{
    public record UserResetPasswordDTO(string Password, string ConfirmPassword, string Token, string Guid);
}
