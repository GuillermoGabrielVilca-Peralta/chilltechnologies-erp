using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Defectos.Commands;

public record UpdateDefectoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? PasosReproduccion { get; set; }
    public string Severidad { get; set; } = null!;
    public int? AsignadoAId { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateDefectoCommandHandler : IRequestHandler<UpdateDefectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDefectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDefectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Defecto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Titulo = request.Titulo;
        item.Descripcion = request.Descripcion;
        item.PasosReproduccion = request.PasosReproduccion;
        item.Severidad = request.Severidad;
        item.AsignadoAId = request.AsignadoAId;
        item.Estado = request.Estado;
        item.FechaCierre = request.Estado is "Cerrado" or "Descartado"
            ? item.FechaCierre ?? DateTime.Now
            : null;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
