using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Commands;

public record DeleteDetalleOrdenCompraCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDetalleOrdenCompraCommandHandler : IRequestHandler<DeleteDetalleOrdenCompraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDetalleOrdenCompraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDetalleOrdenCompraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleOrdenCompra>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
