using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Notificaciones.Queries;

public record GetAllNotificacionesQuery : IRequest<IEnumerable<Domain.Entities.Notificacione>>;

internal sealed class GetAllNotificacionesQueryHandler : IRequestHandler<GetAllNotificacionesQuery, IEnumerable<Domain.Entities.Notificacione>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificacionesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Notificacione>> Handle(GetAllNotificacionesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Notificacione>().GetAllAsync();
    }
}
