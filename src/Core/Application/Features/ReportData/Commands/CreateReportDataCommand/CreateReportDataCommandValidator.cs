using FluentValidation;

namespace Application.Features.ReportData.Commands.CreateReportDataCommand;

public class CreateReportDataCommandValidator : AbstractValidator<CreateReportDataCommand>
{
    public CreateReportDataCommandValidator()
    {
        RuleFor(r => r.ReportKey)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .MaximumLength(9).WithMessage("{PropertyName} must not exceed {MaxLength} characters");
            
        RuleFor(r => r.Data)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

    }
}