using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosPuntos.Queries;

public record GetAllMovimientosPuntosQuery : IRequest<IEnumerable<Domain.Entities.MovimientosPunto>>;

internal sealed class GetAllMovimientosPuntosQueryHandler : IRequestHandler<GetAllMovimientosPuntosQuery, IEnumerable<Domain.Entities.MovimientosPunto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMovimientosPuntosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MovimientosPunto>> Handle(GetAllMovimientosPuntosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MovimientosPunto>().GetAllAsync();
    }
}
