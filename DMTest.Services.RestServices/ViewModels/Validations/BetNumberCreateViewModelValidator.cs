using FluentValidation;

namespace DMTest.Services.RestServices.ViewModels.Validations
{
    public class BetNumberCreateViewModelValidator : AbstractValidator<BetNumberCreateViewModel>
    {
        public BetNumberCreateViewModelValidator()
        {
            RuleFor(vm => vm.RouletteId)
                .GreaterThanOrEqualTo(1).WithMessage("Debe ser mayor a cero");
            RuleFor(vm => vm.BetAmount)
                .GreaterThanOrEqualTo(1).WithMessage("El monto mínimo de apuesta es 1")
                .LessThanOrEqualTo(10000).WithMessage("El monto máximo de apuesta es 10000");
            RuleFor(vm => vm.Number)
                .GreaterThanOrEqualTo(0).WithMessage("El número mínimo de la ruleta es el 0")
                .LessThanOrEqualTo(36).WithMessage("El número máximo de la ruleta es el 36");
        }
    }
}
