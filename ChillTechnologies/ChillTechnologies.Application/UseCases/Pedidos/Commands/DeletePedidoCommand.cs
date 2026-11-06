using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pedidos.Commands;

public record DeletePedidoCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePedidoCommandHandler : IRequestHandler<DeletePedidoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Pedido>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
