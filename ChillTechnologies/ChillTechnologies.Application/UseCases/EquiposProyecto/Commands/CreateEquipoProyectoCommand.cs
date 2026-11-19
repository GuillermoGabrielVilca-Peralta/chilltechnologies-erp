using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EquiposProyecto.Commands;

public record CreateEquipoProyectoCommand : IRequest<int>
{
    public int ProyectoId { get; set; }
    public int EmpleadoId { get; set; }
    public string Rol { get; set; } = null!;
    public decimal DedicacionPorcentaje { get; set; } = 100;
}

internal sealed class CreateEquipoProyectoCommandHandler : IRequestHandler<CreateEquipoProyectoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEquipoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEquipoProyectoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.EquiposProyecto
        {
            ProyectoId = request.ProyectoId,
            EmpleadoId = request.EmpleadoId,
            Rol = request.Rol,
            DedicacionPorcentaje = request.DedicacionPorcentaje,
            FechaIngreso = DateOnly.FromDateTime(DateTime.Now)
        };

        await _unitOfWork.Repository<Domain.Entities.EquiposProyecto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
