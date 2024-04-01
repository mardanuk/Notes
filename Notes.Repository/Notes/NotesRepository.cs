using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notes.Domain.Options;
using Notes.Repository.Abstracion;

namespace Notes.Repository.Notes
{
    public class NotesRepository(NotesContext context, IOptions<PageConfiguration> configuration) : INotesRepository
    {
        public async Task<ICollection<Note>> GetAllNotes()
        {
            return await context.Notes.Take(configuration.Value.PageCapacity).ToListAsync();
        }

        public async Task<Result<Note>> CreateNote(Note note)
        {
            Result<Note> result = new Result<Note>();
            var exitingNote = await context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingNote != null)
            {
                result.Status = Status.ExistingValue;
                return result;
            }

            await context.Notes.AddAsync(note);
            await context.SaveChangesAsync();
            result.Value = note;

            return result;
        }

        public async Task<Result<Note>> DeleteNote(string header)
        {
            Result<Note> result = await GetNote(header);
            if (result.Status != Status.Ok)
            {
                return result;
            }
            else if (result.Value == null) 
            {
                result.Status = Status.Undefined; 
                return result;
            }

            context.Notes.Remove(result.Value);
            return result;
        }

        public async Task<Result<Note>> GetNote(string header)
        {
            Result<Note> result = new Result<Note>();
            result.Value = await context.Notes.FirstOrDefaultAsync(x => x.Header == header);
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

            var exitingNote = await context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingNote == null) await context.Notes.AddAsync(note);
            else exitingNote.Text = note.Text;

            await context.SaveChangesAsync();

            return result;
        }
    }
}
