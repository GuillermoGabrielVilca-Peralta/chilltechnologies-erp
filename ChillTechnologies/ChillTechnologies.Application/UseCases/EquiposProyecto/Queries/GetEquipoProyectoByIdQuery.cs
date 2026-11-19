using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EquiposProyecto.Queries;

public record GetEquipoProyectoByIdQuery(int Id) : IRequest<Domain.Entities.EquiposProyecto>;

internal sealed class GetEquipoProyectoByIdQueryHandler : IRequestHandler<GetEquipoProyectoByIdQuery, Domain.Entities.EquiposProyecto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEquipoProyectoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.EquiposProyecto> Handle(GetEquipoProyectoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.EquiposProyecto>().GetByIdAsync(request.Id))!;
    }
}
