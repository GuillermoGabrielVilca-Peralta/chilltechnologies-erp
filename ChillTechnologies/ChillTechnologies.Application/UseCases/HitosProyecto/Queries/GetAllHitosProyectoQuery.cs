using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HitosProyecto.Queries;

public record GetAllHitosProyectoQuery : IRequest<IEnumerable<Domain.Entities.HitosProyecto>>;

internal sealed class GetAllHitosProyectoQueryHandler : IRequestHandler<GetAllHitosProyectoQuery, IEnumerable<Domain.Entities.HitosProyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllHitosProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.HitosProyecto>> Handle(GetAllHitosProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.HitosProyecto>().GetAllAsync();
    }
}
