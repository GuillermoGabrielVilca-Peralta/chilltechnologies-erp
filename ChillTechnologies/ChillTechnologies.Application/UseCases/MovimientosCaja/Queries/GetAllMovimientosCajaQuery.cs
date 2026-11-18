using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosCaja.Queries;

public record GetAllMovimientosCajaQuery : IRequest<IEnumerable<Domain.Entities.MovimientosCaja>>;

internal sealed class GetAllMovimientosCajaQueryHandler : IRequestHandler<GetAllMovimientosCajaQuery, IEnumerable<Domain.Entities.MovimientosCaja>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMovimientosCajaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MovimientosCaja>> Handle(GetAllMovimientosCajaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MovimientosCaja>().GetAllAsync();
    }
}
