using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessesController : Controller
    {
        private readonly IAccessesProceed _accessesProceed;

        public AccessesController(IAccessesProceed accessesProcced)
        {
            _accessesProceed = accessesProcced;
        }

        // GET accesses/userid/1
        [HttpGet("userid/{userid}")]
        public async Task<ActionResult> GetNotes(int userid)
        {
            var _notes = await _accessesProceed.GetNotes(userid);
            return Ok(_notes?.Select(x => x.Adapt<UserDto>()));
        }

        // GET accesses/header/note1
        [HttpGet("header/{header}")]
        public async Task<ActionResult> GetUsers(string header)
        {
            var _users = await _accessesProceed.GetUsers(header);
            return Ok(_users?.Select(x => x.Adapt<UserDto>()));
        }

        // PUT accesses/note1/1
        [HttpPut("{header}/{userid}")]
        public async Task<ActionResult> AddAccess(string header, int userid)
        {
            var result = await _accessesProceed.AddAccess(header, userid);
            return Ok(result);
        }
    }
}
