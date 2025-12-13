using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Id} обязательно для заполнения.")
                .GreaterThan(0)
                .WithMessage("{Id} не может быть отрицательным.");
            RuleFor(o => o.UserName)
                .NotEmpty()
                .WithMessage("{UserName} обязательно для заполнения.")
                .NotNull()
                .MaximumLength(70)
                .WithMessage("{UserName} не должно превышать 70 символов.");
            RuleFor(o => o.TotalPrice)
                .NotEmpty()
                .WithMessage("{TotalPrice} обязательно для заполнения.")
                .GreaterThan(-1)
                .WithMessage("{TotalPrice} не должно быть отрицательным.");
            RuleFor(o => o.EmailAddress)
                .NotEmpty()
                .WithMessage("{EmailAddress} обязательно для заполнения.");
            RuleFor(o => o.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("{FirstName} обязательно для заполнения.");
            RuleFor(o => o.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("{LastName} обязательно для заполнения.");
        }
    }
}
