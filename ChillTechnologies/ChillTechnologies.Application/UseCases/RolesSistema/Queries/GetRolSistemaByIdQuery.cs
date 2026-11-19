using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolesSistema.Queries;

public record GetRolSistemaByIdQuery(int Id) : IRequest<Domain.Entities.RolesSistema>;

internal sealed class GetRolSistemaByIdQueryHandler : IRequestHandler<GetRolSistemaByIdQuery, Domain.Entities.RolesSistema>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRolSistemaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.RolesSistema> Handle(GetRolSistemaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.RolesSistema>().GetByIdAsync(request.Id))!;
    }
}
