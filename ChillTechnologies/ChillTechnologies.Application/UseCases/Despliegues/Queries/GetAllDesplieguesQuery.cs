using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Despliegues.Queries;

public record GetAllDesplieguesQuery : IRequest<IEnumerable<Domain.Entities.Despliegue>>;

internal sealed class GetAllDesplieguesQueryHandler : IRequestHandler<GetAllDesplieguesQuery, IEnumerable<Domain.Entities.Despliegue>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDesplieguesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Despliegue>> Handle(GetAllDesplieguesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Despliegue>().GetAllAsync();
    }
}
