using MediatR;
using ChillTechnologies.Application.ReglasNegocio;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorCobrar.Commands;

public record CreateCuentaPorCobrarCommand : IRequest<int>
{
    public int ClienteId { get; set; }
    public int? FacturaId { get; set; }
    public DateOnly FechaEmision { get; set; }
    public decimal Monto { get; set; }
}

internal sealed class CreateCuentaPorCobrarCommandHandler : IRequestHandler<CreateCuentaPorCobrarCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCuentaPorCobrarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCuentaPorCobrarCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _unitOfWork.Repository<Domain.Entities.Cliente>()
            .GetByIdAsync(request.ClienteId);

        var data = new Domain.Entities.CuentasPorCobrar
        {
            ClienteId = request.ClienteId,
            FacturaId = request.FacturaId,
            FechaEmision = request.FechaEmision,
            FechaVencimiento = request.FechaEmision.AddDays(CondicionesPago.Dias(cliente!.CondicionPago)),
            Monto = request.Monto,
            Saldo = request.Monto,
            Estado = "Pendiente",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.CuentasPorCobrar>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
