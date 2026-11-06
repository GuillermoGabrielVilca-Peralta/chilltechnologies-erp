using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleAsiento.Commands;

public record UpdateDetalleAsientoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int CuentaId { get; set; }
    public decimal Debe { get; set; }
    public decimal Haber { get; set; }
    public string? Glosa { get; set; }
}

internal sealed class UpdateDetalleAsientoCommandHandler : IRequestHandler<UpdateDetalleAsientoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDetalleAsientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDetalleAsientoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DetalleAsiento>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.CuentaId = request.CuentaId;
        item.Debe = request.Debe;
        item.Haber = request.Haber;
        item.Glosa = request.Glosa;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
