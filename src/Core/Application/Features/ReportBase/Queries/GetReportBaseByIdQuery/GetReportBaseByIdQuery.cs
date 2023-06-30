using Application.DTOs;
using Application.Wrappers;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.ReportBase.Queries.GetReportBaseByIdQuery;

public class GetReportBaseByIdQuery : IRequest<Response<ReportBaseDto>>
{
    public Guid Id { get; set; }
}

public class GetReportBaseByIdQueryHandler : IRequestHandler<GetReportBaseByIdQuery, Response<ReportBaseDto>>
{
    private readonly IReportBaseRepository _repository;
    private readonly IMapper _mapper;

    public GetReportBaseByIdQueryHandler(IReportBaseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Response<ReportBaseDto>> Handle(GetReportBaseByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request), "Request must not be empty");
        return ProcessHandle(request, cancellationToken);
    }

    private async Task<Response<ReportBaseDto>> ProcessHandle(GetReportBaseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var report = await _repository.GetByIdAsync(request.Id, cancellationToken);

        var reportDto = _mapper.Map<ReportBaseDto>(report);
        return new Response<ReportBaseDto>(reportDto);
    }
}