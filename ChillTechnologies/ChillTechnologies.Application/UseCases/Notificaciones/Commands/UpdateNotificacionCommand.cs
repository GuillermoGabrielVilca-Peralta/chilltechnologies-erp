using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Notificaciones.Commands;

public record UpdateNotificacionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    // Marcar como leida o no leida; la fecha de lectura se completa sola
    public bool Leida { get; set; }
}

internal sealed class UpdateNotificacionCommandHandler : IRequestHandler<UpdateNotificacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateNotificacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Notificacione>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Leida = request.Leida;
        item.FechaLectura = request.Leida ? DateTime.Now : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
