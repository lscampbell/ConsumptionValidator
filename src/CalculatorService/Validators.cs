using FluentValidation;
using CalculatorService.Models;

namespace CalculatorService
{
    public class CalculatorRequestValidator : AbstractValidator<CalculatorRequest>
    {
        public CalculatorRequestValidator() 
        { 
            RuleFor(request => request.Date).NotEmpty();
            RuleFor(request => request.SupplyPoint).NotEmpty();
        }
    }
}