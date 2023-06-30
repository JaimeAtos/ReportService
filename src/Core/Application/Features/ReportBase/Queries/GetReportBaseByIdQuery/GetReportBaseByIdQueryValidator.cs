using FluentValidation;

namespace Application.Features.ReportBase.Queries.GetReportBaseByIdQuery;

public class GetReportBaseByIdQueryValidator : AbstractValidator<GetReportBaseByIdQuery>
{
    public GetReportBaseByIdQueryValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("{PropertyName} must not be empty");
    }
}