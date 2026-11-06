using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pedidos.Queries;

public record GetAllPedidosQuery : IRequest<IEnumerable<Domain.Entities.Pedido>>;

internal sealed class GetAllPedidosQueryHandler : IRequestHandler<GetAllPedidosQuery, IEnumerable<Domain.Entities.Pedido>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPedidosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Pedido>> Handle(GetAllPedidosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Pedido>().GetAllAsync();
    }
}
