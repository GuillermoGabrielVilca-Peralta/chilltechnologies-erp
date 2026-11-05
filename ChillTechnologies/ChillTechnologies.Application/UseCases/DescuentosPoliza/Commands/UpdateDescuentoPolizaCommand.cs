using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DescuentosPoliza.Commands;

public record UpdateDescuentoPolizaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public decimal PuntajePromedio { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public decimal? MontoDescontado { get; set; }
    // Calculado,aplicado o rechazado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateDescuentoPolizaCommandHandler : IRequestHandler<UpdateDescuentoPolizaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDescuentoPolizaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDescuentoPolizaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DescuentosPoliza>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.PuntajePromedio = request.PuntajePromedio;
        item.PorcentajeDescuento = request.PorcentajeDescuento;
        item.MontoDescontado = request.MontoDescontado;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
