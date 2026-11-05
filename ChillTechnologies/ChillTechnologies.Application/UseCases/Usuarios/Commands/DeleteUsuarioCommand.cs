using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Commands;

public record DeleteUsuarioCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Usuario>();

        var usuario = await repo.GetByIdAsync(request.Id);

        repo.Delete(usuario!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
