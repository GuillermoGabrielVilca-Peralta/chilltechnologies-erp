using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Repositorios.Commands;

public record UpdateRepositorioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int? ProductoSoftwareId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Proveedor { get; set; } = null!;
    public string RamaPrincipal { get; set; } = null!;
    public string Visibilidad { get; set; } = null!;
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateRepositorioCommandHandler : IRequestHandler<UpdateRepositorioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRepositorioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateRepositorioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Repositorio>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.ProductoSoftwareId = request.ProductoSoftwareId;
        item.Nombre = request.Nombre;
        item.Url = request.Url;
        item.Proveedor = request.Proveedor;
        item.RamaPrincipal = request.RamaPrincipal;
        item.Visibilidad = request.Visibilidad;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
