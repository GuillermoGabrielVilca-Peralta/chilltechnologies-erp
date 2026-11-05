using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Notificaciones.Commands;

public record DeleteNotificacionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteNotificacionCommandHandler : IRequestHandler<DeleteNotificacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteNotificacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Notificacione>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
