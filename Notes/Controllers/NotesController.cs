using Microsoft.AspNetCore.Mvc;
using Notes.BusinessLogic.Abstraction;
using Mapster;
using Presentation.DTOs;
using Notes.Domain;
using Notes.BusinessLogic.Proceed;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController(INotesProceed notesProceed, ILogger<NotesController> logger) : Controller
    {
        [HttpGet]
        // GET notes/
        public async Task<ActionResult<IEnumerable<NoteDto>>> Get()
        {
            var notes = await notesProceed.GetAllNotes();

            logger.Log(LogLevel.Information, "NOTES ARE READ");

            return Ok(notes.Select(x =>x.Adapt<NoteDto>()));
        }

        // GET notes/note1
        [HttpGet("{header}")]
        public async Task<ActionResult<NoteDto>> Get(string header)
        {
            var result = await notesProceed.GetNote(header);

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "note");
            logger.Log(LogLevel.Information, logText);

            return Ok(result.Value?.Adapt<NoteDto>());
        }

        // POST notes/
        [HttpPost]
        public async Task<ActionResult> Post(NoteDto note)
        {
            var result = await notesProceed.CreateNote(note.Adapt<Note>());

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "note");
            logger.Log(LogLevel.Information, logText);

            return Ok();
        }

        // PUT notes/
        [HttpPut]
        public async Task<ActionResult> Put(NoteDto note)
        {
            var result = await notesProceed.UpdateNote(note.Adapt<Note>());

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "note");
            logger.Log(LogLevel.Information, logText);

            return Ok();
        }

        // DELETE notes/note0
        [HttpDelete("{header}")]
        public async Task<ActionResult> Delete(string header)
        {
            var result = await notesProceed.DeleteNote(header);

            string logText = ErrorHandler.ErrorHandler.GetResultStatus(result.Status, "note");
            logger.Log(LogLevel.Information, logText);

            return Ok();
        }
    }
}
