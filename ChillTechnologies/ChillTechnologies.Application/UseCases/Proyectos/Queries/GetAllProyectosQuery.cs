using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proyectos.Queries;

public record GetAllProyectosQuery : IRequest<IEnumerable<Domain.Entities.Proyecto>>;

internal sealed class GetAllProyectosQueryHandler : IRequestHandler<GetAllProyectosQuery, IEnumerable<Domain.Entities.Proyecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProyectosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Proyecto>> Handle(GetAllProyectosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Proyecto>().GetAllAsync();
    }
}
