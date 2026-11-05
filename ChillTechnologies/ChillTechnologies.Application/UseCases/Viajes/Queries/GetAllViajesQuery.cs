using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Viajes.Queries;

public record GetAllViajesQuery : IRequest<IEnumerable<Domain.Entities.Viaje>>;

internal sealed class GetAllViajesQueryHandler : IRequestHandler<GetAllViajesQuery, IEnumerable<Domain.Entities.Viaje>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllViajesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Viaje>> Handle(GetAllViajesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Viaje>().GetAllAsync();
    }
}
