using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposProyecto.Commands;

public record UpdateTipoProyectoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string Modalidad { get; set; } = null!;
}

internal sealed class UpdateTipoProyectoCommandHandler : IRequestHandler<UpdateTipoProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposProyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Modalidad = request.Modalidad;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
