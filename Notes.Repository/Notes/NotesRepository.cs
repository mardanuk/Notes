using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notes.Domain.Options;
using Notes.Repository.Abstracion;

namespace Notes.Repository.Notes
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesContext _context;
        private readonly IOptions<PageConfiguration> _configuration;

        public NotesRepository(NotesContext context, IOptions<PageConfiguration> configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ICollection<Note>> GetAllNotes()
        {
            return await _context.Notes.Take(_configuration.Value.PageCapacity).ToListAsync();
        }

        public async Task<Result<Note>> CreateNote(Note note)
        {
            Result<Note> result = new Result<Note>();
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingNote != null)
            {
                result.Status = Status.NullValue;
                return result;
            }

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            result.Value = note;

            return result;
        }

        public async Task<Result<Note>> DeleteNote(string header)
        {
            Result<Note> result = new Result<Note>();
            var exitingNote = (await GetNote(header)).Value;
            if (exitingNote != null)
            {
                _context.Notes.Remove(exitingNote);
            }
            else
            {
                result.Status = Status.NotFound;
            }
            return result;
        }

        public async Task<Result<Note>> GetNote(string header)
        {
            Result<Note> result = new Result<Note>();
            result.Value = await _context.Notes.FirstOrDefaultAsync(x => x.Header == header);
            if (result.Value == null)
            {
                result.Status = Status.NotFound;
            }
            return result;
        }

        public async Task<Result<Note>> UpdateNote(Note note)
        {
            Result<Note> result = new Result<Note>();
            if (note == null)
            {
                result.Status = Status.NullValue;
                return result;
            }

            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingNote == null) await _context.Notes.AddAsync(note);
            else exitingNote = note;

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
