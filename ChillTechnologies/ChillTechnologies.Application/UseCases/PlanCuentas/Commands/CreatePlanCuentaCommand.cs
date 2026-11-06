using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PlanCuentas.Commands;

public record CreatePlanCuentaCommand : IRequest<int>
{
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    //activo pasivo patrimonio ingreso gasto costo
    public string TipoCuenta { get; set; } = null!;
    // null = cuenta raiz del arbol contable
    public int? CuentaPadreId { get; set; }
    public short Nivel { get; set; }
    // Solo las cuentas de ultimo nivel reciben asientos
    public bool AceptaMovimiento { get; set; }
}

internal sealed class CreatePlanCuentaCommandHandler : IRequestHandler<CreatePlanCuentaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanCuentaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePlanCuentaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.PlanCuenta
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            TipoCuenta = request.TipoCuenta,
            CuentaPadreId = request.CuentaPadreId,
            Nivel = request.Nivel,
            AceptaMovimiento = request.AceptaMovimiento,
            Estado = "Activa"
        };

        await _unitOfWork.Repository<Domain.Entities.PlanCuenta>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
