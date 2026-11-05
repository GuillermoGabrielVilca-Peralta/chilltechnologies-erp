using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EmisionesViaje.Queries;

public record GetEmisionViajeByIdQuery(int Id) : IRequest<Domain.Entities.EmisionesViaje>;

internal sealed class GetEmisionViajeByIdQueryHandler : IRequestHandler<GetEmisionViajeByIdQuery, Domain.Entities.EmisionesViaje>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmisionViajeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.EmisionesViaje> Handle(GetEmisionViajeByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.EmisionesViaje>().GetByIdAsync(request.Id))!;
    }
}
