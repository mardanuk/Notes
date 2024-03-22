using Notes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.Repository
{
    public class AccessesRepository : IAccessesRepository
    {
        private readonly NotesContext _context;

        public AccessesRepository(NotesContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAccess(string header, int userid)
        {
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == userid);
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == header);

            if (exitingUser == null || exitingNote == null) return false;

            exitingNote.Users.Add(exitingUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<User>?> GetUsers(string header)
        {
            var exitingNote = await _context.Notes.SingleOrDefaultAsync(x => x.Header == header);

            if (exitingNote == null) return null;

            return exitingNote.Users;
        }

        public async Task<ICollection<Note>?> GetNotes(int userid)
        {
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == userid);

            if (exitingUser == null) return null;

            return exitingUser.Notes;
        }
    }
}
