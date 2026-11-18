using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosCaja.Commands;

public record CreateMovimientoCajaCommand : IRequest<int>
{
    public int CajaId { get; set; }
    public string Tipo { get; set; } = null!;
    public string Concepto { get; set; } = null!;
    public decimal Monto { get; set; }
    public string? DocumentoReferencia { get; set; }
    public int? EmpleadoId { get; set; }
}

internal sealed class CreateMovimientoCajaCommandHandler : IRequestHandler<CreateMovimientoCajaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovimientoCajaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateMovimientoCajaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.MovimientosCaja
        {
            CajaId = request.CajaId,
            Tipo = request.Tipo,
            Concepto = request.Concepto,
            Monto = request.Monto,
            DocumentoReferencia = request.DocumentoReferencia,
            EmpleadoId = request.EmpleadoId,
            FechaMovimiento = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.MovimientosCaja>().Insert(data);
        
        var cajas = _unitOfWork.Repository<Domain.Entities.Caja>();
        var caja = await cajas.GetByIdAsync(request.CajaId);

        caja!.SaldoActual += request.Tipo == "Ingreso" ? request.Monto : -request.Monto;
        cajas.Update(caja);

        await _unitOfWork.Complete();
        return data.Id;
    }
}
