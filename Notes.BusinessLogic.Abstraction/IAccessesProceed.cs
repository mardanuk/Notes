using Notes.Domain;

namespace Notes.BusinessLogic.Abstraction
{
    public interface IAccessesProceed
    {
        Task<ICollection<Note>> GetNotes(int id);
        Task<ICollection<User>> GetUsers(string header);// TODO: not nullable
        Task<User?> AddAccess(string header, int id);// TODO: bool, id->userid
    }
}
