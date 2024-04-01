using Notes.Domain;
using Microsoft.EntityFrameworkCore;
using Notes.Repository.Abstracion;

namespace Notes.Repository.Users
{
    public class UsersRepository(NotesContext context) : IUsersRepository
    {
        public async Task<Result<User>> CreateUser(User user)
        {
            var result = new Result<User>();
            var exitingUser = await context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            if (exitingUser != null)
            {
                result.Status = Status.ExistingValue;
                return result;
            }

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            result.Value = user;

            return result;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<Result<User>> GetUser(int userid)
        {
            var result = new Result<User>();
            result.Value = await context.Users.FirstOrDefaultAsync(x => x.Id == userid);
            if (result.Value == null)
            {
                result.Status = Status.NotFound;
            }
            return result;
        }

        public async Task<Result<User>> DeleteUser(int userid)
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

            context.Users.Remove(result.Value);
            return result;
        }

        public async Task<Result<User>> UpdateUser(User user)
        {
            Result<User> result = new Result<User>();
            if (user == null)
            {
                result.Status = Status.NullValue;
                return result;
            }

            var exitingUser = await context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            if (exitingUser == null) await context.Users.AddAsync(user);
            else exitingUser = user;

            await context.SaveChangesAsync();

            return result;
        }
    }
}
