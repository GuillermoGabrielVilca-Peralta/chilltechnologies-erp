using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetallePedido.Queries;

public record GetDetallePedidoByIdQuery(int Id) : IRequest<Domain.Entities.DetallePedido>;

internal sealed class GetDetallePedidoByIdQueryHandler : IRequestHandler<GetDetallePedidoByIdQuery, Domain.Entities.DetallePedido>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDetallePedidoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DetallePedido> Handle(GetDetallePedidoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DetallePedido>().GetByIdAsync(request.Id))!;
    }
}
