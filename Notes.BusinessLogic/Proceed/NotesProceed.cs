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
        /// <summary>
        /// Создает заметку
        /// </summary>
        /// <param name="note"></param>
        /// <returns>Значения могут быть Ok, NotValid, NullValue</returns>
        public async Task<Result<Note>> CreateNote(Note note)
        {
            return _noteValidator.Validate(note).IsValid
                ? await _repository.CreateNote(note) 
                : new Result<Note>() { Status = Status.NotValid };
        }
        /// <summary>
        /// Возвращает все заметки
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Note>> GetAllNotes()
        {
            return await _repository.GetAllNotes();
        }
        /// <summary>
        /// Находит заметку по заголовку
        /// </summary>
        /// <param name="header"></param>
        /// <returns>Значения могут быть Ok, NotValid</returns>
        public async Task<Result<Note>> GetNote(string header)
        {
            return string.IsNullOrWhiteSpace(header)
                ? new Result<Note>() { Status = Status.NotValid }
                : await _repository.GetNote(header);
        }

        Task<Result<Note>> INotesProceed.DeleteNote(string header)
        {
            throw new NotImplementedException();
        }

        Task<Result<Note>> INotesProceed.UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
