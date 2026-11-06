using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Productos.Queries;

public record GetAllProductosQuery : IRequest<IEnumerable<Domain.Entities.Producto>>;

internal sealed class GetAllProductosQueryHandler : IRequestHandler<GetAllProductosQuery, IEnumerable<Domain.Entities.Producto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Producto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Producto>().GetAllAsync();
    }
}
