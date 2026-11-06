using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PlanCuentas.Commands;

public record DeletePlanCuentaCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePlanCuentaCommandHandler : IRequestHandler<DeletePlanCuentaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePlanCuentaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePlanCuentaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.PlanCuenta>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
