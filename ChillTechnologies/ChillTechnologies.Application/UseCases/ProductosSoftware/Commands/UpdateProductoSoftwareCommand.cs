using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ProductosSoftware.Commands;

public record UpdateProductoSoftwareCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string Tipo { get; set; } = null!;
    public DateOnly? FechaLanzamiento { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateProductoSoftwareCommandHandler : IRequestHandler<UpdateProductoSoftwareCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductoSoftwareCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProductoSoftwareCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ProductosSoftware>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Tipo = request.Tipo;
        item.Estado = request.Estado;
        item.FechaLanzamiento = request.Estado == "Activo"
            ? request.FechaLanzamiento ?? DateOnly.FromDateTime(DateTime.Now)
            : request.FechaLanzamiento;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
