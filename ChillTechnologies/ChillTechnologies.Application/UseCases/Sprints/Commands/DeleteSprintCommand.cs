using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Sprints.Commands;

public record DeleteSprintCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSprintCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Sprint>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
