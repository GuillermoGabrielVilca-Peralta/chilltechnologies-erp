using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proyectos.Queries;

public record GetProyectoByIdQuery(int Id) : IRequest<Domain.Entities.Proyecto>;

internal sealed class GetProyectoByIdQueryHandler : IRequestHandler<GetProyectoByIdQuery, Domain.Entities.Proyecto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProyectoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Proyecto> Handle(GetProyectoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Proyecto>().GetByIdAsync(request.Id))!;
    }
}
