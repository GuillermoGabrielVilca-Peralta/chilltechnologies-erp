using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosCaja.Queries;

public record GetMovimientoCajaByIdQuery(int Id) : IRequest<Domain.Entities.MovimientosCaja>;

internal sealed class GetMovimientoCajaByIdQueryHandler : IRequestHandler<GetMovimientoCajaByIdQuery, Domain.Entities.MovimientosCaja>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovimientoCajaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.MovimientosCaja> Handle(GetMovimientoCajaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.MovimientosCaja>().GetByIdAsync(request.Id))!;
    }
}
