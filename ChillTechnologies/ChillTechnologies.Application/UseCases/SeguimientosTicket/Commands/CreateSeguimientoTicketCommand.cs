using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SeguimientosTicket.Commands;

public record CreateSeguimientoTicketCommand : IRequest<int>
{
    public int TicketId { get; set; }
    public int? EmpleadoId { get; set; }
    public string Comentario { get; set; } = null!;
    public bool VisibleCliente { get; set; } = true;
    public decimal HorasInvertidas { get; set; }
}

internal sealed class CreateSeguimientoTicketCommandHandler : IRequestHandler<CreateSeguimientoTicketCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSeguimientoTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSeguimientoTicketCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.SeguimientosTicket
        {
            TicketId = request.TicketId,
            EmpleadoId = request.EmpleadoId,
            Comentario = request.Comentario,
            VisibleCliente = request.VisibleCliente,
            HorasInvertidas = request.HorasInvertidas,
            FechaSeguimiento = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.SeguimientosTicket>().Insert(data);

        if (request.VisibleCliente)
        {
            var tickets = _unitOfWork.Repository<Domain.Entities.TicketsSoporte>();
            var ticket = await tickets.GetByIdAsync(request.TicketId);

            if (ticket!.FechaPrimeraRespuesta == null)
            {
                ticket.FechaPrimeraRespuesta = data.FechaSeguimiento;
                tickets.Update(ticket);
            }
        }

        await _unitOfWork.Complete();
        return data.Id;
    }
}
