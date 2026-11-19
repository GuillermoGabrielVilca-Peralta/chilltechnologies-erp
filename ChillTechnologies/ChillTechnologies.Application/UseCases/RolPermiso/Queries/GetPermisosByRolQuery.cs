using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolPermiso.Queries;

public record GetPermisosByRolQuery(int RolId) : IRequest<IEnumerable<Domain.Entities.RolPermiso>>;

internal sealed class GetPermisosByRolQueryHandler : IRequestHandler<GetPermisosByRolQuery, IEnumerable<Domain.Entities.RolPermiso>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPermisosByRolQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.RolPermiso>> Handle(GetPermisosByRolQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.RolPermiso>()
            .FindAsync(rp => rp.RolId == request.RolId);
    }
}
