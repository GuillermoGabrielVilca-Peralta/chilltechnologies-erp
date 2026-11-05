using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EmisionesViaje.Commands;

public record CreateEmisionViajeCommand : IRequest<int>
{
    public int ViajeId { get; set; }
    public decimal Co2Kg { get; set; }
    public decimal? CombustibleLitros { get; set; }
    // CO2 no emitido gracias a la buena conduccion frente al promedio
    public decimal? AhorroEstimadoKg { get; set; }
}

internal sealed class CreateEmisionViajeCommandHandler : IRequestHandler<CreateEmisionViajeCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmisionViajeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEmisionViajeCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.EmisionesViaje
        {
            ViajeId = request.ViajeId,
            Co2Kg = request.Co2Kg,
            CombustibleLitros = request.CombustibleLitros,
            AhorroEstimadoKg = request.AhorroEstimadoKg,
            FechaCalculo = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.EmisionesViaje>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
