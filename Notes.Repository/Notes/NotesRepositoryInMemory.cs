namespace Notes.Repository.Notes;

using System.Collections.Concurrent;
using Domain;
using global::Notes.Repository.Abstracion;

public class NotesRepositoryInMemory : INotesRepository
{
    private ConcurrentDictionary<string, Note> _notes =
        new ConcurrentDictionary<string, Note>();

    public Task<Note> CreateNote(Note note)
    {
        ArgumentNullException.ThrowIfNull(note);
        return Task.Run(() => _notes.TryAdd(note.Header, note) ? note : throw new Exception());
    }

    public Task<ICollection<Note>> GetAllNotes() => Task.Run(() => _notes.Values);

    public Task DeleteNote(string header) => Task.Run(() => _notes.TryRemove(header, out _));

    public Task UpdateNote(Note note)
    {
        ArgumentNullException.ThrowIfNull(note);
        return Task.Run(() => _notes.AddOrUpdate(note.Header, note, (_, _) => note));
    }

    public Task<Note?> GetNote(string header) => Task.FromResult(_notes.GetValueOrDefault(header));
}
