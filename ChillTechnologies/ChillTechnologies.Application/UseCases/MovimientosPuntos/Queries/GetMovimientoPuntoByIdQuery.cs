using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosPuntos.Queries;

public record GetMovimientoPuntoByIdQuery(int Id) : IRequest<Domain.Entities.MovimientosPunto>;

internal sealed class GetMovimientoPuntoByIdQueryHandler : IRequestHandler<GetMovimientoPuntoByIdQuery, Domain.Entities.MovimientosPunto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovimientoPuntoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.MovimientosPunto> Handle(GetMovimientoPuntoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.MovimientosPunto>().GetByIdAsync(request.Id))!;
    }
}
