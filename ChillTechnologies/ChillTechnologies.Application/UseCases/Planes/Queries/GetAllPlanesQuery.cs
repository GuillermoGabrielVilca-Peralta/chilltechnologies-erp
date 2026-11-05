using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planes.Queries;

public record GetAllPlanesQuery : IRequest<IEnumerable<Domain.Entities.Plane>>;

internal sealed class GetAllPlanesQueryHandler : IRequestHandler<GetAllPlanesQuery, IEnumerable<Domain.Entities.Plane>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPlanesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Plane>> Handle(GetAllPlanesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Plane>().GetAllAsync();
    }
}
