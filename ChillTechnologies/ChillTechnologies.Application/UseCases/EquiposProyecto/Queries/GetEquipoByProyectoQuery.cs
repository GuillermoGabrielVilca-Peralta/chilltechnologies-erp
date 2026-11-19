using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EquiposProyecto.Queries;

public record GetEquipoByProyectoQuery(int ProyectoId) : IRequest<IEnumerable<Domain.Entities.EquiposProyecto>>;

internal sealed class GetEquipoByProyectoQueryHandler : IRequestHandler<GetEquipoByProyectoQuery, IEnumerable<Domain.Entities.EquiposProyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEquipoByProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.EquiposProyecto>> Handle(GetEquipoByProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.EquiposProyecto>()
            .FindAsync(e => e.ProyectoId == request.ProyectoId);
    }
}
