using FluentValidation;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository.Abstracion;

namespace Notes.BusinessLogic.Proceed
{
    public class NotesProceed : INotesProceed
    {
        private readonly INotesRepository _repository;
        private readonly IValidator<Note> _noteValidator;

        public NotesProceed(INotesRepository repository, IValidator<Note> noteValidator) 
        {
            _repository = repository;
            _noteValidator = noteValidator;
        }

        public async Task<Note?> CreateNote(Note note)
        {
            return _noteValidator.Validate(note).IsValid
                ? await _repository.CreateNote(note) 
                : null;
        }

        public async Task<ICollection<Note>> GetAllNotes()
        {
            return await _repository.GetAllNotes();
        }

        public async Task<Note?> GetNote(string header)
        {
            return string.IsNullOrWhiteSpace(header)
                ? null
                : await _repository.GetNote(header);
        }
    }
}
