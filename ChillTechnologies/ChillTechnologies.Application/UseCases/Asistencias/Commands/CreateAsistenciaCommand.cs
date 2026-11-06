using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Asistencias.Commands;

public record CreateAsistenciaCommand : IRequest<int>
{
    public int EmpleadoId { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeOnly? HoraEntrada { get; set; }
    public TimeOnly? HoraSalida { get; set; }
    // puntual,tardanza,falta,permiso o feriado
    public string Estado { get; set; } = "Puntual";
    public string? Observacion { get; set; }
}

internal sealed class CreateAsistenciaCommandHandler : IRequestHandler<CreateAsistenciaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAsistenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAsistenciaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Asistencia
        {
            EmpleadoId = request.EmpleadoId,
            Fecha = request.Fecha,
            HoraEntrada = request.HoraEntrada,
            HoraSalida = request.HoraSalida,
            Estado = request.Estado,
            Observacion = request.Observacion
        };

        await _unitOfWork.Repository<Domain.Entities.Asistencia>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
