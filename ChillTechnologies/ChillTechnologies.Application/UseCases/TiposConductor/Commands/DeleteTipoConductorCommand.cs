using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposConductor.Commands;

public record DeleteTipoConductorCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoConductorCommandHandler : IRequestHandler<DeleteTipoConductorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoConductorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoConductorCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposConductor>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
