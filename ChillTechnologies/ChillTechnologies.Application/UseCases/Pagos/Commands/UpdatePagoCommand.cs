using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pagos.Commands;

public record UpdatePagoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int MetodoPagoId { get; set; }
    public decimal MontoSoles { get; set; }
    public string? Referencia { get; set; }
    // Pendiente, donfirmado, rechazado o reembolsado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdatePagoCommandHandler : IRequestHandler<UpdatePagoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePagoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePagoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Pago>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.MetodoPagoId = request.MetodoPagoId;
        item.MontoSoles = request.MontoSoles;
        item.Referencia = request.Referencia;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
