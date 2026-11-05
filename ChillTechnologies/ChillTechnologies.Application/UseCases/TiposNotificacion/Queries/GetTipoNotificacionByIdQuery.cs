using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposNotificacion.Queries;

public record GetTipoNotificacionByIdQuery(int Id) : IRequest<Domain.Entities.TiposNotificacion>;

internal sealed class GetTipoNotificacionByIdQueryHandler : IRequestHandler<GetTipoNotificacionByIdQuery, Domain.Entities.TiposNotificacion>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoNotificacionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposNotificacion> Handle(GetTipoNotificacionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposNotificacion>().GetByIdAsync(request.Id))!;
    }
}
