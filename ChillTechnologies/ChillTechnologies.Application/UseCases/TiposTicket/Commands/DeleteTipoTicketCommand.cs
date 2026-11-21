using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposTicket.Commands;

public record DeleteTipoTicketCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoTicketCommandHandler : IRequestHandler<DeleteTipoTicketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoTicketCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposTicket>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
