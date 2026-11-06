using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleCotizacion.Commands;

public record DeleteDetalleCotizacionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDetalleCotizacionCommandHandler : IRequestHandler<DeleteDetalleCotizacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDetalleCotizacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDetalleCotizacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleCotizacion>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
