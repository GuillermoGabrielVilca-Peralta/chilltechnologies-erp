using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasBancarias.Commands;

public record UpdateCuentaBancariaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Banco { get; set; } = null!;
    public string NumeroCuenta { get; set; } = null!;
    public string? Cci { get; set; }
    public string TipoCuenta { get; set; } = null!;
    public string Moneda { get; set; } = null!;
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateCuentaBancariaCommandHandler : IRequestHandler<UpdateCuentaBancariaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCuentaBancariaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCuentaBancariaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CuentasBancaria>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Banco = request.Banco;
        item.NumeroCuenta = request.NumeroCuenta;
        item.Cci = request.Cci;
        item.TipoCuenta = request.TipoCuenta;
        item.Moneda = request.Moneda;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
