using Notes.Domain;

namespace Notes.BusinessLogic.Abstraction
{
    public interface IUsersProceed
    {
        Task<ICollection<User>> GetAllUsers();
        Task<Result<User>> GetUser(int userid);
        Task<Result<User>> CreateUser(User user);
        Task<Result<User>> UpdateUser(User user);
        Task<Result<User>> DeleteUser(int userid);
    }
}
