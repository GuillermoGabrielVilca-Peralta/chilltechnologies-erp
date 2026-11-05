using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Eventos.Queries;

public record GetAllEventosQuery : IRequest<IEnumerable<Domain.Entities.Evento>>;

internal sealed class GetAllEventosQueryHandler : IRequestHandler<GetAllEventosQuery, IEnumerable<Domain.Entities.Evento>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEventosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Evento>> Handle(GetAllEventosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Evento>().GetAllAsync();
    }
}
