using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Asistencias.Queries;

public record GetAsistenciaByIdQuery(int Id) : IRequest<Domain.Entities.Asistencia>;

internal sealed class GetAsistenciaByIdQueryHandler : IRequestHandler<GetAsistenciaByIdQuery, Domain.Entities.Asistencia>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAsistenciaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Asistencia> Handle(GetAsistenciaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Asistencia>().GetByIdAsync(request.Id))!;
    }
}
