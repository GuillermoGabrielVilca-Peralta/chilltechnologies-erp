using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SolicitudesAusencia.Commands;

public record CreateSolicitudAusenciaCommand : IRequest<int>
{
    public int EmpleadoId { get; set; }
    public int TipoAusenciaId { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public int Dias { get; set; }
    public string? Motivo { get; set; }
}

internal sealed class CreateSolicitudAusenciaCommandHandler : IRequestHandler<CreateSolicitudAusenciaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSolicitudAusenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSolicitudAusenciaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.SolicitudesAusencium
        {
            EmpleadoId = request.EmpleadoId,
            TipoAusenciaId = request.TipoAusenciaId,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            Dias = request.Dias,
            Motivo = request.Motivo,
            Estado = "Pendiente",
            FechaSolicitud = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.SolicitudesAusencium>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
