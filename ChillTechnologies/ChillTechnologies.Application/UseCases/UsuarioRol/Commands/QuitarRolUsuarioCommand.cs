using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuarioRol.Commands;

public record QuitarRolUsuarioCommand(int UsuarioSistemaId, int RolId) : IRequest<Unit>;

internal sealed class QuitarRolUsuarioCommandHandler : IRequestHandler<QuitarRolUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public QuitarRolUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(QuitarRolUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.UsuarioRol>();
        
        var item = await repo.GetByIdAsync(request.UsuarioSistemaId, request.RolId);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
