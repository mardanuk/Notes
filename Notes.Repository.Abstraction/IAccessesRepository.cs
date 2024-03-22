using Notes.Domain;

namespace Notes.Repository
{
    public interface IAccessesRepository
    {
        Task<ICollection<Note>?> GetNotes(int id);
        Task<ICollection<User>?> GetUsers(string header);
        Task<User?> AddAccess(string header, int id);
    }
}
