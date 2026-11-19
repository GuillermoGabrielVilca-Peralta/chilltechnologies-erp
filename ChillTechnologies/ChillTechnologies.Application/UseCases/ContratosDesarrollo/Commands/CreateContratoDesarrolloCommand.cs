using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ContratosDesarrollo.Commands;

public record CreateContratoDesarrolloCommand : IRequest<int>
{
    public string Numero { get; set; } = null!;
    public int ClienteId { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public decimal MontoTotal { get; set; }
    public string Moneda { get; set; } = "PEN";
    public string CondicionPago { get; set; } = "Contado";
}

internal sealed class CreateContratoDesarrolloCommandHandler : IRequestHandler<CreateContratoDesarrolloCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContratoDesarrolloCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateContratoDesarrolloCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.ContratosDesarrollo
        {
            Numero = request.Numero,
            ClienteId = request.ClienteId,
            Descripcion = request.Descripcion,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            MontoTotal = request.MontoTotal,
            Moneda = request.Moneda,
            CondicionPago = request.CondicionPago,
            Estado = "Borrador",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.ContratosDesarrollo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
