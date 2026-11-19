using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proyectos.Commands;

public record CreateProyectoCommand : IRequest<int>
{
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int TipoProyectoId { get; set; }
    public int? ContratoId { get; set; }
    public int? ProductoSoftwareId { get; set; }
    public int? JefeProyectoId { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public decimal Presupuesto { get; set; }
    public decimal HorasEstimadas { get; set; }
}

internal sealed class CreateProyectoCommandHandler : IRequestHandler<CreateProyectoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProyectoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Proyecto
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            TipoProyectoId = request.TipoProyectoId,
            ContratoId = request.ContratoId,
            ProductoSoftwareId = request.ProductoSoftwareId,
            JefeProyectoId = request.JefeProyectoId,
            FechaInicio = request.FechaInicio,
            FechaFinEstimada = request.FechaFinEstimada,
            Presupuesto = request.Presupuesto,
            HorasEstimadas = request.HorasEstimadas,
            AvancePorcentaje = 0,
            Estado = "Planificado",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Proyecto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
