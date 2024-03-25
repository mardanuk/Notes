using FluentValidation;
using Notes.Domain;

namespace Notes.BusinessLogic.Validation
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(note => note.Header).NotEmpty();
            RuleFor(note => note.Text).NotEmpty();
        }
    }
}
