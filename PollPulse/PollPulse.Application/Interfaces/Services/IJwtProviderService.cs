﻿using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Interfaces.Services
{
    public interface IJwtProviderService
    {
        string GenerateJwtToken(User user);
    }
}
