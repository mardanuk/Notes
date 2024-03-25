using FluentValidation;
using Notes.Domain;

namespace Notes.BusinessLogic.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty();
        }
    }
}
