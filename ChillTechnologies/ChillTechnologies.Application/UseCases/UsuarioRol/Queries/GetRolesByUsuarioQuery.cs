using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuarioRol.Queries;

public record GetRolesByUsuarioQuery(int UsuarioSistemaId) : IRequest<IEnumerable<Domain.Entities.UsuarioRol>>;

internal sealed class GetRolesByUsuarioQueryHandler : IRequestHandler<GetRolesByUsuarioQuery, IEnumerable<Domain.Entities.UsuarioRol>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRolesByUsuarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.UsuarioRol>> Handle(GetRolesByUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.UsuarioRol>()
            .FindAsync(ur => ur.UsuarioSistemaId == request.UsuarioSistemaId);
    }
}
