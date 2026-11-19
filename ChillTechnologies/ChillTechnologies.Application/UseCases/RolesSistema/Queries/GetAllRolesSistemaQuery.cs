using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolesSistema.Queries;

public record GetAllRolesSistemaQuery : IRequest<IEnumerable<Domain.Entities.RolesSistema>>;

internal sealed class GetAllRolesSistemaQueryHandler : IRequestHandler<GetAllRolesSistemaQuery, IEnumerable<Domain.Entities.RolesSistema>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesSistemaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.RolesSistema>> Handle(GetAllRolesSistemaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.RolesSistema>().GetAllAsync();
    }
}
