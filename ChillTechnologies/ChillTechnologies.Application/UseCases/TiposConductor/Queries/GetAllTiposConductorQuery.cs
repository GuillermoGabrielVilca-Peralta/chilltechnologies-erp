using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposConductor.Queries;

public record GetAllTiposConductorQuery : IRequest<IEnumerable<Domain.Entities.TiposConductor>>;

internal sealed class GetAllTiposConductorQueryHandler : IRequestHandler<GetAllTiposConductorQuery, IEnumerable<Domain.Entities.TiposConductor>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposConductorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposConductor>> Handle(GetAllTiposConductorQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposConductor>().GetAllAsync();
    }
}
