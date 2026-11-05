using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposNotificacion.Commands;

public record DeleteTipoNotificacionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoNotificacionCommandHandler : IRequestHandler<DeleteTipoNotificacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoNotificacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoNotificacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposNotificacion>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
