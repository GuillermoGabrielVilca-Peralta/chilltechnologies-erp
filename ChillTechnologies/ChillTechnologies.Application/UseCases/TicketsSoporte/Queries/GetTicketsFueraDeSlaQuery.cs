using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Queries;

public record GetTicketsFueraDeSlaQuery : IRequest<IEnumerable<Domain.Entities.TicketsSoporte>>;

internal sealed class GetTicketsFueraDeSlaQueryHandler : IRequestHandler<GetTicketsFueraDeSlaQuery, IEnumerable<Domain.Entities.TicketsSoporte>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketsFueraDeSlaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TicketsSoporte>> Handle(GetTicketsFueraDeSlaQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _unitOfWork.Repository<Domain.Entities.TicketsSoporte>()
            .FindAsync(t => t.AcuerdoServicioId != null);

        var acuerdos = (await _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>()
            .GetAllAsync()).ToDictionary(a => a.Id);

        var incumplidos = new List<Domain.Entities.TicketsSoporte>();

        foreach (var ticket in tickets)
        {
            if (!acuerdos.TryGetValue(ticket.AcuerdoServicioId!.Value, out var sla))
                continue;

            var comprometidas = ticket.Severidad switch
            {
                "Critica" => sla.HorasRespuestaCritica,
                "Alta" => sla.HorasRespuestaAlta,
                _ => sla.HorasRespuestaNormal
            };

            var corte = ticket.FechaPrimeraRespuesta ?? DateTime.Now;

            if ((corte - ticket.FechaApertura).TotalHours > (double)comprometidas)
                incumplidos.Add(ticket);
        }

        return incumplidos;
    }
}
