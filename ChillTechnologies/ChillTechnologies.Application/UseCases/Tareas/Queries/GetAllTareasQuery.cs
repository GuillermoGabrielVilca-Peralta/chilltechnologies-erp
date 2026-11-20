using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Queries;

public record GetAllTareasQuery : IRequest<IEnumerable<Domain.Entities.Tarea>>;

internal sealed class GetAllTareasQueryHandler : IRequestHandler<GetAllTareasQuery, IEnumerable<Domain.Entities.Tarea>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTareasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Tarea>> Handle(GetAllTareasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Tarea>().GetAllAsync();
    }
}
