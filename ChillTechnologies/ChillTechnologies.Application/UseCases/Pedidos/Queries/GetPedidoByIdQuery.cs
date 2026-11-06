using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pedidos.Queries;

public record GetPedidoByIdQuery(int Id) : IRequest<Domain.Entities.Pedido>;

internal sealed class GetPedidoByIdQueryHandler : IRequestHandler<GetPedidoByIdQuery, Domain.Entities.Pedido>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPedidoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Pedido> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Pedido>().GetByIdAsync(request.Id))!;
    }
}
