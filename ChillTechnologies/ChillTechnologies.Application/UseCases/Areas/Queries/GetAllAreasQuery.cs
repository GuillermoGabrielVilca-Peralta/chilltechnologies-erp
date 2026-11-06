using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Areas.Queries;

public record GetAllAreasQuery : IRequest<IEnumerable<Domain.Entities.Area>>;

internal sealed class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, IEnumerable<Domain.Entities.Area>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAreasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Area>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Area>().GetAllAsync();
    }
}
