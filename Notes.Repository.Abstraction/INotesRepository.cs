using Notes.Domain;

namespace Notes.Repository.Abstracion
{
    public interface INotesRepository
    {
        Task<ICollection<Note>> GetAllNotes();
        Task<Note?> GetNote(string header);
        Task<Note?> CreateNote(Note note);
    }
}
