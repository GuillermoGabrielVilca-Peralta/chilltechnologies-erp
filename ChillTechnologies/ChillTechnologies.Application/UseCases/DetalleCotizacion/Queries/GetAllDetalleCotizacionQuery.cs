using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleCotizacion.Queries;

public record GetAllDetalleCotizacionQuery : IRequest<IEnumerable<Domain.Entities.DetalleCotizacion>>;

internal sealed class GetAllDetalleCotizacionQueryHandler : IRequestHandler<GetAllDetalleCotizacionQuery, IEnumerable<Domain.Entities.DetalleCotizacion>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDetalleCotizacionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DetalleCotizacion>> Handle(GetAllDetalleCotizacionQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DetalleCotizacion>().GetAllAsync();
    }
}
