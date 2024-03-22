using Notes.Domain;

namespace Notes.Repository
{
    public interface INotesRepository
    {
        Task<ICollection<Note>> GetAllNotes();
        Task<Note?> GetNote(string header);
        Task<Note?> CreateNote(Note note);
        Task<ICollection<User>?> GetUsers(Note note);
        Task<Note?> AddAccess(Note note, User user);
    }
}
