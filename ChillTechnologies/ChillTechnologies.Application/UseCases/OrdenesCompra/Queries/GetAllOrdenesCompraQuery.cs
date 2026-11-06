using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.OrdenesCompra.Queries;

public record GetAllOrdenesCompraQuery : IRequest<IEnumerable<Domain.Entities.OrdenesCompra>>;

internal sealed class GetAllOrdenesCompraQueryHandler : IRequestHandler<GetAllOrdenesCompraQuery, IEnumerable<Domain.Entities.OrdenesCompra>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrdenesCompraQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.OrdenesCompra>> Handle(GetAllOrdenesCompraQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.OrdenesCompra>().GetAllAsync();
    }
}
