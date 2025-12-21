using FluentValidation;

namespace Ordering.Application.Validators
{
    public class CheckoutOrderCommandValidatorv2 : AbstractValidator<CheckoutOrderCommandValidatorv2>
    {
        public CheckoutOrderCommandValidatorv2()
        {
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

        }
    }
}
