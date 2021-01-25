using FluentValidation;

namespace DMTest.Services.RestServices.ViewModels.Validations
{
    public class BetColorCreateViewModelValidator : AbstractValidator<BetColorCreateViewModel>
    {
        public BetColorCreateViewModelValidator()
        {
            RuleFor(vm => vm.RouletteId)
                .GreaterThanOrEqualTo(1).WithMessage("Debe ser mayor a cero");
            RuleFor(vm => vm.BetAmount)
                .GreaterThanOrEqualTo(1).WithMessage("El monto mínimo de apuesta es 1")
                .LessThanOrEqualTo(10000).WithMessage("El monto máximo de apuesta es 10000");
            RuleFor(vm => vm.Color)
                .InclusiveBetween(0, 1).WithMessage("Los valores permitidos son 0 para negro y 1 para rojo");
        }
    }
}
