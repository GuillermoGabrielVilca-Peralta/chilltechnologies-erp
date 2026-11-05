using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EmisionesViaje.Commands;

public record UpdateEmisionViajeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public decimal Co2Kg { get; set; }
    public decimal? CombustibleLitros { get; set; }
    public decimal? AhorroEstimadoKg { get; set; }
}

internal sealed class UpdateEmisionViajeCommandHandler : IRequestHandler<UpdateEmisionViajeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmisionViajeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEmisionViajeCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.EmisionesViaje>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Co2Kg = request.Co2Kg;
        item.CombustibleLitros = request.CombustibleLitros;
        item.AhorroEstimadoKg = request.AhorroEstimadoKg;
        item.FechaCalculo = DateTime.Now;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
