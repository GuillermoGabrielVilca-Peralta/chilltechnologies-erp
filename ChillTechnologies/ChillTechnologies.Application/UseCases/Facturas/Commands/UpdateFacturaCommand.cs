using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Facturas.Commands;

public record UpdateFacturaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public decimal Subtotal { get; set; }
    // emitada pagada anulada
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateFacturaCommandHandler : IRequestHandler<UpdateFacturaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFacturaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateFacturaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Factura>();

        var factura = await repo.GetByIdAsync(request.Id);

        factura!.Subtotal = request.Subtotal;
        factura.Igv = Math.Round(request.Subtotal * 0.18m, 2);
        factura.Total = request.Subtotal + factura.Igv;
        factura.Estado = request.Estado;

        repo.Update(factura);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
