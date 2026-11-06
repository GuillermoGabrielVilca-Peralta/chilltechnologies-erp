using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SolicitudesAusencia.Queries;

public record GetAllSolicitudesAusenciaQuery : IRequest<IEnumerable<Domain.Entities.SolicitudesAusencium>>;

internal sealed class GetAllSolicitudesAusenciaQueryHandler : IRequestHandler<GetAllSolicitudesAusenciaQuery, IEnumerable<Domain.Entities.SolicitudesAusencium>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSolicitudesAusenciaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.SolicitudesAusencium>> Handle(GetAllSolicitudesAusenciaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.SolicitudesAusencium>().GetAllAsync();
    }
}
