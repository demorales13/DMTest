using FluentValidation;

namespace DMTest.Services.RestServices.ViewModels.Validations
{
    public class RouletteChangeStatusViewModelValidator : AbstractValidator<RouletteChangeStatusViewModel>
    {
        public RouletteChangeStatusViewModelValidator()
        {
            RuleFor(vm => vm.RouletteId)
                .GreaterThanOrEqualTo(1).WithMessage("Debe ser mayor a cero");
        }
    }
}
