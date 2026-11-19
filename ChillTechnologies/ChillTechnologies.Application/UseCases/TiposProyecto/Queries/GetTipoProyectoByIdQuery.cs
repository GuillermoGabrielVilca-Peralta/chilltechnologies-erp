using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposProyecto.Queries;

public record GetTipoProyectoByIdQuery(int Id) : IRequest<Domain.Entities.TiposProyecto>;

internal sealed class GetTipoProyectoByIdQueryHandler : IRequestHandler<GetTipoProyectoByIdQuery, Domain.Entities.TiposProyecto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoProyectoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposProyecto> Handle(GetTipoProyectoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposProyecto>().GetByIdAsync(request.Id))!;
    }
}
