using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Productos.Queries;

public record GetProductoByIdQuery(int Id) : IRequest<Domain.Entities.Producto>;

internal sealed class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, Domain.Entities.Producto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Producto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Producto>().GetByIdAsync(request.Id))!;
    }
}
