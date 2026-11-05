using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DescuentosPoliza.Commands;

public record CreateDescuentoPolizaCommand : IRequest<int>
{
    public int PolizaId { get; set; }
    public DateOnly PeriodoInicio { get; set; }
    public DateOnly PeriodoFin { get; set; }
    // Promedio de conduccion del periodo, 0-100
    public decimal PuntajePromedio { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public decimal? MontoDescontado { get; set; }
}

internal sealed class CreateDescuentoPolizaCommandHandler : IRequestHandler<CreateDescuentoPolizaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDescuentoPolizaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDescuentoPolizaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DescuentosPoliza
        {
            PolizaId = request.PolizaId,
            PeriodoInicio = request.PeriodoInicio,
            PeriodoFin = request.PeriodoFin,
            PuntajePromedio = request.PuntajePromedio,
            PorcentajeDescuento = request.PorcentajeDescuento,
            MontoDescontado = request.MontoDescontado,
            Estado = "Calculado",
            FechaCalculo = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.DescuentosPoliza>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
