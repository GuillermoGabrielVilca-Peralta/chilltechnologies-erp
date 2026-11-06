using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposAusencia.Queries;

public record GetTipoAusenciaByIdQuery(int Id) : IRequest<Domain.Entities.TiposAusencium>;

internal sealed class GetTipoAusenciaByIdQueryHandler : IRequestHandler<GetTipoAusenciaByIdQuery, Domain.Entities.TiposAusencium>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoAusenciaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposAusencium> Handle(GetTipoAusenciaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposAusencium>().GetByIdAsync(request.Id))!;
    }
}
