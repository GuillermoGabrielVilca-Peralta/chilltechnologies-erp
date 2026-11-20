using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Commands;

public record DeleteHistoriaUsuarioCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteHistoriaUsuarioCommandHandler : IRequestHandler<DeleteHistoriaUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHistoriaUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteHistoriaUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
