using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosInventario.Commands;

public record CreateMovimientoInventarioCommand : IRequest<int>
{
    public int ProductoId { get; set; }
    public int TipoMovimientoId { get; set; }
    // destino y origen=entrada-salida
    public int? AlmacenOrigenId { get; set; }
    public int? AlmacenDestinoId { get; set; }
    public int Cantidad { get; set; }
    public decimal? CostoUnitario { get; set; }
    public string? DocumentoReferencia { get; set; }
    public int? EmpleadoId { get; set; }
    public string? Observacion { get; set; }
}

internal sealed class CreateMovimientoInventarioCommandHandler : IRequestHandler<CreateMovimientoInventarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovimientoInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateMovimientoInventarioCommand request, CancellationToken cancellationToken)
    {
        var tipo = await _unitOfWork.Repository<Domain.Entities.TiposMovimientoInventario>()
            .GetByIdAsync(request.TipoMovimientoId);

        var data = new Domain.Entities.MovimientosInventario
        {
            ProductoId = request.ProductoId,
            TipoMovimientoId = request.TipoMovimientoId,
            AlmacenOrigenId = request.AlmacenOrigenId,
            AlmacenDestinoId = request.AlmacenDestinoId,
            Cantidad = request.Cantidad,
            CostoUnitario = request.CostoUnitario,
            DocumentoReferencia = request.DocumentoReferencia,
            EmpleadoId = request.EmpleadoId,
            Observacion = request.Observacion,
            FechaMovimiento = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.MovimientosInventario>().Insert(data);

        // El signo del tipo decide como se mueve el stock
        // 1 = suma en el almacen destino
        // -1 = resta en el almacen origen
        // 0= resta en origen y suma en destino
        if (tipo!.Signo >= 0 && request.AlmacenDestinoId.HasValue)
            await AjustarStock(request.ProductoId, request.AlmacenDestinoId.Value, request.Cantidad);

        if (tipo.Signo <= 0 && request.AlmacenOrigenId.HasValue)
            await AjustarStock(request.ProductoId, request.AlmacenOrigenId.Value, -request.Cantidad);

        //el movimiento y el ajuste de stock viajan en la misma transaccion
        await _unitOfWork.Complete();
        return data.Id;
    }

    private async Task AjustarStock(int productoId, int almacenId, int delta)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Inventario>();

        var fila = await repo.FirstOrDefaultAsync(i => i.ProductoId == productoId && i.AlmacenId == almacenId);

        if (fila is null)
        {
            await repo.Insert(new Domain.Entities.Inventario
            {
                ProductoId = productoId,
                AlmacenId = almacenId,
                Cantidad = delta,
                UltimaActualizacion = DateTime.Now
            });
            return;
        }

        fila.Cantidad += delta;
        fila.UltimaActualizacion = DateTime.Now;
        repo.Update(fila);
    }
}
