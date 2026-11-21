using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Commands;

public record CreateTicketSoporteCommand : IRequest<int>
{
    public string Codigo { get; set; } = null!;
    public int ClienteId { get; set; }
    public int? ProductoSoftwareId { get; set; }
    public int TipoTicketId { get; set; }
    public int? AcuerdoServicioId { get; set; }
    public string Asunto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string Severidad { get; set; } = "Normal";
}

internal sealed class CreateTicketSoporteCommandHandler : IRequestHandler<CreateTicketSoporteCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketSoporteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTicketSoporteCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TicketsSoporte
        {
            Codigo = request.Codigo,
            ClienteId = request.ClienteId,
            ProductoSoftwareId = request.ProductoSoftwareId,
            TipoTicketId = request.TipoTicketId,
            AcuerdoServicioId = request.AcuerdoServicioId,
            Asunto = request.Asunto,
            Descripcion = request.Descripcion,
            Severidad = request.Severidad,
            AsignadoAId = null,
            Estado = "Abierto",
            FechaApertura = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.TicketsSoporte>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
