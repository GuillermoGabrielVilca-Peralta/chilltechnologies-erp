using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposTicket.Commands;

public record CreateTipoTicketCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool Facturable { get; set; }
}

internal sealed class CreateTipoTicketCommandHandler : IRequestHandler<CreateTipoTicketCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoTicketCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposTicket
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Facturable = request.Facturable
        };

        await _unitOfWork.Repository<Domain.Entities.TiposTicket>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
