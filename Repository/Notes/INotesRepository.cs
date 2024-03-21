namespace Repository.Notes
{
    public interface INotesRepository
    {
        ICollection<Note> GetAllNotes();
    }
}
