using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;
using Notes.Domain;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        private readonly INotesProceed _notesProceed;

        public NotesController(INotesProceed notesProceed)
        {
            _notesProceed = notesProceed;
        }

        [HttpGet]
        // GET notes/
        public async Task<ActionResult<IEnumerable<NoteDto>>> Get()
        {
            var notes = await _notesProceed.GetAllNotes();
            return Ok(notes.Select(x =>x.Adapt<NoteDto>()));
        }

        // GET notes/note1
        [HttpGet("{header}")]
        public async Task<ActionResult<NoteDto>> Get(string header)
        {
            var note = await _notesProceed.GetNote(header);
            return Ok(note.Adapt<NoteDto>());
        }

        // PUT notes/
        [HttpPut]
        public async Task<ActionResult> Put(NoteDto note)
        {
            var _note = await _notesProceed.CreateNote(note.Adapt<Note>());
            return Ok(_note.Adapt<NoteDto>());
        }

        //// GET notes/
        //[HttpGet]
        //public async Task<ActionResult> GetNotes(NoteDto note)
        //{
        //    var _users = await _notesProceed.GetUsers(note.Adapt<Note>());
        //    return Ok(_users.Select(x => x.Adapt<UserDto>()));
        //}

        //// PUT notes/
        //[HttpPut("{note}/{user}")]
        //public async Task<ActionResult> AddAccess(NoteDto note, UserDto user)
        //{
        //    var _users = await _notesProceed.AddAccess(note.Adapt<Note>(), user.Adapt<User>());
        //    return Ok(_users.Adapt<NoteDto>());
        //}
    }
}
