using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Permisos.Commands;

public record UpdatePermisoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Modulo { get; set; } = null!;
}

internal sealed class UpdatePermisoCommandHandler : IRequestHandler<UpdatePermisoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePermisoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePermisoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Permiso>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Codigo = request.Codigo;
        item.Nombre = request.Nombre;
        item.Modulo = request.Modulo;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
