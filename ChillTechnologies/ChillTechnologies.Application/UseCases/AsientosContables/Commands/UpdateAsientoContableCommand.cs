using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsientosContables.Commands;

public record UpdateAsientoContableCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public string Glosa { get; set; } = null!;
    public string TipoAsiento { get; set; } = null!;
    // borrador contabilizado anulado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAsientoContableCommandHandler : IRequestHandler<UpdateAsientoContableCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAsientoContableCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAsientoContableCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AsientosContable>();

        var asiento = await repo.GetByIdAsync(request.Id);

        asiento!.Fecha = request.Fecha;
        asiento.Glosa = request.Glosa;
        asiento.TipoAsiento = request.TipoAsiento;
        asiento.Estado = request.Estado;

        // Los totales no los manda el cliente
        var lineas = await _unitOfWork.Repository<Domain.Entities.DetalleAsiento>()
            .FindAsync(d => d.AsientoId == request.Id);

        asiento.TotalDebe = lineas.Sum(d => d.Debe);
        asiento.TotalHaber = lineas.Sum(d => d.Haber);

        repo.Update(asiento);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
