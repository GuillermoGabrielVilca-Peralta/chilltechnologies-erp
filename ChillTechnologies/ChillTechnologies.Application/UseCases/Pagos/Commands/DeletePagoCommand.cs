using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pagos.Commands;

public record DeletePagoCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePagoCommandHandler : IRequestHandler<DeletePagoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePagoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePagoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Pago>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
