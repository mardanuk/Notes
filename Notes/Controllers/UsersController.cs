using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;
using Notes.Domain;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUsersProceed _usersProceed, ILogger<UsersController> logger) : Controller
    {

        [HttpGet]
        // GET users/
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _usersProceed.GetAllUsers();
            logger.Log(LogLevel.Information, "USERS ARE READ");
            return Ok(users.Select(x => x.Adapt<UserDto>()));
        }

        // GET users/1
        [HttpGet("{userid}")]
        public async Task<ActionResult<NoteDto>> Get(int userid)
        {
            var result = await _usersProceed.GetUser(userid);

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "user");
            logger.Log(LogLevel.Information, logText);

            return Ok(result.Value?.Adapt<UserDto>());
        }

        // POST users/
        [HttpPost]
        public async Task<ActionResult> Post(UserDto user)
        {
            var result = await _usersProceed.CreateUser(user.Adapt<User>());

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "user");
            logger.Log(LogLevel.Information, logText);

            return Ok();
        }

        // PUT users/
        [HttpPut]
        public async Task<ActionResult> Put(UserDto user)
        {
            var result = await _usersProceed.UpdateUser(user.Adapt<User>());

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "user");
            logger.Log(LogLevel.Information, logText);

            return Ok();
        }

        // DELETE users/3
        [HttpDelete("{userid}")]
        public async Task<ActionResult> Delete(int userid)
        {
            var result = await _usersProceed.DeleteUser(userid);

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "user");
            logger.Log(LogLevel.Information, logText);

            return Ok();
        }
    }
}
