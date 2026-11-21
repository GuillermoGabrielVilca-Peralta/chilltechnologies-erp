using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Commands;

public record UpdateTicketSoporteCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Asunto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int TipoTicketId { get; set; }
    public string Severidad { get; set; } = null!;
    public int? DefectoId { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateTicketSoporteCommandHandler : IRequestHandler<UpdateTicketSoporteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketSoporteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTicketSoporteCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TicketsSoporte>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Asunto = request.Asunto;
        item.Descripcion = request.Descripcion;
        item.TipoTicketId = request.TipoTicketId;
        item.Severidad = request.Severidad;
        item.DefectoId = request.DefectoId;
        item.Estado = request.Estado;

        item.FechaCierre = request.Estado is "Resuelto" or "Cerrado"
            ? item.FechaCierre ?? DateTime.Now
            : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
