using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Viajes.Commands;

public record DeleteViajeCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteViajeCommandHandler : IRequestHandler<DeleteViajeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteViajeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteViajeCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Viaje>();

        var viaje = await repo.GetByIdAsync(request.Id);

        repo.Delete(viaje!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
