using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;
using Notes.Domain;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersProceed _usersProceed;

        public UsersController(IUsersProceed usersProceed)
        {
            _usersProceed = usersProceed;
        }

        [HttpGet]
        // GET users/
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _usersProceed.GetAllUsers();
            return Ok(users.Select(x => x.Adapt<UserDto>()));
        }

        // GET users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDto>> Get(int id)
        {
            var user = await _usersProceed.GetUser(id);
            return Ok(user.Adapt<UserDto>());
        }

        // PUT users/
        [HttpPut]
        public async Task<ActionResult> Put(UserDto user)
        {
            var _user = await _usersProceed.CreateUser(user.Adapt<User>());
            return Ok(_user.Adapt<UserDto>());
        }
    }
}
