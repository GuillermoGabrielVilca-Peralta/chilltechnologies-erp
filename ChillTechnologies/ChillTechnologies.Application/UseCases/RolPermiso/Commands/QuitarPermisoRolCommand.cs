using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolPermiso.Commands;

public record QuitarPermisoRolCommand(int RolId, int PermisoId) : IRequest<Unit>;

internal sealed class QuitarPermisoRolCommandHandler : IRequestHandler<QuitarPermisoRolCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public QuitarPermisoRolCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(QuitarPermisoRolCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.RolPermiso>();

        // El orden de las llaves es el que declara el DbContext: (RolId, PermisoId)
        var item = await repo.GetByIdAsync(request.RolId, request.PermisoId);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
