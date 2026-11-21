using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TicketsSoporte.Commands;

public record AsignarTicketSoporteCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int? AsignadoAId { get; set; }
}

internal sealed class AsignarTicketSoporteCommandHandler : IRequestHandler<AsignarTicketSoporteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AsignarTicketSoporteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AsignarTicketSoporteCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TicketsSoporte>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.AsignadoAId = request.AsignadoAId;

        if (request.AsignadoAId == null)
            item.Estado = "Abierto";
        else if (item.Estado == "Abierto")
            item.Estado = "Asignado";

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
