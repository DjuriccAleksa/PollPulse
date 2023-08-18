using MediatR;
using Microsoft.AspNetCore.Mvc;
using PollPulse.CommandsAndQueries.Commands.UserCommands;
using PollPulse.CommandsAndQueries.Notifications;
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

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegister)
        {
            if (userRegister == null)
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

            await _publisher.Publish(new UserRegisteredEvent(result.user.Guid));

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLogin)
        {
            if (userLogin == null)
                return BadRequest("User for login is null");
             
            var result = await _sender.Send(new  LoginUserCommand(userLogin));

            if(!result.Item1)
                return Unauthorized(result.Item2);

            return Ok();
        }

        [HttpGet("emailconfirmation")]
        public async Task<IActionResult> ConfirmUserEmail(string token, string guid)
        {
            var result = await _sender.Send(new ConfirmUserEmailCommand(token, Guid.Parse(guid)));

            if (!result.Succeeded)
                return BadRequest("Error in email confirmation.");

            return Ok();                        
        }


    }
}
