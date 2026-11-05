using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Notificaciones.Queries;

public record GetNotificacionByIdQuery(int Id) : IRequest<Domain.Entities.Notificacione>;

internal sealed class GetNotificacionByIdQueryHandler : IRequestHandler<GetNotificacionByIdQuery, Domain.Entities.Notificacione>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificacionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Notificacione> Handle(GetNotificacionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Notificacione>().GetByIdAsync(request.Id))!;
    }
}
