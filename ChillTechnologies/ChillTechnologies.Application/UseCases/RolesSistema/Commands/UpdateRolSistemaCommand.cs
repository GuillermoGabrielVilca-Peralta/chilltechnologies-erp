using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolesSistema.Commands;

public record UpdateRolSistemaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    // Para activo inactivo
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateRolSistemaCommandHandler : IRequestHandler<UpdateRolSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRolSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateRolSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.RolesSistema>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
