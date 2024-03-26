using Notes.Domain;

namespace Notes.BusinessLogic.Abstraction
{
    public interface INotesProceed
    {
        Task<ICollection<Note>> GetAllNotes();
        Task<Result<Note>> GetNote(string header);
        Task<Result<Note>> CreateNote(Note note);
        Task<Result<Note>> UpdateNote(Note note);
        Task<Result<Note>> DeleteNote(string header);
    }
}
