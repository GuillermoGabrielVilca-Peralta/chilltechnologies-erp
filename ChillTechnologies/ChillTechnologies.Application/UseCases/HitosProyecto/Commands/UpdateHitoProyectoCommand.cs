using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HitosProyecto.Commands;

public record UpdateHitoProyectoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public DateOnly FechaObjetivo { get; set; }
    public decimal Monto { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateHitoProyectoCommandHandler : IRequestHandler<UpdateHitoProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHitoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateHitoProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.HitosProyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.FechaObjetivo = request.FechaObjetivo;
        item.Monto = request.Monto;
        item.Estado = request.Estado;
        item.FechaEntrega = request.Estado is "Entregado" or "Aprobado"
            ? item.FechaEntrega ?? DateOnly.FromDateTime(DateTime.Now)
            : item.FechaEntrega;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
