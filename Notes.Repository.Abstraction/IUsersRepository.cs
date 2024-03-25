using Notes.Domain;

namespace Notes.Repository.Abstracion
{
    public interface IUsersRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUser(int userid);
        Task<User?> CreateUser(User user);
    }
}
