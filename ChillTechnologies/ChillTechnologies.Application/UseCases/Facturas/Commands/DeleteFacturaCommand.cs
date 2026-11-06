using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Facturas.Commands;

public record DeleteFacturaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteFacturaCommandHandler : IRequestHandler<DeleteFacturaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFacturaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteFacturaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Factura>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
