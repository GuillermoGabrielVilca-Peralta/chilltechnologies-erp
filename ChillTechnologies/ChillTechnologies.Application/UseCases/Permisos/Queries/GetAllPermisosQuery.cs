using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Permisos.Queries;

public record GetAllPermisosQuery : IRequest<IEnumerable<Domain.Entities.Permiso>>;

internal sealed class GetAllPermisosQueryHandler : IRequestHandler<GetAllPermisosQuery, IEnumerable<Domain.Entities.Permiso>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPermisosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Permiso>> Handle(GetAllPermisosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Permiso>().GetAllAsync();
    }
}
