using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Inventarios.Commands;

public record UpdateInventarioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public string? Ubicacion { get; set; }
}

internal sealed class UpdateInventarioCommandHandler : IRequestHandler<UpdateInventarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateInventarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Inventario>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Cantidad = request.Cantidad;
        item.Ubicacion = request.Ubicacion;
        item.UltimaActualizacion = DateTime.Now;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
