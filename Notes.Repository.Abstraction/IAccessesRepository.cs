using Notes.Domain;

namespace Notes.Repository
{
    public interface IAccessesRepository
    {
        Task<ICollection<Note>?> GetNotes(int userid);
        Task<ICollection<User>?> GetUsers(string header);
        Task<bool> AddAccess(string header, int userid);
    }
}
