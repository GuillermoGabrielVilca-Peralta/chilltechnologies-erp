using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planillas.Commands;

public record UpdatePlanillaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public decimal SueldoBasico { get; set; }
    public decimal Bonificaciones { get; set; }
    public decimal Descuentos { get; set; }
    // calculada,aprobada, pagada y anulada
    public string Estado { get; set; } = null!;
}

internal sealed class UpdatePlanillaCommandHandler : IRequestHandler<UpdatePlanillaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlanillaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePlanillaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Planilla>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.SueldoBasico = request.SueldoBasico;
        item.Bonificaciones = request.Bonificaciones;
        item.Descuentos = request.Descuentos;
        item.NetoPagar = request.SueldoBasico + request.Bonificaciones - request.Descuentos;
        item.Estado = request.Estado;
        item.FechaPago = request.Estado == "Pagada" ? DateOnly.FromDateTime(DateTime.Now) : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
