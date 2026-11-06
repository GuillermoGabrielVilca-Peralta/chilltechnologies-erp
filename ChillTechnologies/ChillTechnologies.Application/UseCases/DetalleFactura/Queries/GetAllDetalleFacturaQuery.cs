using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleFactura.Queries;

public record GetAllDetalleFacturaQuery : IRequest<IEnumerable<Domain.Entities.DetalleFactura>>;

internal sealed class GetAllDetalleFacturaQueryHandler : IRequestHandler<GetAllDetalleFacturaQuery, IEnumerable<Domain.Entities.DetalleFactura>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDetalleFacturaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DetalleFactura>> Handle(GetAllDetalleFacturaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DetalleFactura>().GetAllAsync();
    }
}
