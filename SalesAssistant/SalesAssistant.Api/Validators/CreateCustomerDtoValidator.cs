using FluentValidation;
using SalesAssistant.Api.Dtos.Requests;

public class CreateCustomerDtoValidator
    : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
