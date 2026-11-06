using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Asistencias.Queries;

public record GetAllAsistenciasQuery : IRequest<IEnumerable<Domain.Entities.Asistencia>>;

internal sealed class GetAllAsistenciasQueryHandler : IRequestHandler<GetAllAsistenciasQuery, IEnumerable<Domain.Entities.Asistencia>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAsistenciasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Asistencia>> Handle(GetAllAsistenciasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Asistencia>().GetAllAsync();
    }
}
