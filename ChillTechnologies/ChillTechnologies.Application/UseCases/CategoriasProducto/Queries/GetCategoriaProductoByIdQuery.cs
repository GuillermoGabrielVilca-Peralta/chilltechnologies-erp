using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasProducto.Queries;

public record GetCategoriaProductoByIdQuery(int Id) : IRequest<Domain.Entities.CategoriasProducto>;

internal sealed class GetCategoriaProductoByIdQueryHandler : IRequestHandler<GetCategoriaProductoByIdQuery, Domain.Entities.CategoriasProducto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriaProductoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.CategoriasProducto> Handle(GetCategoriaProductoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.CategoriasProducto>().GetByIdAsync(request.Id))!;
    }
}
