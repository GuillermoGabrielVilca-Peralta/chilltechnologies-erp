using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aliados.Queries;

public record GetAllAliadosQuery : IRequest<IEnumerable<Domain.Entities.Aliado>>;

internal sealed class GetAllAliadosQueryHandler : IRequestHandler<GetAllAliadosQuery, IEnumerable<Domain.Entities.Aliado>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAliadosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Aliado>> Handle(GetAllAliadosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Aliado>().GetAllAsync();
    }
}
