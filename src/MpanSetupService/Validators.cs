using FluentValidation;
using MpanSetupService.Models;

namespace MpanSetupService
{
    public class CompleteMpanRequestValidator : AbstractValidator<CompleteMpanRequest>
    {
        public CompleteMpanRequestValidator() => RuleFor(request => request.SupplyPoint).NotEmpty();
    }

    public class SupplyCapacityRequestValidator : AbstractValidator<SupplyCapacityRequest>
    {
        public SupplyCapacityRequestValidator() => RuleFor(request => request.SupplyPoint).NotEmpty();
    }

    public class ChargeBandsRequestValidator :  AbstractValidator<ChargeBandsRequest>
    {
        public ChargeBandsRequestValidator() 
        {
            RuleFor(request => request.Customer).NotEmpty();
            RuleFor(request => request.Date).NotEmpty();
            RuleFor(request => request.SupplyPoint).NotEmpty();
        }
    }
}