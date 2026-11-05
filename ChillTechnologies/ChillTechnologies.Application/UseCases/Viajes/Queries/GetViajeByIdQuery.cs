using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Viajes.Queries;

public record GetViajeByIdQuery(int Id) : IRequest<Domain.Entities.Viaje>;

internal sealed class GetViajeByIdQueryHandler : IRequestHandler<GetViajeByIdQuery, Domain.Entities.Viaje>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetViajeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Viaje> Handle(GetViajeByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Viaje>().GetByIdAsync(request.Id))!;
    }
}
