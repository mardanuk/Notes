using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;
using Notes.Domain;
using Notes.BusinessLogic.Proceed;

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
            return Ok(note.Value?.Adapt<NoteDto>());
        }

        // POST notes/
        [HttpPost]
        public async Task<ActionResult> Post(NoteDto note)
        {
            var _note = await _notesProceed.CreateNote(note.Adapt<Note>());
            return Ok(_note.Value?.Adapt<NoteDto>());
        }

        // PUT notes/
        [HttpPut]
        public async Task<ActionResult> Put(NoteDto note)
        {
            var _note = await _notesProceed.UpdateNote(note.Adapt<Note>());
            return Ok(_note.Adapt<NoteDto>());
        }

        // DELETE notes/note0
        [HttpDelete("{header}")]
        public async Task<ActionResult> Delete(string header)
        {
            var _note = await _notesProceed.DeleteNote(header);
            return Ok(_note.Adapt<NoteDto>());
        }
    }
}
