using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CasosPrueba.Queries;

public record GetCasosByHistoriaQuery(int HistoriaId) : IRequest<IEnumerable<Domain.Entities.CasosPrueba>>;

internal sealed class GetCasosByHistoriaQueryHandler : IRequestHandler<GetCasosByHistoriaQuery, IEnumerable<Domain.Entities.CasosPrueba>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCasosByHistoriaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CasosPrueba>> Handle(GetCasosByHistoriaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CasosPrueba>()
            .FindAsync(c => c.HistoriaId == request.HistoriaId);
    }
}
