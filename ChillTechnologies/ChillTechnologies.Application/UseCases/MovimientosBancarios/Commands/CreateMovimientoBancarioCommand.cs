using MediatR;
using ChillTechnologies.Application.Common;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosBancarios.Commands;

public record CreateMovimientoBancarioCommand : IRequest<int>
{
    public int CuentaBancariaId { get; set; }
    public string Tipo { get; set; } = null!;
    public string Concepto { get; set; } = null!;
    public decimal Monto { get; set; }
    public string? Referencia { get; set; }
}

internal sealed class CreateMovimientoBancarioCommandHandler : IRequestHandler<CreateMovimientoBancarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovimientoBancarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateMovimientoBancarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.MovimientosBancario
        {
            CuentaBancariaId = request.CuentaBancariaId,
            Tipo = request.Tipo,
            Concepto = request.Concepto,
            Monto = request.Monto,
            Referencia = request.Referencia,
            Conciliado = false,
            FechaMovimiento = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.MovimientosBancario>().Insert(data);
        
        var cuentas = _unitOfWork.Repository<Domain.Entities.CuentasBancaria>();
        var cuenta = await cuentas.GetByIdAsync(request.CuentaBancariaId);

        cuenta!.Saldo += SignosBancarios.Signo(request.Tipo) * request.Monto;
        cuentas.Update(cuenta);

        await _unitOfWork.Complete();
        return data.Id;
    }
}
