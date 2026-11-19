using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proyectos.Queries;

public record GetProyectosByContratoQuery(int ContratoId) : IRequest<IEnumerable<Domain.Entities.Proyecto>>;

internal sealed class GetProyectosByContratoQueryHandler : IRequestHandler<GetProyectosByContratoQuery, IEnumerable<Domain.Entities.Proyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProyectosByContratoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Proyecto>> Handle(GetProyectosByContratoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Proyecto>()
            .FindAsync(p => p.ContratoId == request.ContratoId);
    }
}
