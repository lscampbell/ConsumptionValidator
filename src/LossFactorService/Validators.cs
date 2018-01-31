using FluentValidation;
using LossFactorService.Models;

namespace LossFactorService
{
    public class DistributionLossFactorRequestValidator : AbstractValidator<DistributionLossFactorRequest>
    {
        public DistributionLossFactorRequestValidator()
        {
            RuleFor(request => request.Date).NotEmpty();
            RuleFor(request => request.Area).NotEmpty();
            RuleFor(request => request.LLF).NotEmpty();
        }
    }

    public class TransmissionLossFactorRequestValidator : AbstractValidator<TransmissionLossFactorRequest>
    {
        public TransmissionLossFactorRequestValidator() => RuleFor(request => request.Date).NotEmpty();
    }
}
