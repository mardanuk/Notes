using Notes.Domain;

namespace Notes.BusinessLogic.Abstraction
{
    public interface INotesProceed
    {
        Task<ICollection<Note>> GetAllNotes();
        Task<Note?> GetNote(string header);
        Task<Note?> CreateNote(Note note);
    }
}
