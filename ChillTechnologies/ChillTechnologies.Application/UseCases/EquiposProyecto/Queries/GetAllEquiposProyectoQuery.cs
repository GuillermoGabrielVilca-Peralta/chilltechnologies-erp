using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EquiposProyecto.Queries;

public record GetAllEquiposProyectoQuery : IRequest<IEnumerable<Domain.Entities.EquiposProyecto>>;

internal sealed class GetAllEquiposProyectoQueryHandler : IRequestHandler<GetAllEquiposProyectoQuery, IEnumerable<Domain.Entities.EquiposProyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEquiposProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.EquiposProyecto>> Handle(GetAllEquiposProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.EquiposProyecto>().GetAllAsync();
    }
}
