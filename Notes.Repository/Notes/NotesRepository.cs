using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notes.Domain.Options;

namespace Notes.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesContext _context;
        private readonly IOptions<PageConfiguration> _configuration;

        public NotesRepository(NotesContext context, IOptions<PageConfiguration> configuration)
        {
            _context = context;
            _configuration = configuration;
            _configuration = configuration;
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
            return await _context.Notes.Take(_configuration.Value.PageCapacity).ToListAsync();
        }

        public async Task<Note?> GetNote(string header)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.Header == header);
        }

        public async Task<Note?> AddAccess(Note note, User user)
        {
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingUser == null || exitingNote == null) return null;

            exitingNote.Users.Add(user);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task<ICollection<User>?> GetUsers(Note note)
        {
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == note.Header);

            if (exitingNote == null) return null;

            return exitingNote.Users;
        }
    }
}
