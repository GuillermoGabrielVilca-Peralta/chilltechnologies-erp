using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleAsiento.Queries;

public record GetDetalleAsientoByIdQuery(int Id) : IRequest<Domain.Entities.DetalleAsiento>;

internal sealed class GetDetalleAsientoByIdQueryHandler : IRequestHandler<GetDetalleAsientoByIdQuery, Domain.Entities.DetalleAsiento>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDetalleAsientoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DetalleAsiento> Handle(GetDetalleAsientoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DetalleAsiento>().GetByIdAsync(request.Id))!;
    }
}
