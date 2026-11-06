using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proveedores.Commands;

public record CreateProveedorCommand : IRequest<int>
{
    public string RazonSocial { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string? ContactoNombre { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    // Contado,credito 15,credito 30 credito 60 oCredito 90
    public string CondicionPago { get; set; } = "Contado";
}

internal sealed class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProveedorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Proveedore
        {
            RazonSocial = request.RazonSocial,
            Ruc = request.Ruc,
            ContactoNombre = request.ContactoNombre,
            Telefono = request.Telefono,
            Email = request.Email,
            Direccion = request.Direccion,
            CondicionPago = request.CondicionPago,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Proveedore>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
