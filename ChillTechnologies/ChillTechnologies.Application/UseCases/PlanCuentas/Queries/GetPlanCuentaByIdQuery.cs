using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PlanCuentas.Queries;

public record GetPlanCuentaByIdQuery(int Id) : IRequest<Domain.Entities.PlanCuenta>;

internal sealed class GetPlanCuentaByIdQueryHandler : IRequestHandler<GetPlanCuentaByIdQuery, Domain.Entities.PlanCuenta>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlanCuentaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.PlanCuenta> Handle(GetPlanCuentaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.PlanCuenta>().GetByIdAsync(request.Id))!;
    }
}
