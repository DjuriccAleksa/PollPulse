using Microsoft.AspNetCore.Identity;
using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.UsersDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Commands.UserCommands
{
    public record ResetUserPasswordCommand(UserResetPasswordDTO User) : ICommand<IdentityResult>;
}
