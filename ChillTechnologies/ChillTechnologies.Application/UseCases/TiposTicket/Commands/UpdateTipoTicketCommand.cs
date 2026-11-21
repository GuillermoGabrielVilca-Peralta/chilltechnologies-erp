using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposTicket.Commands;

public record UpdateTipoTicketCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool Facturable { get; set; }
}

internal sealed class UpdateTipoTicketCommandHandler : IRequestHandler<UpdateTipoTicketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoTicketCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposTicket>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Facturable = request.Facturable;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
