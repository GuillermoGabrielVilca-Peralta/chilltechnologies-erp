using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SolicitudesAusencia.Queries;

public record GetSolicitudAusenciaByIdQuery(int Id) : IRequest<Domain.Entities.SolicitudesAusencium>;

internal sealed class GetSolicitudAusenciaByIdQueryHandler : IRequestHandler<GetSolicitudAusenciaByIdQuery, Domain.Entities.SolicitudesAusencium>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSolicitudAusenciaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.SolicitudesAusencium> Handle(GetSolicitudAusenciaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.SolicitudesAusencium>().GetByIdAsync(request.Id))!;
    }
}
