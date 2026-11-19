using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Repositorios.Queries;

public record GetAllRepositoriosQuery : IRequest<IEnumerable<Domain.Entities.Repositorio>>;

internal sealed class GetAllRepositoriosQueryHandler : IRequestHandler<GetAllRepositoriosQuery, IEnumerable<Domain.Entities.Repositorio>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRepositoriosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Repositorio>> Handle(GetAllRepositoriosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Repositorio>().GetAllAsync();
    }
}
