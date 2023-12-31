﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Commands.UserCommands
{
    public record RegisterUserCommand(UserRegisterDTO User) : ICommand<(IdentityResult registerResult, User user)>;
}
