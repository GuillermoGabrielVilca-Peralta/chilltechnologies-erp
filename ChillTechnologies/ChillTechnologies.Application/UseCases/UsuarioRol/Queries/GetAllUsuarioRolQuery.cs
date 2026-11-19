using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuarioRol.Queries;

public record GetAllUsuarioRolQuery : IRequest<IEnumerable<Domain.Entities.UsuarioRol>>;

internal sealed class GetAllUsuarioRolQueryHandler : IRequestHandler<GetAllUsuarioRolQuery, IEnumerable<Domain.Entities.UsuarioRol>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsuarioRolQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.UsuarioRol>> Handle(GetAllUsuarioRolQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.UsuarioRol>().GetAllAsync();
    }
}
