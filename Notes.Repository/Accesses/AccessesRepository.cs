using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using Notes.Repository.Abstracion;

namespace Notes.Repository.Accesses
{
    public class AccessesRepository(NotesContext context) : IAccessesRepository
    {
        public async Task<bool> AddAccess(string header, int userid)
        {
            var exitingUser = await context.Users.SingleOrDefaultAsync(x => x.Id == userid);
            var exitingNote = await context.Notes.SingleOrDefaultAsync(x => x.Header == header);

            if (exitingUser == null || exitingNote == null) return false;

            exitingNote.Users.Add(exitingUser);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<User>?> GetUsers(string header)
        {
            var exitingNote = await context.Notes.SingleOrDefaultAsync(x => x.Header == header);

            if (exitingNote == null) return null;

            return exitingNote.Users;
        }

        public async Task<ICollection<Note>?> GetNotes(int userid)
        {
            var exitingUser = await context.Users.SingleOrDefaultAsync(x => x.Id == userid);

            if (exitingUser == null) return null;

            return exitingUser.Notes;
        }
    }
}
