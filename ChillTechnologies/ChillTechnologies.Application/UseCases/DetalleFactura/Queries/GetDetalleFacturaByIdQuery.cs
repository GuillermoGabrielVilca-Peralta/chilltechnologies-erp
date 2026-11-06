using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleFactura.Queries;

public record GetDetalleFacturaByIdQuery(int Id) : IRequest<Domain.Entities.DetalleFactura>;

internal sealed class GetDetalleFacturaByIdQueryHandler : IRequestHandler<GetDetalleFacturaByIdQuery, Domain.Entities.DetalleFactura>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDetalleFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DetalleFactura> Handle(GetDetalleFacturaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DetalleFactura>().GetByIdAsync(request.Id))!;
    }
}
