using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aliados.Commands;

public record UpdateAliadoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Ruc { get; set; }
    public int CategoriaId { get; set; }
    public string? Direccion { get; set; }
    public string? Distrito { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Logo { get; set; }
    public string? Descripcion { get; set; }
    public decimal ComisionPorcentaje { get; set; }
    // Activo, Inactivo o Suspendido
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAliadoCommandHandler : IRequestHandler<UpdateAliadoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAliadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAliadoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Aliado>();

        var aliado = await repo.GetByIdAsync(request.Id);

        aliado!.Nombre = request.Nombre;
        aliado.Ruc = request.Ruc;
        aliado.CategoriaId = request.CategoriaId;
        aliado.Direccion = request.Direccion;
        aliado.Distrito = request.Distrito;
        aliado.Telefono = request.Telefono;
        aliado.Email = request.Email;
        aliado.Logo = request.Logo;
        aliado.Descripcion = request.Descripcion;
        aliado.ComisionPorcentaje = request.ComisionPorcentaje;
        aliado.Estado = request.Estado;

        repo.Update(aliado);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
