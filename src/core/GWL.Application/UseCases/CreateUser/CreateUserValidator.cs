using FluentValidation;

namespace GWL.Application.UseCases.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(10).MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(10).MaximumLength(100);
            RuleFor(x => x.Gender).NotEmpty().MinimumLength(1).MaximumLength(1);
            RuleFor(x => x.Age).NotNull();
        }
    }
}
