using FluentValidation;

namespace DMTest.Services.RestServices.ViewModels.Validations
{
    class RouletteCloseViewModelValidator : AbstractValidator<RouletteCloseViewModel>
    {
        public RouletteCloseViewModelValidator()
        {
            RuleFor(vm => vm.RouletteId)
                .GreaterThan(0).WithMessage("Debe ser mayor a cero");
        }
    }
}
