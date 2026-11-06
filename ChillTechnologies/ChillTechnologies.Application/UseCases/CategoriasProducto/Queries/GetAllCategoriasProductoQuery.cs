using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasProducto.Queries;

public record GetAllCategoriasProductoQuery : IRequest<IEnumerable<Domain.Entities.CategoriasProducto>>;

internal sealed class GetAllCategoriasProductoQueryHandler : IRequestHandler<GetAllCategoriasProductoQuery, IEnumerable<Domain.Entities.CategoriasProducto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoriasProductoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CategoriasProducto>> Handle(GetAllCategoriasProductoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CategoriasProducto>().GetAllAsync();
    }
}
