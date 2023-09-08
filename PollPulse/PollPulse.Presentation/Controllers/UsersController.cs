using MediatR;
using Microsoft.AspNetCore.Mvc;
using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Notifications;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Common.DTOResults;

namespace PollPulse.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public UsersController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet("emailconfirmation")]
        public async Task<IActionResult> ConfirmUserEmail(string token, string guid)
        {
            var result = await _sender.Send(new ConfirmUserEmailCommand(token, Guid.Parse(guid)));

            if (!result.Succeeded)
                return BadRequest("Error in email confirmation.");

            return Redirect("https://localhost:5011/login?emailConfirmed=true");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegister)
        {
            if (userRegister is null)
                return BadRequest("User for register is null");

            var result = await _sender.Send(new RegisterUserCommand(userRegister));
            
            if (!result.registerResult.Succeeded)
            {
                return BadRequest(new UserRegisterResultDTO
                {
                    Errors = result.registerResult.Errors
                    .Select(er => er.Description)
                    .ToList()
                });
            }

            var confirmationLink = await _sender.Send(new GenerateEmailConfirmationTokenCommand(result.user));

            await _publisher.Publish(new UserRegisteredEvent(result.user.Email!, $"{result.user.FirstName} {result.user.LastName}", confirmationLink));

            return StatusCode(201, new UserRegisterResultDTO
            {
                IsSuccesfull = true
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLogin)
        {
            if (userLogin is null)
                return BadRequest("User for login is null");
             
            var result = await _sender.Send(new  LoginUserCommand(userLogin));

            if (result.Item2 != "")
                return Unauthorized(new UserLoginResultDTO
                {
                    Errors = new List<string>
                    {
                        result.Item2
                    }
                });

            var token = await _sender.Send(new GenerateNewJwtTokenCommand(result.Item1));

            return Ok(new UserLoginResultDTO
            {
                IsSuccesfull = true,
                Token = token
            });
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> UserForgotPassword([FromBody] UserForgotPasswordDTO userForgotPassword)
        {
            if (userForgotPassword is null)
                return BadRequest("Forgot password is null");

            var resetLink = await _sender.Send(new GeneratePasswordResetTokenCommand(userForgotPassword.Email));

            if (resetLink != "")
                await _publisher.Publish(new UserForgotPasswordEvent(userForgotPassword.Email, resetLink));

            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetUserPassword([FromBody] UserResetPasswordDTO userResetPassword)
        {
            if (userResetPassword is null)
                return BadRequest("User reset is null");

            var result = await _sender.Send(new ResetUserPasswordCommand(userResetPassword));

            if (!result.Succeeded)
            {
                return BadRequest(new UserResetPasswordResultDTO
                {
                    Errors = result.Errors
                   .Select(er => er.Description)
                   .ToList()
                });
            }

            return Ok(new UserResetPasswordResultDTO
            {
                IsSuccesfull = true
            });
        }

    }
}
