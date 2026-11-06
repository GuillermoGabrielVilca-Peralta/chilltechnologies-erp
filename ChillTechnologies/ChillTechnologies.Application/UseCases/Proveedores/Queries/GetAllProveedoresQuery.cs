using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proveedores.Queries;

public record GetAllProveedoresQuery : IRequest<IEnumerable<Domain.Entities.Proveedore>>;

internal sealed class GetAllProveedoresQueryHandler : IRequestHandler<GetAllProveedoresQuery, IEnumerable<Domain.Entities.Proveedore>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProveedoresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Proveedore>> Handle(GetAllProveedoresQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Proveedore>().GetAllAsync();
    }
}
