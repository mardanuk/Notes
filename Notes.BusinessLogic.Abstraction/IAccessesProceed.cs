using Notes.Domain;

namespace Notes.BusinessLogic.Abstraction
{
    public interface IAccessesProceed
    {
        Task<ICollection<Note>?> GetNotes(int userid);
        Task<ICollection<User>?> GetUsers(string header);// TODO: not nullable
        Task<bool> AddAccess(string header, int userid);
    }
}
