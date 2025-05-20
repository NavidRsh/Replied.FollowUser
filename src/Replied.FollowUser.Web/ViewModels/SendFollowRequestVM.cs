using FluentValidation;

namespace Replied.FollowUser.Web.ViewModels;

public record SendFollowRequestVM(Guid FromUserId, Guid ToUserId);

public class SendFollowRequestVMValidator : AbstractValidator<SendFollowRequestVM>
{
    public SendFollowRequestVMValidator()
    {
        RuleFor(x => x.FromUserId).NotEmpty().WithMessage("FromUserId is required.");
        RuleFor(x => x.ToUserId).NotEmpty().WithMessage("ToUserId is required.");
        RuleFor(x => x).Must(x => x.FromUserId != x.ToUserId)
            .WithMessage("You cannot follow yourself.");
    }
}