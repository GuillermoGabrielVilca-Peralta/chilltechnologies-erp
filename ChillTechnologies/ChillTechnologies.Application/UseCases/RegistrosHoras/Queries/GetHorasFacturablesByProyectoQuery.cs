using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Queries;

public record GetHorasFacturablesByProyectoQuery(int ProyectoId) : IRequest<decimal>;

internal sealed class GetHorasFacturablesByProyectoQueryHandler : IRequestHandler<GetHorasFacturablesByProyectoQuery, decimal>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHorasFacturablesByProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<decimal> Handle(GetHorasFacturablesByProyectoQuery request, CancellationToken cancellationToken)
    {
        var horas = await _unitOfWork.Repository<Domain.Entities.RegistrosHora>()
            .FindAsync(h => h.ProyectoId == request.ProyectoId && h.Facturable && h.Aprobado);

        return horas.Sum(h => h.Horas);
    }
}
