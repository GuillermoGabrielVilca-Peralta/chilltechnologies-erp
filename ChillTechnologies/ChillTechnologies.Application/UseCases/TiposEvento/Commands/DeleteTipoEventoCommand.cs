using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposEvento.Commands;

public record DeleteTipoEventoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoEventoCommandHandler : IRequestHandler<DeleteTipoEventoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoEventoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoEventoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposEvento>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
