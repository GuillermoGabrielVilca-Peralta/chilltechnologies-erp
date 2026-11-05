using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Eventos.Queries;

public record GetEventoByIdQuery(int Id) : IRequest<Domain.Entities.Evento>;

internal sealed class GetEventoByIdQueryHandler : IRequestHandler<GetEventoByIdQuery, Domain.Entities.Evento>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEventoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Evento> Handle(GetEventoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Evento>().GetByIdAsync(request.Id))!;
    }
}
