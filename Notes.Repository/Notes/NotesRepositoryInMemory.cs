////using Notes.Domain;
////using System.Collections.Concurrent;
////using System.Collections.Generic;

////namespace Notes.Repository.Notes
////{
////    public class NotesRepositoryInMemory : INotesRepository
////    {
////        public ConcurrentDictionary<string, Note> Notes = new ConcurrentDictionary<string, Note> ();

////        public async Task<Note?> CreateNote(Note note)
////        {
////            var exitingNote = Notes.SingleOrDefault(x => x.Header == note.Header);

////            if (exitingNote != null) return null;

////            Notes.Add(note);

////            return note;
////        }

////        public async Task<ICollection<Note>> GetAllNotes()
////        {
////            return Notes.ToList();
////        }

////        public async Task<Note?> GetNote(string header)
////        {
////            return Notes.FirstOrDefault(x => x.Header == header);
////        }
////    }
////}
