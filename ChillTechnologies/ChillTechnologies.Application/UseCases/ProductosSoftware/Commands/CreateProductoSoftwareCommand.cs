using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ProductosSoftware.Commands;

public record CreateProductoSoftwareCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    //aqui es produc platform o servicio
    public string Tipo { get; set; } = "Producto";
    public DateOnly? FechaLanzamiento { get; set; }
}

internal sealed class CreateProductoSoftwareCommandHandler : IRequestHandler<CreateProductoSoftwareCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductoSoftwareCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProductoSoftwareCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.ProductosSoftware
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Tipo = request.Tipo,
            FechaLanzamiento = request.FechaLanzamiento,
            Estado = "Concepto",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.ProductosSoftware>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
