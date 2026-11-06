using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasPorPagar.Queries;

public record GetAllCuentasPorPagarQuery : IRequest<IEnumerable<Domain.Entities.CuentasPorPagar>>;

internal sealed class GetAllCuentasPorPagarQueryHandler : IRequestHandler<GetAllCuentasPorPagarQuery, IEnumerable<Domain.Entities.CuentasPorPagar>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCuentasPorPagarQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CuentasPorPagar>> Handle(GetAllCuentasPorPagarQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CuentasPorPagar>().GetAllAsync();
    }
}
