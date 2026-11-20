using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Queries;

public record GetTareasByHistoriaQuery(int HistoriaId) : IRequest<IEnumerable<Domain.Entities.Tarea>>;

internal sealed class GetTareasByHistoriaQueryHandler : IRequestHandler<GetTareasByHistoriaQuery, IEnumerable<Domain.Entities.Tarea>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTareasByHistoriaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Tarea>> Handle(GetTareasByHistoriaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Tarea>()
            .FindAsync(t => t.HistoriaId == request.HistoriaId);
    }
}
