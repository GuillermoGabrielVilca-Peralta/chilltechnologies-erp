using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Clientes.Commands;

public record UpdateClienteCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string TipoDocumento { get; set; } = null!;
    public string NumeroDocumento { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string CondicionPago { get; set; } = null!;
    public decimal LineaCredito { get; set; }
    public int? VendedorId { get; set; }
    //activo inactivo bloqueado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClienteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Cliente>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.RazonSocial = request.RazonSocial;
        item.TipoDocumento = request.TipoDocumento;
        item.NumeroDocumento = request.NumeroDocumento;
        item.Direccion = request.Direccion;
        item.Telefono = request.Telefono;
        item.Email = request.Email;
        item.CondicionPago = request.CondicionPago;
        item.LineaCredito = request.LineaCredito;
        item.VendedorId = request.VendedorId;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
