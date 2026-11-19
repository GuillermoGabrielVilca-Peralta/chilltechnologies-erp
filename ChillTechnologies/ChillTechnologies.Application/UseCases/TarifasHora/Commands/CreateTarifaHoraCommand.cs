using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TarifasHora.Commands;

public record CreateTarifaHoraCommand : IRequest<int>
{
    public int CargoId { get; set; }
    public int? ProyectoId { get; set; }
    public decimal Tarifa { get; set; }
    public string Moneda { get; set; } = "PEN";
    public DateOnly VigenteDesde { get; set; }
}

internal sealed class CreateTarifaHoraCommandHandler : IRequestHandler<CreateTarifaHoraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTarifaHoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTarifaHoraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TarifasHora
        {
            CargoId = request.CargoId,
            ProyectoId = request.ProyectoId,
            Tarifa = request.Tarifa,
            Moneda = request.Moneda,
            VigenteDesde = request.VigenteDesde
        };

        await _unitOfWork.Repository<Domain.Entities.TarifasHora>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
