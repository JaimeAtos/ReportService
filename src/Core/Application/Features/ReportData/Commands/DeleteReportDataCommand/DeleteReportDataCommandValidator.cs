using FluentValidation;

namespace Application.Features.ReportData.Commands.DeleteReportDataCommand;

public class DeleteReportDataCommandValidator: AbstractValidator<DeleteReportDataCommand>
{
    public DeleteReportDataCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("{PropertyName} must not be empty");
    }   
}