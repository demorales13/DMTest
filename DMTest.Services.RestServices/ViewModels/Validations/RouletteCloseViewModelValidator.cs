using FluentValidation;

namespace DMTest.Services.RestServices.ViewModels.Validations
{
    class RouletteCloseViewModelValidator : AbstractValidator<RouletteCloseViewModel>
    {
        public RouletteCloseViewModelValidator()
        {
            RuleFor(vm => vm.RouletteId)
                .GreaterThanOrEqualTo(1).WithMessage("Debe ser mayor a cero");
        }
    }
}
