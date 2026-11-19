using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Queries;

public record GetAllUsuariosSistemaQuery : IRequest<IEnumerable<Domain.Entities.UsuariosSistema>>;

internal sealed class GetAllUsuariosSistemaQueryHandler : IRequestHandler<GetAllUsuariosSistemaQuery, IEnumerable<Domain.Entities.UsuariosSistema>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsuariosSistemaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.UsuariosSistema>> Handle(GetAllUsuariosSistemaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.UsuariosSistema>().GetAllAsync();
    }
}
