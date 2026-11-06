using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Inventarios.Commands;

public record CreateInventarioCommand : IRequest<int>
{
    public int ProductoId { get; set; }
    public int AlmacenId { get; set; }
    public int Cantidad { get; set; }
    public string? Ubicacion { get; set; }
}

internal sealed class CreateInventarioCommandHandler : IRequestHandler<CreateInventarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateInventarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Inventario
        {
            ProductoId = request.ProductoId,
            AlmacenId = request.AlmacenId,
            Cantidad = request.Cantidad,
            Ubicacion = request.Ubicacion,
            UltimaActualizacion = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Inventario>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
