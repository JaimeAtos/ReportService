using Application.Parameters;

namespace Application.Features.ReportBase.Queries.GetAllReportBaseQuery;

public class GetAllReportBaseQueryParameters : RequestParameter
{
    public string? ReportName { get; set; }
    public bool Status { get; set; }
}