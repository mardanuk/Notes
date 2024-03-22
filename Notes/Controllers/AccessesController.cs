using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;
using Notes.Domain;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessesController : Controller
    {
        private readonly IAccessesProceed _accessesProcced;

        public AccessesController(IAccessesProceed accessesProcced)
        {
            _accessesProcced = accessesProcced;
        }

        // GET accesses/id/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotes(int id)
        {
            var _users = await _accessesProcced.GetNotes(id);
            return Ok(_users.Select(x => x.Adapt<UserDto>()));
        }

        //// GET accesses/header/note1
        //[HttpGet("header/{header}")]
        //public async Task<ActionResult> GetUsers(string header)
        //{
        //    var _users = await _accessesProcced.GetUsers(header);
        //    return Ok(_users.Select(x => x.Adapt<UserDto>()));
        //}

        // PUT accesses/note1/1
        [HttpPut("{header}/{id}")]
        public async Task<ActionResult> AddAccess(string header, int id)
        {
            var _users = await _accessesProcced.AddAccess(header, id);
            return Ok(_users.Adapt<NoteDto>());
        }
    }
}
