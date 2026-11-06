using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorCobrar.Queries;

public record GetCuentaPorCobrarByIdQuery(int Id) : IRequest<Domain.Entities.CuentasPorCobrar>;

internal sealed class GetCuentaPorCobrarByIdQueryHandler : IRequestHandler<GetCuentaPorCobrarByIdQuery, Domain.Entities.CuentasPorCobrar>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCuentaPorCobrarByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.CuentasPorCobrar> Handle(GetCuentaPorCobrarByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.CuentasPorCobrar>().GetByIdAsync(request.Id))!;
    }
}
