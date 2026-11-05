using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pagos.Commands;

public record CreatePagoCommand : IRequest<int>
{
    public int SuscripcionId { get; set; }
    public int MetodoPagoId { get; set; }
    public decimal MontoSoles { get; set; }
    public string? Referencia { get; set; }
}

internal sealed class CreatePagoCommandHandler : IRequestHandler<CreatePagoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePagoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePagoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Pago
        {
            SuscripcionId = request.SuscripcionId,
            MetodoPagoId = request.MetodoPagoId,
            MontoSoles = request.MontoSoles,
            Referencia = request.Referencia,
            Estado = "Pendiente",
            FechaPago = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Pago>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
