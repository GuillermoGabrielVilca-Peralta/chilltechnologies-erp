using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleCotizacion.Queries;

public record GetDetalleCotizacionByIdQuery(int Id) : IRequest<Domain.Entities.DetalleCotizacion>;

internal sealed class GetDetalleCotizacionByIdQueryHandler : IRequestHandler<GetDetalleCotizacionByIdQuery, Domain.Entities.DetalleCotizacion>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDetalleCotizacionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DetalleCotizacion> Handle(GetDetalleCotizacionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DetalleCotizacion>().GetByIdAsync(request.Id))!;
    }
}
