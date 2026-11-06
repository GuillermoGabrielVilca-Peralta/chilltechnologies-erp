using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cotizaciones.Queries;

public record GetCotizacionByIdQuery(int Id) : IRequest<Domain.Entities.Cotizacione>;

internal sealed class GetCotizacionByIdQueryHandler : IRequestHandler<GetCotizacionByIdQuery, Domain.Entities.Cotizacione>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCotizacionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Cotizacione> Handle(GetCotizacionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Cotizacione>().GetByIdAsync(request.Id))!;
    }
}
