using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMantenimiento.Queries;

public record GetAllTiposMantenimientoQuery : IRequest<IEnumerable<Domain.Entities.TiposMantenimiento>>;

internal sealed class GetAllTiposMantenimientoQueryHandler : IRequestHandler<GetAllTiposMantenimientoQuery, IEnumerable<Domain.Entities.TiposMantenimiento>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposMantenimientoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposMantenimiento>> Handle(GetAllTiposMantenimientoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposMantenimiento>().GetAllAsync();
    }
}
