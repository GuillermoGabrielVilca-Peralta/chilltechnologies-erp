using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TarifasHora.Commands;

public record UpdateTarifaHoraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public decimal Tarifa { get; set; }
    public DateOnly VigenteDesde { get; set; }
    public DateOnly? VigenteHasta { get; set; }
}

internal sealed class UpdateTarifaHoraCommandHandler : IRequestHandler<UpdateTarifaHoraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTarifaHoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTarifaHoraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TarifasHora>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Tarifa = request.Tarifa;
        item.VigenteDesde = request.VigenteDesde;
        item.VigenteHasta = request.VigenteHasta;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
