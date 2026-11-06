using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorCobrar.Commands;

public record UpdateCuentaPorCobrarCommand : IRequest<Unit>
{
    public int Id { get; set; }
    //se descuenta del saldo pendiente
    public decimal MontoCobrado { get; set; }
}

internal sealed class UpdateCuentaPorCobrarCommandHandler : IRequestHandler<UpdateCuentaPorCobrarCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCuentaPorCobrarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCuentaPorCobrarCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CuentasPorCobrar>();

        var cuenta = await repo.GetByIdAsync(request.Id);

        cuenta!.Saldo -= request.MontoCobrado;

        cuenta.Estado = cuenta.Saldo <= 0 ? "Cobrada"
            : cuenta.Saldo < cuenta.Monto ? "Parcial"
            : cuenta.FechaVencimiento < DateOnly.FromDateTime(DateTime.Now) ? "Vencida"
            : "Pendiente";

        repo.Update(cuenta);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
