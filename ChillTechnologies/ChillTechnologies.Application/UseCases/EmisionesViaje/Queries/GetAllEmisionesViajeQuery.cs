using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EmisionesViaje.Queries;

public record GetAllEmisionesViajeQuery : IRequest<IEnumerable<Domain.Entities.EmisionesViaje>>;

internal sealed class GetAllEmisionesViajeQueryHandler : IRequestHandler<GetAllEmisionesViajeQuery, IEnumerable<Domain.Entities.EmisionesViaje>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmisionesViajeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.EmisionesViaje>> Handle(GetAllEmisionesViajeQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.EmisionesViaje>().GetAllAsync();
    }
}
