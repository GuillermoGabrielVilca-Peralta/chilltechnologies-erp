using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Defectos.Commands;

public record CreateDefectoCommand : IRequest<int>
{
    public int ProyectoId { get; set; }
    public int? HistoriaId { get; set; }
    public int? VersionId { get; set; }
    public string Codigo { get; set; } = null!;
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? PasosReproduccion { get; set; }
    public string Severidad { get; set; } = "Media";
    public int? ReportadoPorId { get; set; }
}

internal sealed class CreateDefectoCommandHandler : IRequestHandler<CreateDefectoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDefectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDefectoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Defecto
        {
            ProyectoId = request.ProyectoId,
            HistoriaId = request.HistoriaId,
            VersionId = request.VersionId,
            Codigo = request.Codigo,
            Titulo = request.Titulo,
            Descripcion = request.Descripcion,
            PasosReproduccion = request.PasosReproduccion,
            Severidad = request.Severidad,
            ReportadoPorId = request.ReportadoPorId,
            AsignadoAId = null,
            Estado = "Abierto",
            FechaReporte = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Defecto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
