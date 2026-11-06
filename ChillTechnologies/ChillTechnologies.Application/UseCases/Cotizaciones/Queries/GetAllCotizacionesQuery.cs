using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cotizaciones.Queries;

public record GetAllCotizacionesQuery : IRequest<IEnumerable<Domain.Entities.Cotizacione>>;

internal sealed class GetAllCotizacionesQueryHandler : IRequestHandler<GetAllCotizacionesQuery, IEnumerable<Domain.Entities.Cotizacione>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCotizacionesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Cotizacione>> Handle(GetAllCotizacionesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Cotizacione>().GetAllAsync();
    }
}
