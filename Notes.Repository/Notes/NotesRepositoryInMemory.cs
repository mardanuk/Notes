using Notes.Domain;

namespace Notes.Repository
{
    public class NotesRepositoryInMemory : INotesRepository
    {
        public ICollection<Note> Notes = new List<Note>();

        public async Task<Note?> CreateNote(Note note)
        {
            var exitingNote = Notes.SingleOrDefault(x => x.Header == note.Header);

            if (exitingNote != null) return null;

            Notes.Add(note);

            return note;
        }

        public async Task<ICollection<Note>> GetAllNotes()
        {
            return Notes.ToList();
        }

        public async Task<Note?> GetNote(string header)
        {
            return Notes.FirstOrDefault(x => x.Header == header);
        }


        Task<Note?> INotesRepository.AddAccess(Note note, User user)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<User>> INotesRepository.GetUsers(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
