using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Queries;

public record GetHorasByProyectoQuery(int ProyectoId) : IRequest<IEnumerable<Domain.Entities.RegistrosHora>>;

internal sealed class GetHorasByProyectoQueryHandler : IRequestHandler<GetHorasByProyectoQuery, IEnumerable<Domain.Entities.RegistrosHora>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHorasByProyectoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.RegistrosHora>> Handle(GetHorasByProyectoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.RegistrosHora>()
            .FindAsync(h => h.ProyectoId == request.ProyectoId);
    }
}
