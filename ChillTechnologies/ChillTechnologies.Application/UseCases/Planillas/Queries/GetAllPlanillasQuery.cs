using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planillas.Queries;

public record GetAllPlanillasQuery : IRequest<IEnumerable<Domain.Entities.Planilla>>;

internal sealed class GetAllPlanillasQueryHandler : IRequestHandler<GetAllPlanillasQuery, IEnumerable<Domain.Entities.Planilla>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPlanillasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Planilla>> Handle(GetAllPlanillasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Planilla>().GetAllAsync();
    }
}
