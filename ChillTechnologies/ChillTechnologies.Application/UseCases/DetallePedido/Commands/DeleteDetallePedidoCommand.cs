using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetallePedido.Commands;

public record DeleteDetallePedidoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDetallePedidoCommandHandler : IRequestHandler<DeleteDetallePedidoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDetallePedidoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDetallePedidoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetallePedido>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
