using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Productos.Commands;

public record CreateProductoCommand : IRequest<int>
{
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int CategoriaProductoId { get; set; }
    public string UnidadMedida { get; set; } = "Unidad";
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public int StockMinimo { get; set; }
}

internal sealed class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Producto
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            CategoriaProductoId = request.CategoriaProductoId,
            UnidadMedida = request.UnidadMedida,
            PrecioCompra = request.PrecioCompra,
            PrecioVenta = request.PrecioVenta,
            StockMinimo = request.StockMinimo,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Producto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
