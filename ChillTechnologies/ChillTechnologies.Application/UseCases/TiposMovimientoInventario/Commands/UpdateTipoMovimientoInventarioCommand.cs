using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Commands;

public record UpdateTipoMovimientoInventarioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public short Signo { get; set; }
}

internal sealed class UpdateTipoMovimientoInventarioCommandHandler : IRequestHandler<UpdateTipoMovimientoInventarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoMovimientoInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoMovimientoInventarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposMovimientoInventario>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Signo = request.Signo;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
