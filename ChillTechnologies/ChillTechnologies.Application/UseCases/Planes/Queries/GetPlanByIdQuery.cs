using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planes.Queries;

public record GetPlanByIdQuery(int Id) : IRequest<Domain.Entities.Plane>;

internal sealed class GetPlanByIdQueryHandler : IRequestHandler<GetPlanByIdQuery, Domain.Entities.Plane>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlanByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Plane> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Plane>().GetByIdAsync(request.Id))!;
    }
}
