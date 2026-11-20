using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Queries;

public record GetTareaByIdQuery(int Id) : IRequest<Domain.Entities.Tarea>;

internal sealed class GetTareaByIdQueryHandler : IRequestHandler<GetTareaByIdQuery, Domain.Entities.Tarea>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTareaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Tarea> Handle(GetTareaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Tarea>().GetByIdAsync(request.Id))!;
    }
}
