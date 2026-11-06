using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cargos.Queries;

public record GetAllCargosQuery : IRequest<IEnumerable<Domain.Entities.Cargo>>;

internal sealed class GetAllCargosQueryHandler : IRequestHandler<GetAllCargosQuery, IEnumerable<Domain.Entities.Cargo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCargosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Cargo>> Handle(GetAllCargosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Cargo>().GetAllAsync();
    }
}
