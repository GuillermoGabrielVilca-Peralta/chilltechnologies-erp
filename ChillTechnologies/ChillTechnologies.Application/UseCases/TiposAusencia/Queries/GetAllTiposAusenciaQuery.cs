using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposAusencia.Queries;

public record GetAllTiposAusenciaQuery : IRequest<IEnumerable<Domain.Entities.TiposAusencium>>;

internal sealed class GetAllTiposAusenciaQueryHandler : IRequestHandler<GetAllTiposAusenciaQuery, IEnumerable<Domain.Entities.TiposAusencium>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposAusenciaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposAusencium>> Handle(GetAllTiposAusenciaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposAusencium>().GetAllAsync();
    }
}
