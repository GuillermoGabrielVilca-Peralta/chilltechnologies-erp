using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMantenimiento.Queries;

public record GetTipoMantenimientoByIdQuery(int Id) : IRequest<Domain.Entities.TiposMantenimiento>;

internal sealed class GetTipoMantenimientoByIdQueryHandler : IRequestHandler<GetTipoMantenimientoByIdQuery, Domain.Entities.TiposMantenimiento>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoMantenimientoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposMantenimiento> Handle(GetTipoMantenimientoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposMantenimiento>().GetByIdAsync(request.Id))!;
    }
}
