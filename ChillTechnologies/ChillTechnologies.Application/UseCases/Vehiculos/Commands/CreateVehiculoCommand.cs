using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Vehiculos.Commands;

public record CreateVehiculoCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    public string Placa { get; set; } = null!;
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int? Anio { get; set; }
    public string? Color { get; set; }
    public int TipoVehiculoId { get; set; }
}

internal sealed class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Vehiculo
        {
            UsuarioId = request.UsuarioId,
            Placa = request.Placa,
            Marca = request.Marca,
            Modelo = request.Modelo,
            Anio = request.Anio,
            Color = request.Color,
            TipoVehiculoId = request.TipoVehiculoId,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Vehiculo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
