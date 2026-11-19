using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuarioRol.Commands;

public record AsignarRolUsuarioCommand : IRequest<Unit>
{
    public int UsuarioSistemaId { get; set; }
    public int RolId { get; set; }
}

internal sealed class AsignarRolUsuarioCommandHandler : IRequestHandler<AsignarRolUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AsignarRolUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AsignarRolUsuarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.UsuarioRol
        {
            UsuarioSistemaId = request.UsuarioSistemaId,
            RolId = request.RolId,
            FechaAsignacion = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.UsuarioRol>().Insert(data);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
