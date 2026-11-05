using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposNotificacion.Queries;

public record GetAllTiposNotificacionQuery : IRequest<IEnumerable<Domain.Entities.TiposNotificacion>>;

internal sealed class GetAllTiposNotificacionQueryHandler : IRequestHandler<GetAllTiposNotificacionQuery, IEnumerable<Domain.Entities.TiposNotificacion>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposNotificacionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposNotificacion>> Handle(GetAllTiposNotificacionQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposNotificacion>().GetAllAsync();
    }
}
