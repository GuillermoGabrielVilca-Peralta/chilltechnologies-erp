using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposNotificacion.Commands;

public record UpdateTipoNotificacionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Canal { get; set; } = null!;
}

internal sealed class UpdateTipoNotificacionCommandHandler : IRequestHandler<UpdateTipoNotificacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoNotificacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoNotificacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposNotificacion>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Canal = request.Canal;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
