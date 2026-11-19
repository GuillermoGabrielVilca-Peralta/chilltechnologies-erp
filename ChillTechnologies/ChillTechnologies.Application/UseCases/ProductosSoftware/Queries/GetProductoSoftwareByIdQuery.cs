using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ProductosSoftware.Queries;

public record GetProductoSoftwareByIdQuery(int Id) : IRequest<Domain.Entities.ProductosSoftware>;

internal sealed class GetProductoSoftwareByIdQueryHandler : IRequestHandler<GetProductoSoftwareByIdQuery, Domain.Entities.ProductosSoftware>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductoSoftwareByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ProductosSoftware> Handle(GetProductoSoftwareByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ProductosSoftware>().GetByIdAsync(request.Id))!;
    }
}
