using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Sprints.Queries;

public record GetAllSprintsQuery : IRequest<IEnumerable<Domain.Entities.Sprint>>;

internal sealed class GetAllSprintsQueryHandler : IRequestHandler<GetAllSprintsQuery, IEnumerable<Domain.Entities.Sprint>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSprintsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Sprint>> Handle(GetAllSprintsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Sprint>().GetAllAsync();
    }
}
