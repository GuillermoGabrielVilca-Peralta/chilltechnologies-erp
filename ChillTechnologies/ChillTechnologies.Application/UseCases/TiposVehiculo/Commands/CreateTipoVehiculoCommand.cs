using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposVehiculo.Commands;

public record CreateTipoVehiculoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public decimal FactorEmisionGKm { get; set; }
}

internal sealed class CreateTipoVehiculoCommandHandler : IRequestHandler<CreateTipoVehiculoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposVehiculo
        {
            Nombre = request.Nombre,
            FactorEmisionGKm = request.FactorEmisionGKm,
        };

        await _unitOfWork.Repository<Domain.Entities.TiposVehiculo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
