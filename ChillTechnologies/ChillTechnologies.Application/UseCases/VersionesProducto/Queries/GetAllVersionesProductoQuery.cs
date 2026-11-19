using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.VersionesProducto.Queries;

public record GetAllVersionesProductoQuery : IRequest<IEnumerable<Domain.Entities.VersionesProducto>>;

internal sealed class GetAllVersionesProductoQueryHandler : IRequestHandler<GetAllVersionesProductoQuery, IEnumerable<Domain.Entities.VersionesProducto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVersionesProductoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.VersionesProducto>> Handle(GetAllVersionesProductoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.VersionesProducto>().GetAllAsync();
    }
}
