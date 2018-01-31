using FluentValidation;
using DuosChargeService.Models;

namespace DuosChargeService
{
    public class TariffsRequestValidator : AbstractValidator<TariffsRequest>
    {
        public TariffsRequestValidator() => RuleFor(request => request.Date).NotEmpty();
    }

    public class TimeBandsRequestValidator : AbstractValidator<TimeBandsRequest>
    {
        public TimeBandsRequestValidator() => RuleFor(request => request.Date).NotEmpty();
    }
}