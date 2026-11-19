using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposProyecto.Queries;

public record GetAllTiposProyectoQuery : IRequest<IEnumerable<Domain.Entities.TiposProyecto>>;

internal sealed class GetAllTiposProyectoQueryHandler : IRequestHandler<GetAllTiposProyectoQuery, IEnumerable<Domain.Entities.TiposProyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposProyecto>> Handle(GetAllTiposProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposProyecto>().GetAllAsync();
    }
}
