using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using Notes.Repository.Abstracion;
using System.Reflection.PortableExecutable;

namespace Notes.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly NotesContext _context;

        public UsersRepository(NotesContext context)
        {
            _context = context;
        }

        public async Task<Result<User>> CreateUser(User user)
        {
            var result = new Result<User>();
            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            if (exitingUser != null)
            {
                result.Status = Status.ExistingValue;
                return result;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            result.Value = user;

            return result;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Result<User>> GetUser(int userid)
        {
            var result = new Result<User>();
            result.Value = await _context.Users.FirstOrDefaultAsync(x => x.Id == userid);
            if (result.Value == null)
            {
                result.Status = Status.NotFound;
            }
            return result;
        }

        public async Task<Result<User>> DeleteNote(int userid)
        {
            Result<User> result = await GetUser(userid);
            if (result.Status != Status.Ok)
            {
                return result;
            }
            else if (result.Value == null)
            {
                result.Status = Status.Undefined;
                return result;
            }

            _context.Users.Remove(result.Value);
            return result;
        }

        public async Task<Result<User>> UpdateNote(User user)
        {
            Result<User> result = new Result<User>();
            if (user == null)
            {
                result.Status = Status.NullValue;
                return result;
            }

            var exitingUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            if (exitingUser == null) await _context.Users.AddAsync(user);
            else exitingUser = user;

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
