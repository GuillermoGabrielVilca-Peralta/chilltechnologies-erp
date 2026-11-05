using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Vehiculos.Commands;

public record UpdateVehiculoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public int? FlotaId { get; set; }
    public string Placa { get; set; } = null!;
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int? Anio { get; set; }
    public string? Color { get; set; }
    public int TipoVehiculoId { get; set; }
    // Activo, Inactivo o Vendido
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateVehiculoCommandHandler : IRequestHandler<UpdateVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Vehiculo>();

        var vehiculo = await repo.GetByIdAsync(request.Id);

        vehiculo!.UsuarioId = request.UsuarioId;
        vehiculo.FlotaId = request.FlotaId;
        vehiculo.Placa = request.Placa;
        vehiculo.Marca = request.Marca;
        vehiculo.Modelo = request.Modelo;
        vehiculo.Anio = request.Anio;
        vehiculo.Color = request.Color;
        vehiculo.TipoVehiculoId = request.TipoVehiculoId;
        vehiculo.Estado = request.Estado;

        repo.Update(vehiculo);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
