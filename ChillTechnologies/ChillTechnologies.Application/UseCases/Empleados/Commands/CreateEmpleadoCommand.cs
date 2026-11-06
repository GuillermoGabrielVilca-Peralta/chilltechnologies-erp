using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empleados.Commands;

public record CreateEmpleadoCommand : IRequest<int>
{
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Dni { get; set; } = null!;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int AreaId { get; set; }
    public int CargoId { get; set; }
    // Jefe directo, para el organigrama
    public int? JefeId { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public decimal SueldoBasico { get; set; }
}

internal sealed class CreateEmpleadoCommandHandler : IRequestHandler<CreateEmpleadoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmpleadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEmpleadoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Empleado
        {
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            Dni = request.Dni,
            Email = request.Email,
            Telefono = request.Telefono,
            AreaId = request.AreaId,
            CargoId = request.CargoId,
            JefeId = request.JefeId,
            FechaIngreso = request.FechaIngreso,
            SueldoBasico = request.SueldoBasico,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Empleado>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
