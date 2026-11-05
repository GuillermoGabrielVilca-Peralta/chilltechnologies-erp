using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ModelosIa.Commands;

public record UpdateModeloIaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string Arquitectura { get; set; } = null!;
    public decimal? PrecisionPromedio { get; set; }
    public DateOnly? FechaEntrenamiento { get; set; }
    public bool Activo { get; set; }
}

internal sealed class UpdateModeloIaCommandHandler : IRequestHandler<UpdateModeloIaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModeloIaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateModeloIaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ModelosIum>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Version = request.Version;
        item.Arquitectura = request.Arquitectura;
        item.PrecisionPromedio = request.PrecisionPromedio;
        item.FechaEntrenamiento = request.FechaEntrenamiento;
        item.Activo = request.Activo;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
