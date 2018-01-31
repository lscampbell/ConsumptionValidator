using FluentValidation;
using ProfileDataService.Models;

namespace ProfileDataService
{
    public class ProfileDataRequestValidators : AbstractValidator<ProfileDataRequest>
    {
        public ProfileDataRequestValidators()
        {
            RuleFor(request => request.Date).NotEmpty();
            RuleFor(request => request.SupplyPoint).NotEmpty();
        }
    }
}