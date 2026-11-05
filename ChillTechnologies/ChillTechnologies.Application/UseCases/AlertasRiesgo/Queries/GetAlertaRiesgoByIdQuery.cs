using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AlertasRiesgo.Queries;

public record GetAlertaRiesgoByIdQuery(int Id) : IRequest<Domain.Entities.AlertasRiesgo>;

internal sealed class GetAlertaRiesgoByIdQueryHandler : IRequestHandler<GetAlertaRiesgoByIdQuery, Domain.Entities.AlertasRiesgo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAlertaRiesgoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.AlertasRiesgo> Handle(GetAlertaRiesgoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.AlertasRiesgo>().GetByIdAsync(request.Id))!;
    }
}
