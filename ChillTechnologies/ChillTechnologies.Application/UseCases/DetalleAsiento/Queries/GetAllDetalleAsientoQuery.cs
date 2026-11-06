using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleAsiento.Queries;

public record GetAllDetalleAsientoQuery : IRequest<IEnumerable<Domain.Entities.DetalleAsiento>>;

internal sealed class GetAllDetalleAsientoQueryHandler : IRequestHandler<GetAllDetalleAsientoQuery, IEnumerable<Domain.Entities.DetalleAsiento>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDetalleAsientoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DetalleAsiento>> Handle(GetAllDetalleAsientoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DetalleAsiento>().GetAllAsync();
    }
}
