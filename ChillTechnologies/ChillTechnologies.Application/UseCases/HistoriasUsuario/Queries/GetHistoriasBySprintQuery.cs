using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Queries;

public record GetHistoriasBySprintQuery(int SprintId) : IRequest<IEnumerable<Domain.Entities.HistoriasUsuario>>;

internal sealed class GetHistoriasBySprintQueryHandler : IRequestHandler<GetHistoriasBySprintQuery, IEnumerable<Domain.Entities.HistoriasUsuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHistoriasBySprintQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.HistoriasUsuario>> Handle(GetHistoriasBySprintQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>()
            .FindAsync(h => h.SprintId == request.SprintId);
    }
}
