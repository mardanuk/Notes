using Notes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesContext _context;

        public NotesRepository(NotesContext context)
        {
            _context = context;
        }

        public async Task<Note?> CreateNote(Note note)
        {
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingNote != null) return null;

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task<ICollection<Note>> GetAllNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note?> GetNote(string header)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.Header == header);
        }
    }
}
