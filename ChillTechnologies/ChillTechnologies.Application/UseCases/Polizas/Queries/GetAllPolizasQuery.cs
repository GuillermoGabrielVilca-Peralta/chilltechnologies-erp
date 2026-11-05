using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Polizas.Queries;

public record GetAllPolizasQuery : IRequest<IEnumerable<Domain.Entities.Poliza>>;

internal sealed class GetAllPolizasQueryHandler : IRequestHandler<GetAllPolizasQuery, IEnumerable<Domain.Entities.Poliza>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPolizasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Poliza>> Handle(GetAllPolizasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Poliza>().GetAllAsync();
    }
}
