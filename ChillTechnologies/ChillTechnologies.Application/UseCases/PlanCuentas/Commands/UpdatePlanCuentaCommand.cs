using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PlanCuentas.Commands;

public record UpdatePlanCuentaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string TipoCuenta { get; set; } = null!;
    public int? CuentaPadreId { get; set; }
    public short Nivel { get; set; }
    public bool AceptaMovimiento { get; set; }
    // Activa o Inactiva
    public string Estado { get; set; } = null!;
}

internal sealed class UpdatePlanCuentaCommandHandler : IRequestHandler<UpdatePlanCuentaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlanCuentaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePlanCuentaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.PlanCuenta>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Codigo = request.Codigo;
        item.Nombre = request.Nombre;
        item.TipoCuenta = request.TipoCuenta;
        item.CuentaPadreId = request.CuentaPadreId;
        item.Nivel = request.Nivel;
        item.AceptaMovimiento = request.AceptaMovimiento;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
