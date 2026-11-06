using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planillas.Commands;

public record DeletePlanillaCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePlanillaCommandHandler : IRequestHandler<DeletePlanillaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePlanillaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePlanillaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Planilla>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
