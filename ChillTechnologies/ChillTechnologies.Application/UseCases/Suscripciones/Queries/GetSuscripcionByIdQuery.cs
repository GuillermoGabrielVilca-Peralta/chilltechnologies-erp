using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Suscripciones.Queries;

public record GetSuscripcionByIdQuery(int Id) : IRequest<Domain.Entities.Suscripcione>;

internal sealed class GetSuscripcionByIdQueryHandler : IRequestHandler<GetSuscripcionByIdQuery, Domain.Entities.Suscripcione>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSuscripcionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Suscripcione> Handle(GetSuscripcionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Suscripcione>().GetByIdAsync(request.Id))!;
    }
}
