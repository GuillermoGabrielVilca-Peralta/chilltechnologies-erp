using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposVehiculo.Commands;

public record UpdateTipoVehiculoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal FactorEmisionGKm { get; set; }
}

internal sealed class UpdateTipoVehiculoCommandHandler : IRequestHandler<UpdateTipoVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposVehiculo>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.FactorEmisionGKm = request.FactorEmisionGKm;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
