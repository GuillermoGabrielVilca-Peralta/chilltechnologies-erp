using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasBancarias.Commands;

public record CreateCuentaBancariaCommand : IRequest<int>
{
    public string Banco { get; set; } = null!;
    public string NumeroCuenta { get; set; } = null!;
    public string? Cci { get; set; }
    public string TipoCuenta { get; set; } = "Corriente";
    public string Moneda { get; set; } = "PEN";
    public decimal Saldo { get; set; }
}

internal sealed class CreateCuentaBancariaCommandHandler : IRequestHandler<CreateCuentaBancariaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCuentaBancariaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCuentaBancariaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.CuentasBancaria
        {
            Banco = request.Banco,
            NumeroCuenta = request.NumeroCuenta,
            Cci = request.Cci,
            TipoCuenta = request.TipoCuenta,
            Moneda = request.Moneda,
            Saldo = request.Saldo,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.CuentasBancaria>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
