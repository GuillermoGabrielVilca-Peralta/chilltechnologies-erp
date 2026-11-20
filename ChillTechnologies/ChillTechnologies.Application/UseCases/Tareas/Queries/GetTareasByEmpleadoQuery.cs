using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Queries;

public record GetTareasByEmpleadoQuery(int EmpleadoId) : IRequest<IEnumerable<Domain.Entities.Tarea>>;

internal sealed class GetTareasByEmpleadoQueryHandler : IRequestHandler<GetTareasByEmpleadoQuery, IEnumerable<Domain.Entities.Tarea>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTareasByEmpleadoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Tarea>> Handle(GetTareasByEmpleadoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Tarea>()
            .FindAsync(t => t.EmpleadoId == request.EmpleadoId);
    }
}
