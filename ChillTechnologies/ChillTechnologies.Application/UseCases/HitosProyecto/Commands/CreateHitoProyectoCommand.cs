using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HitosProyecto.Commands;

public record CreateHitoProyectoCommand : IRequest<int>
{
    public int ProyectoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public DateOnly FechaObjetivo { get; set; }
    public decimal Monto { get; set; }
}

internal sealed class CreateHitoProyectoCommandHandler : IRequestHandler<CreateHitoProyectoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateHitoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateHitoProyectoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.HitosProyecto
        {
            ProyectoId = request.ProyectoId,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            FechaObjetivo = request.FechaObjetivo,
            Monto = request.Monto,
            Estado = "Pendiente",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.HitosProyecto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
