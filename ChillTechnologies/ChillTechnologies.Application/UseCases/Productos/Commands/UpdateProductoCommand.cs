using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Productos.Commands;

public record UpdateProductoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int CategoriaProductoId { get; set; }
    public string UnidadMedida { get; set; } = null!;
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public int StockMinimo { get; set; }
    //activo o descontinuado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Producto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Codigo = request.Codigo;
        item.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.CategoriaProductoId = request.CategoriaProductoId;
        item.UnidadMedida = request.UnidadMedida;
        item.PrecioCompra = request.PrecioCompra;
        item.PrecioVenta = request.PrecioVenta;
        item.StockMinimo = request.StockMinimo;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
