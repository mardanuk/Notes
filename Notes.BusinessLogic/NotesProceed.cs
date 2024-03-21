using FluentValidation;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository;

namespace Notes.BusinessLogic
{
    public class NotesProceed : INotesProceed
    {
        private readonly INotesRepository _repository;
        private readonly IValidator<Note> _validator;

        public NotesProceed(INotesRepository repository, IValidator<Note> validator) 
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Note?> CreateNote(Note note)
        {
            return _validator.Validate(note).IsValid
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
