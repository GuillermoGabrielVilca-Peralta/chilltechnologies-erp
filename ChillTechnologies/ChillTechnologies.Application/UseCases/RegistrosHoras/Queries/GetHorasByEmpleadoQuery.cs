using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Queries;

public record GetHorasByEmpleadoQuery(int EmpleadoId, DateOnly Desde, DateOnly Hasta) : IRequest<IEnumerable<Domain.Entities.RegistrosHora>>;

internal sealed class GetHorasByEmpleadoQueryHandler : IRequestHandler<GetHorasByEmpleadoQuery, IEnumerable<Domain.Entities.RegistrosHora>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHorasByEmpleadoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.RegistrosHora>> Handle(GetHorasByEmpleadoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.RegistrosHora>()
            .FindAsync(h => h.EmpleadoId == request.EmpleadoId &&
                            h.Fecha >= request.Desde &&
                            h.Fecha <= request.Hasta);
    }
}
