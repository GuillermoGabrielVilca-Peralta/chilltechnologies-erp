using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolPermiso.Commands;

public record AsignarPermisoRolCommand : IRequest<Unit>
{
    public int RolId { get; set; }
    public int PermisoId { get; set; }
}

internal sealed class AsignarPermisoRolCommandHandler : IRequestHandler<AsignarPermisoRolCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AsignarPermisoRolCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AsignarPermisoRolCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.RolPermiso
        {
            RolId = request.RolId,
            PermisoId = request.PermisoId,
            FechaAsignacion = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.RolPermiso>().Insert(data);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
