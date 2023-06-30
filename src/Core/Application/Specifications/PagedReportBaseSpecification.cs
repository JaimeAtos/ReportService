using Application.Features.ReportBase.Queries.GetAllReportBaseQuery;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications;

public class PagedReportBaseSpecification : Specification<ReportBase>
{
    public PagedReportBaseSpecification(GetAllReportBaseQuery request)
    {
        Query.Skip(request.PageNumber * request.PageSize)
            .Take(request.PageSize);

        if (!string.IsNullOrEmpty(request.ReportName))
            Query.Search(s => s.ReportName, "%" + request.ReportName + "%");
        
        //TODO: revisar como podemos omitir la conversion de datos
        if (!string.IsNullOrEmpty(request.State.ToString()))
            Query.Search(s => s.State.ToString(), "%" + request.State + "%");
        
        
    }
}