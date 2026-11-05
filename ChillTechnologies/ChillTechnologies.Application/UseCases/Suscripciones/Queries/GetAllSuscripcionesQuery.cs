using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Suscripciones.Queries;

public record GetAllSuscripcionesQuery : IRequest<IEnumerable<Domain.Entities.Suscripcione>>;

internal sealed class GetAllSuscripcionesQueryHandler : IRequestHandler<GetAllSuscripcionesQuery, IEnumerable<Domain.Entities.Suscripcione>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSuscripcionesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Suscripcione>> Handle(GetAllSuscripcionesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Suscripcione>().GetAllAsync();
    }
}
