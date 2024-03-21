using Notes.Domain;
using Microsoft.EntityFrameworkCore;

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
    }
}
