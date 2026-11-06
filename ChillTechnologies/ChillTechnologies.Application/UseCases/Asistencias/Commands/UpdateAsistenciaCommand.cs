using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Asistencias.Commands;

public record UpdateAsistenciaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public TimeOnly? HoraEntrada { get; set; }
    public TimeOnly? HoraSalida { get; set; }
    public string Estado { get; set; } = null!;
    public string? Observacion { get; set; }
}

internal sealed class UpdateAsistenciaCommandHandler : IRequestHandler<UpdateAsistenciaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAsistenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAsistenciaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Asistencia>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.HoraEntrada = request.HoraEntrada;
        item.HoraSalida = request.HoraSalida;
        item.Estado = request.Estado;
        item.Observacion = request.Observacion;
        // Si hay entrada y salida, las horas se calculan solas
        item.HorasTrabajadas = request.HoraEntrada.HasValue && request.HoraSalida.HasValue
            ? (decimal)(request.HoraSalida.Value - request.HoraEntrada.Value).TotalHours
            : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
