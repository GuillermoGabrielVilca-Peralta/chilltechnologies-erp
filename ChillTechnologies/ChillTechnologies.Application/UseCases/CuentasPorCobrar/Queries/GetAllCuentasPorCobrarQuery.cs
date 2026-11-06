using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorCobrar.Queries;

public record GetAllCuentasPorCobrarQuery : IRequest<IEnumerable<Domain.Entities.CuentasPorCobrar>>;

internal sealed class GetAllCuentasPorCobrarQueryHandler : IRequestHandler<GetAllCuentasPorCobrarQuery, IEnumerable<Domain.Entities.CuentasPorCobrar>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCuentasPorCobrarQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CuentasPorCobrar>> Handle(GetAllCuentasPorCobrarQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CuentasPorCobrar>().GetAllAsync();
    }
}
