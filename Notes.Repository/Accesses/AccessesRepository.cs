using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Notes.Repository
{
    public class AccessesRepository : IAccessesRepository
    {
        private readonly NotesContext _context;

        public AccessesRepository(NotesContext context)
        {
            _context = context;
        }

        public async Task<User?> AddAccess(string header, int id)
        {
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == header);

            if (exitingUser == null || exitingNote == null) return null;

            exitingNote.Users.Add(exitingUser);
            await _context.SaveChangesAsync();

            return exitingUser;
        }

        public async Task<ICollection<User>?> GetUsers(string header)
        {
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == header);

            if (exitingNote == null) return null;

            return exitingNote.Users;
        }

        public async Task<ICollection<Note>?> GetNotes(int id)
        {
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (exitingUser == null) return null;

            return exitingUser.Notes;
        }
    }
}
