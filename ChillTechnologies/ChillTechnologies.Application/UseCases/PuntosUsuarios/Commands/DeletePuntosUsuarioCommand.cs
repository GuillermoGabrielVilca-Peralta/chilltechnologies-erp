using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PuntosUsuarios.Commands;

public record DeletePuntosUsuarioCommand(int UsuarioId) : IRequest<Unit>;

internal sealed class DeletePuntosUsuarioCommandHandler : IRequestHandler<DeletePuntosUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePuntosUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePuntosUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.PuntosUsuario>();

        var puntos = await repo.GetByIdAsync(request.UsuarioId);

        repo.Delete(puntos!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
