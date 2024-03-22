using Notes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly NotesContext _context;

        public UsersRepository(NotesContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(User user)
        {
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            if (exitingUser != null) return null;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int userid)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userid);
        }
    }
}
