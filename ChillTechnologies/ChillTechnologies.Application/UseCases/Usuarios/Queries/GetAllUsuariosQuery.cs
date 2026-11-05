using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Queries;

public record GetAllUsuariosQuery : IRequest<IEnumerable<Domain.Entities.Usuario>>;

internal sealed class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<Domain.Entities.Usuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsuariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Usuario>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Usuario>().GetAllAsync();
    }
}
