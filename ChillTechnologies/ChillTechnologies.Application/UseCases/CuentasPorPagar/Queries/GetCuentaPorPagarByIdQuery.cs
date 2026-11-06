using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorPagar.Queries;

public record GetCuentaPorPagarByIdQuery(int Id) : IRequest<Domain.Entities.CuentasPorPagar>;

internal sealed class GetCuentaPorPagarByIdQueryHandler : IRequestHandler<GetCuentaPorPagarByIdQuery, Domain.Entities.CuentasPorPagar>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCuentaPorPagarByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.CuentasPorPagar> Handle(GetCuentaPorPagarByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.CuentasPorPagar>().GetByIdAsync(request.Id))!;
    }
}
