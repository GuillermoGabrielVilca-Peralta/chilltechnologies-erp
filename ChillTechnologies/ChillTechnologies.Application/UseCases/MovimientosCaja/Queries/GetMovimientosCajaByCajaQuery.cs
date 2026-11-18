using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosCaja.Queries;

public record GetMovimientosCajaByCajaQuery(int CajaId) : IRequest<IEnumerable<Domain.Entities.MovimientosCaja>>;

internal sealed class GetMovimientosCajaByCajaQueryHandler : IRequestHandler<GetMovimientosCajaByCajaQuery, IEnumerable<Domain.Entities.MovimientosCaja>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovimientosCajaByCajaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MovimientosCaja>> Handle(GetMovimientosCajaByCajaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MovimientosCaja>()
            .FindAsync(m => m.CajaId == request.CajaId);
    }
}
