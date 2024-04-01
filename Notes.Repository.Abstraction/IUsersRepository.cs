using Notes.Domain;

namespace Notes.Repository.Abstracion
{
    public interface IUsersRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<Result<User>> GetUser(int userid);
        Task<Result<User>> CreateUser(User user);
        Task<Result<User>> UpdateNote(User user);
        Task<Result<User>> DeleteNote(int userid);
    }
}
