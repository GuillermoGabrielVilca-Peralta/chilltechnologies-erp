using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.OrdenesCompra.Queries;

public record GetOrdenCompraByIdQuery(int Id) : IRequest<Domain.Entities.OrdenesCompra>;

internal sealed class GetOrdenCompraByIdQueryHandler : IRequestHandler<GetOrdenCompraByIdQuery, Domain.Entities.OrdenesCompra>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrdenCompraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.OrdenesCompra> Handle(GetOrdenCompraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.OrdenesCompra>().GetByIdAsync(request.Id))!;
    }
}
