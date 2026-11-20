using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Sprints.Queries;

public record GetSprintsByProyectoQuery(int ProyectoId) : IRequest<IEnumerable<Domain.Entities.Sprint>>;

internal sealed class GetSprintsByProyectoQueryHandler : IRequestHandler<GetSprintsByProyectoQuery, IEnumerable<Domain.Entities.Sprint>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSprintsByProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Sprint>> Handle(GetSprintsByProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Sprint>()
            .FindAsync(s => s.ProyectoId == request.ProyectoId);
    }
}
