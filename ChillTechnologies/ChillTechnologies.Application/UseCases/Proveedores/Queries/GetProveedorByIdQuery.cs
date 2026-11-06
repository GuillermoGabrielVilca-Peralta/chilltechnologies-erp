using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proveedores.Queries;

public record GetProveedorByIdQuery(int Id) : IRequest<Domain.Entities.Proveedore>;

internal sealed class GetProveedorByIdQueryHandler : IRequestHandler<GetProveedorByIdQuery, Domain.Entities.Proveedore>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProveedorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Proveedore> Handle(GetProveedorByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Proveedore>().GetByIdAsync(request.Id))!;
    }
}
