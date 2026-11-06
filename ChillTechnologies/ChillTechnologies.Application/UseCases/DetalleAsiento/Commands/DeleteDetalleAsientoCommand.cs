using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleAsiento.Commands;

public record DeleteDetalleAsientoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDetalleAsientoCommandHandler : IRequestHandler<DeleteDetalleAsientoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDetalleAsientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDetalleAsientoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleAsiento>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
