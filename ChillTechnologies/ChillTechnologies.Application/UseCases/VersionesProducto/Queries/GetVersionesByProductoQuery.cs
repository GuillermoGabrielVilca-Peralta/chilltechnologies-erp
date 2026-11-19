using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.VersionesProducto.Queries;

public record GetVersionesByProductoQuery(int ProductoSoftwareId) : IRequest<IEnumerable<Domain.Entities.VersionesProducto>>;

internal sealed class GetVersionesByProductoQueryHandler : IRequestHandler<GetVersionesByProductoQuery, IEnumerable<Domain.Entities.VersionesProducto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVersionesByProductoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.VersionesProducto>> Handle(GetVersionesByProductoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.VersionesProducto>()
            .FindAsync(v => v.ProductoSoftwareId == request.ProductoSoftwareId);
    }
}
