using FluentValidation;
using Notes.Domain;

namespace Notes.BusinessLogic
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty();
        }
    }
}
