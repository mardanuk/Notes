namespace Notes.Repository.Notes;

using System.Collections.Concurrent;
using Domain;
using global::Notes.Repository.Abstracion;

public class NotesRepositoryInMemory : INotesRepository
{
    private ConcurrentDictionary<string, Note> _notes =
        new ConcurrentDictionary<string, Note>();


    public Task<ICollection<Note>> GetAllNotes() => Task.Run(() => _notes.Values);

    public Task<Note?> GetNote(string header) => Task.FromResult(_notes.GetValueOrDefault(header));

    Task<Result<Note>> INotesRepository.GetNote(string header)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Note>> CreateNote(Note note)
    {
        Result<Note> result = new Result<Note>();
        if (note == null)
        {
            result.Status = Status.NullValue;
        }
        else if (_notes.TryAdd(note.Header, note)) 
        {
            result.Value = note;
        }
        else 
        { 
            result.Status = Status.Undefined; 
        }

        return Task.FromResult(result);
    }

    public Task<Result<Note>> UpdateNote(Note note)
    {
        Result<Note> result = new Result<Note>();
        if (note == null)
        {
            result.Status = Status.NullValue;
            return Task.FromResult(result);
        }
        _notes.AddOrUpdate(note.Header, note, (_, _) => note);
        return Task.FromResult(result);
    }

    public Task<Result<Note>> DeleteNote(string header)
    {
        Result<Note> result = new Result<Note>();
        if (!_notes.TryRemove(header, out _))
        {
            result.Status = Status.Undefined;
        }
        return Task.FromResult(result);
    }
}
