using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Eventos.Commands;

public record DeleteEventoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteEventoCommandHandler : IRequestHandler<DeleteEventoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEventoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteEventoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Evento>();

        var evento = await repo.GetByIdAsync(request.Id);

        repo.Delete(evento!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
