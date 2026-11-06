using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposAusencia.Commands;

public record DeleteTipoAusenciaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoAusenciaCommandHandler : IRequestHandler<DeleteTipoAusenciaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoAusenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoAusenciaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposAusencium>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
