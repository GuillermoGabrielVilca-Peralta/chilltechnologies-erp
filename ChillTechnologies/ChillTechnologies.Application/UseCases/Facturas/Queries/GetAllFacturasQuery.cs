using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Facturas.Queries;

public record GetAllFacturasQuery : IRequest<IEnumerable<Domain.Entities.Factura>>;

internal sealed class GetAllFacturasQueryHandler : IRequestHandler<GetAllFacturasQuery, IEnumerable<Domain.Entities.Factura>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFacturasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Factura>> Handle(GetAllFacturasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Factura>().GetAllAsync();
    }
}
