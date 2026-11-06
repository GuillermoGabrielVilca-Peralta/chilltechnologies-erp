using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PlanCuentas.Queries;

public record GetAllPlanCuentasQuery : IRequest<IEnumerable<Domain.Entities.PlanCuenta>>;

internal sealed class GetAllPlanCuentasQueryHandler : IRequestHandler<GetAllPlanCuentasQuery, IEnumerable<Domain.Entities.PlanCuenta>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPlanCuentasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.PlanCuenta>> Handle(GetAllPlanCuentasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.PlanCuenta>().GetAllAsync();
    }
}
