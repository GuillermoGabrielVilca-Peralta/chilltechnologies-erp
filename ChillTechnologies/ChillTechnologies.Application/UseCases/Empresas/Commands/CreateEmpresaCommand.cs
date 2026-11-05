using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empresas.Commands;

public record CreateEmpresaCommand : IRequest<int>
{
    public string RazonSocial { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Distrito { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? ContactoNombre { get; set; }
}

internal sealed class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmpresaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Empresa
        {
            RazonSocial = request.RazonSocial,
            Ruc = request.Ruc,
            Direccion = request.Direccion,
            Distrito = request.Distrito,
            Telefono = request.Telefono,
            Email = request.Email,
            ContactoNombre = request.ContactoNombre,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Empresa>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
