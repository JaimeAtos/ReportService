using Application.Wrappers;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.ReportData.Commands.CreateReportDataCommand;

public class CreateReportDataCommand : IRequest<Response<Guid>>
{
    public string ReportKey { get; set; } = null!;
    public string Data { get; set; } = null!;
}

public class CreateReportDataCommandHandler : IRequestHandler<CreateReportDataCommand, Response<Guid>>
{
    private readonly IReportBaseRepository _repository;
    private readonly IMapper _mapper;

    public CreateReportDataCommandHandler(IReportBaseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Response<Guid>> Handle(CreateReportDataCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request), "Request must not be empty");
        return ProcessHandle(request, cancellationToken);
    }

    private async Task<Response<Guid>>  ProcessHandle(CreateReportDataCommand request, CancellationToken cancellationToken)
    {
        var report = _mapper.Map<Domain.Entities.ReportBase>(request);
        var record = await _repository.AddAsync(report, cancellationToken);
        return new Response<Guid>(record.Id);
    }
}