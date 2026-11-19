using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ContratosDesarrollo.Commands;

public record UpdateContratoDesarrolloCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateOnly? FechaFin { get; set; }
    public decimal MontoTotal { get; set; }
    public string CondicionPago { get; set; } = null!;
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateContratoDesarrolloCommandHandler : IRequestHandler<UpdateContratoDesarrolloCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContratoDesarrolloCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateContratoDesarrolloCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ContratosDesarrollo>();

        var item = await repo.GetByIdAsync(request.Id);

        // El numero, el cliente y la moneda quedan fijos al firmar
        item!.Descripcion = request.Descripcion;
        item.MontoTotal = request.MontoTotal;
        item.CondicionPago = request.CondicionPago;
        item.Estado = request.Estado;
        // Un contrato que termina sella su fecha de fin
        item.FechaFin = request.Estado is "Finalizado" or "Resuelto"
            ? request.FechaFin ?? DateOnly.FromDateTime(DateTime.Now)
            : request.FechaFin;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
