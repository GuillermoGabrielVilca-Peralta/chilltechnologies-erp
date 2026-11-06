using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empleados.Commands;

public record UpdateEmpleadoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int AreaId { get; set; }
    public int CargoId { get; set; }
    public int? JefeId { get; set; }
    public decimal SueldoBasico { get; set; }
    // Activo, Cesado, Suspendido o Vacaciones
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateEmpleadoCommandHandler : IRequestHandler<UpdateEmpleadoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmpleadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEmpleadoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Empleado>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombres = request.Nombres;
        item.Apellidos = request.Apellidos;
        item.Email = request.Email;
        item.Telefono = request.Telefono;
        item.AreaId = request.AreaId;
        item.CargoId = request.CargoId;
        item.JefeId = request.JefeId;
        item.SueldoBasico = request.SueldoBasico;
        item.Estado = request.Estado;
        item.FechaCese = request.Estado == "Cesado" ? DateOnly.FromDateTime(DateTime.Now) : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
