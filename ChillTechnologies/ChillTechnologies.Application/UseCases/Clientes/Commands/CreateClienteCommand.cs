using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Clientes.Commands;

public record CreateClienteCommand : IRequest<int>
{
    public string RazonSocial { get; set; } = null!;
    //ruc,dni, CE
    public string TipoDocumento { get; set; } = "RUC";
    public string NumeroDocumento { get; set; } = null!;
    //empresa de flota B2B o conductor B2C,ambos no
    public int? EmpresaId { get; set; }
    public int? UsuarioId { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string CondicionPago { get; set; } = "Contado";
    public decimal LineaCredito { get; set; }
    public int? VendedorId { get; set; }
}

internal sealed class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateClienteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Cliente
        {
            RazonSocial = request.RazonSocial,
            TipoDocumento = request.TipoDocumento,
            NumeroDocumento = request.NumeroDocumento,
            EmpresaId = request.EmpresaId,
            UsuarioId = request.UsuarioId,
            Direccion = request.Direccion,
            Telefono = request.Telefono,
            Email = request.Email,
            CondicionPago = request.CondicionPago,
            LineaCredito = request.LineaCredito,
            VendedorId = request.VendedorId,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Cliente>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
