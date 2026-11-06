using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleFactura.Commands;

public record DeleteDetalleFacturaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDetalleFacturaCommandHandler : IRequestHandler<DeleteDetalleFacturaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDetalleFacturaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDetalleFacturaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleFactura>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
