using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proveedores.Commands;

public record UpdateProveedorCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string? ContactoNombre { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public string CondicionPago { get; set; } = null!;
    // Activo, Inactivo o Bloqueado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateProveedorCommandHandler : IRequestHandler<UpdateProveedorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProveedorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Proveedore>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.RazonSocial = request.RazonSocial;
        item.Ruc = request.Ruc;
        item.ContactoNombre = request.ContactoNombre;
        item.Telefono = request.Telefono;
        item.Email = request.Email;
        item.Direccion = request.Direccion;
        item.CondicionPago = request.CondicionPago;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
