using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Paradas.Commands;

public record DeleteParadaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteParadaCommandHandler : IRequestHandler<DeleteParadaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteParadaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteParadaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Parada>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
