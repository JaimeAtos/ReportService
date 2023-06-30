using Application.Wrappers;
using AutoMapper;
using Domain.Repositories;
using MediatR;


namespace Application.Features.ReportData.Commands.UpdateReportDataCommand;

public class UpdateReportDataCommand: IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string ReportKey { get; set; } = default!;
    public string Data { get; set; } = default!;
}

public class UpdateReportDataCommandHandler : IRequestHandler<UpdateReportDataCommand, Response<bool>>
{
    private readonly IReportBaseRepository _repository;
    private readonly IMapper _mapper;

    public UpdateReportDataCommandHandler(IReportBaseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Response<bool>> Handle(UpdateReportDataCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request), "Request must not be empty");
        return ProcessHandle(request, cancellationToken);
    }

    private async Task<Response<bool>> ProcessHandle(UpdateReportDataCommand request, CancellationToken cancellationToken)
    {
        var report = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (report is null)
            return new Response<bool>(false);
        report = _mapper.Map(request, report);
        await _repository.UpdateAsync(report, cancellationToken);
        return new Response<bool>(true);
    }
}
