using Notes.Domain;

namespace Notes.BusinessLogic.Abstraction
{
    public interface IUsersProceed
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUser(int userid);
        Task<User?> CreateUser(User user);
    }
}
