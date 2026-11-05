using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empresas.Commands;

public record UpdateEmpresaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Distrito { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? ContactoNombre { get; set; }
    // Activa, Inactiva o Suspendida
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmpresaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Empresa>();

        var empresa = await repo.GetByIdAsync(request.Id);

        empresa!.RazonSocial = request.RazonSocial;
        empresa.Ruc = request.Ruc;
        empresa.Direccion = request.Direccion;
        empresa.Distrito = request.Distrito;
        empresa.Telefono = request.Telefono;
        empresa.Email = request.Email;
        empresa.ContactoNombre = request.ContactoNombre;
        empresa.Estado = request.Estado;

        repo.Update(empresa);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
