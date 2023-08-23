using MediatR;
using Microsoft.AspNetCore.Mvc;
using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Notifications;
using PollPulse.Common.DTO.UsersDTOs;

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

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegister)
        {
            if (userRegister is null)
                return BadRequest("User for register is null");

            var result = await _sender.Send(new RegisterUserCommand(userRegister));
            
            if (!result.registerResult.Succeeded)
            {
                foreach (var error in result.Item1.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            var confirmationLink = await _sender.Send(new GenerateEmailConfirmationTokenCommand(result.user));

            await _publisher.Publish(new UserRegisteredEvent(result.user.Email!, $"{result.user.FirstName} {result.user.LastName}", confirmationLink));

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLogin)
        {
            if (userLogin is null)
                return BadRequest("User for login is null");
             
            var result = await _sender.Send(new  LoginUserCommand(userLogin));

            if(!result.Item1)
                return Unauthorized(result.Item2);

            return Ok();
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
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

    }
}
