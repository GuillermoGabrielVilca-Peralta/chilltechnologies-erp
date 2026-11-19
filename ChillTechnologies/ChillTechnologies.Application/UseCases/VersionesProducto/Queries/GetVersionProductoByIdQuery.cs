using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.VersionesProducto.Queries;

public record GetVersionProductoByIdQuery(int Id) : IRequest<Domain.Entities.VersionesProducto>;

internal sealed class GetVersionProductoByIdQueryHandler : IRequestHandler<GetVersionProductoByIdQuery, Domain.Entities.VersionesProducto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVersionProductoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.VersionesProducto> Handle(GetVersionProductoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.VersionesProducto>().GetByIdAsync(request.Id))!;
    }
}
