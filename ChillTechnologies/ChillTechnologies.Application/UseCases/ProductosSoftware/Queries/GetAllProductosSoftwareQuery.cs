using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ProductosSoftware.Queries;

public record GetAllProductosSoftwareQuery : IRequest<IEnumerable<Domain.Entities.ProductosSoftware>>;

internal sealed class GetAllProductosSoftwareQueryHandler : IRequestHandler<GetAllProductosSoftwareQuery, IEnumerable<Domain.Entities.ProductosSoftware>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductosSoftwareQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.ProductosSoftware>> Handle(GetAllProductosSoftwareQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.ProductosSoftware>().GetAllAsync();
    }
}
