using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorPagar.Commands;

public record UpdateCuentaPorPagarCommand : IRequest<Unit>
{
    public int Id { get; set; }
    // Monto que se abona ahoray se descuenta delsaldopendiente
    public decimal MontoAbonado { get; set; }
}

internal sealed class UpdateCuentaPorPagarCommandHandler : IRequestHandler<UpdateCuentaPorPagarCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCuentaPorPagarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCuentaPorPagarCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CuentasPorPagar>();

        var cuenta = await repo.GetByIdAsync(request.Id);

        cuenta!.Saldo -= request.MontoAbonado;

        // El estado se deduce del saldo cliente no lo hace
        cuenta.Estado = cuenta.Saldo <= 0 ? "Pagada"
            : cuenta.Saldo < cuenta.Monto ? "Parcial"
            : cuenta.FechaVencimiento < DateOnly.FromDateTime(DateTime.Now) ? "Vencida"
            : "Pendiente";

        repo.Update(cuenta);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
