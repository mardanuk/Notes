using FluentValidation;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository;

namespace Notes.BusinessLogic
{
    public class NotesProceed : INotesProceed
    {
        private readonly INotesRepository _repository;
        private readonly IValidator<Note> _noteValidator;
        private readonly IValidator<User> _userValidator;

        public NotesProceed(INotesRepository repository, IValidator<Note> noteValidator, IValidator<User> userValidator) 
        {
            _repository = repository;
            _noteValidator = noteValidator;
            _userValidator = userValidator;
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

        public async Task<Note?> AddAccess(Note note, User user)
        {
            return _noteValidator.Validate(note).IsValid
                && _userValidator.Validate(user).IsValid
                ? await _repository.AddAccess(note, user)
                : null;
        }

        public async Task<ICollection<User>?> GetUsers(Note note)
        {
            return _noteValidator.Validate(note).IsValid
                ? await _repository.GetUsers(note)
                : null;
        }
    }
}
