using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Facturas.Queries;

public record GetFacturaByIdQuery(int Id) : IRequest<Domain.Entities.Factura>;

internal sealed class GetFacturaByIdQueryHandler : IRequestHandler<GetFacturaByIdQuery, Domain.Entities.Factura>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Factura> Handle(GetFacturaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Factura>().GetByIdAsync(request.Id))!;
    }
}
