using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolPermiso.Queries;

public record GetAllRolPermisoQuery : IRequest<IEnumerable<Domain.Entities.RolPermiso>>;

internal sealed class GetAllRolPermisoQueryHandler : IRequestHandler<GetAllRolPermisoQuery, IEnumerable<Domain.Entities.RolPermiso>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolPermisoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.RolPermiso>> Handle(GetAllRolPermisoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.RolPermiso>().GetAllAsync();
    }
}
