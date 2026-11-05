using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PuntosUsuarios.Queries;

public record GetPuntosUsuarioByIdQuery(int UsuarioId) : IRequest<Domain.Entities.PuntosUsuario>;

internal sealed class GetPuntosUsuarioByIdQueryHandler : IRequestHandler<GetPuntosUsuarioByIdQuery, Domain.Entities.PuntosUsuario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPuntosUsuarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.PuntosUsuario> Handle(GetPuntosUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.PuntosUsuario>().GetByIdAsync(request.UsuarioId))!;
    }
}
