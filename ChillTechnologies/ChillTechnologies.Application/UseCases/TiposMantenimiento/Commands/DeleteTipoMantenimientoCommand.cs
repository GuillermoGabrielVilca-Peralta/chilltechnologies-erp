using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMantenimiento.Commands;

public record DeleteTipoMantenimientoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoMantenimientoCommandHandler : IRequestHandler<DeleteTipoMantenimientoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoMantenimientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposMantenimiento>();

        var tipo = await repo.GetByIdAsync(request.Id);

        repo.Delete(tipo!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
