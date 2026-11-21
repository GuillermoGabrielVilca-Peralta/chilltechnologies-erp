using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Commands;

public record CreateRegistroHoraCommand : IRequest<int>
{
    public int EmpleadoId { get; set; }
    public int ProyectoId { get; set; }
    public int? TareaId { get; set; }
    public DateOnly Fecha { get; set; }
    public decimal Horas { get; set; }
    public string? Descripcion { get; set; }
    public bool Facturable { get; set; } = true;
}

internal sealed class CreateRegistroHoraCommandHandler : IRequestHandler<CreateRegistroHoraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegistroHoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRegistroHoraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.RegistrosHora
        {
            EmpleadoId = request.EmpleadoId,
            ProyectoId = request.ProyectoId,
            TareaId = request.TareaId,
            Fecha = request.Fecha,
            Horas = request.Horas,
            Descripcion = request.Descripcion,
            Facturable = request.Facturable,
            Aprobado = false,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.RegistrosHora>().Insert(data);

        if (request.TareaId != null)
        {
            var tareas = _unitOfWork.Repository<Domain.Entities.Tarea>();
            var tarea = await tareas.GetByIdAsync(request.TareaId);

            tarea!.HorasReales += request.Horas;
            tareas.Update(tarea);
        }

        await _unitOfWork.Complete();
        return data.Id;
    }
}
