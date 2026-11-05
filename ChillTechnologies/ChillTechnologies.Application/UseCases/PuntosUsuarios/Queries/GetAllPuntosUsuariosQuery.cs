using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PuntosUsuarios.Queries;

public record GetAllPuntosUsuariosQuery : IRequest<IEnumerable<Domain.Entities.PuntosUsuario>>;

internal sealed class GetAllPuntosUsuariosQueryHandler : IRequestHandler<GetAllPuntosUsuariosQuery, IEnumerable<Domain.Entities.PuntosUsuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPuntosUsuariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.PuntosUsuario>> Handle(GetAllPuntosUsuariosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.PuntosUsuario>().GetAllAsync();
    }
}
