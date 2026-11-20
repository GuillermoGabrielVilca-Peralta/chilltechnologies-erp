using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Queries;

public record GetBacklogByProyectoQuery(int ProyectoId) : IRequest<IEnumerable<Domain.Entities.HistoriasUsuario>>;

internal sealed class GetBacklogByProyectoQueryHandler : IRequestHandler<GetBacklogByProyectoQuery, IEnumerable<Domain.Entities.HistoriasUsuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBacklogByProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.HistoriasUsuario>> Handle(GetBacklogByProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>()
            .FindAsync(h => h.ProyectoId == request.ProyectoId && h.SprintId == null);
    }
}
