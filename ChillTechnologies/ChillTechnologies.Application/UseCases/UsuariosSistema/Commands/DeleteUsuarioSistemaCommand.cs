using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Commands;

public record DeleteUsuarioSistemaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteUsuarioSistemaCommandHandler : IRequestHandler<DeleteUsuarioSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUsuarioSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUsuarioSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.UsuariosSistema>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
