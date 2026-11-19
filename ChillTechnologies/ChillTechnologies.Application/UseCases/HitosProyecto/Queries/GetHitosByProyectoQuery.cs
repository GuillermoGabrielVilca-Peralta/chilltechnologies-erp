using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HitosProyecto.Queries;

public record GetHitosByProyectoQuery(int ProyectoId) : IRequest<IEnumerable<Domain.Entities.HitosProyecto>>;

internal sealed class GetHitosByProyectoQueryHandler : IRequestHandler<GetHitosByProyectoQuery, IEnumerable<Domain.Entities.HitosProyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHitosByProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.HitosProyecto>> Handle(GetHitosByProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.HitosProyecto>()
            .FindAsync(h => h.ProyectoId == request.ProyectoId);
    }
}
