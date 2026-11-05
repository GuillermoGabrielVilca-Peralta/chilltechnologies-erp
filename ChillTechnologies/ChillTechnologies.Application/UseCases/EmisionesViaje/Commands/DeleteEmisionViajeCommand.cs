using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EmisionesViaje.Commands;

public record DeleteEmisionViajeCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteEmisionViajeCommandHandler : IRequestHandler<DeleteEmisionViajeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmisionViajeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteEmisionViajeCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.EmisionesViaje>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
