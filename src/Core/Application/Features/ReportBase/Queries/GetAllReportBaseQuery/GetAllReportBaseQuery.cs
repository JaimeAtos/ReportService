using Application.DTOs;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.ReportBase.Queries.GetAllReportBaseQuery;

public class GetAllReportBaseQuery : IRequest<PagedResponse<List<ReportBaseDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? ReportName { get; set; }
    public bool State { get; set; }
}

public class GetAllReportBaseQueryHandler : IRequestHandler<GetAllReportBaseQuery, PagedResponse<List<ReportBaseDto>>>
{
    private readonly IReportBaseRepository _repository;
    private readonly IMapper _mapper;

    public GetAllReportBaseQueryHandler(IReportBaseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<PagedResponse<List<ReportBaseDto>>> Handle(GetAllReportBaseQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request), "Request must not be empty");
        return ProcessHandle(request, cancellationToken);
    }

    private async Task<PagedResponse<List<ReportBaseDto>>> ProcessHandle(GetAllReportBaseQuery request, CancellationToken cancellationToken)
    {
        var pagination = new PagedReportBaseSpecification(request);
        var reports = await _repository.ListAsync(pagination, cancellationToken);
        var reportsDto = _mapper.Map<List<ReportBaseDto>>(reports);
        return new PagedResponse<List<ReportBaseDto>>(reportsDto, request.PageNumber, request.PageSize);
    }
}