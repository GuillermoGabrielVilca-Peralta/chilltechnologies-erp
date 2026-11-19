using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HitosProyecto.Queries;

public record GetHitoProyectoByIdQuery(int Id) : IRequest<Domain.Entities.HitosProyecto>;

internal sealed class GetHitoProyectoByIdQueryHandler : IRequestHandler<GetHitoProyectoByIdQuery, Domain.Entities.HitosProyecto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHitoProyectoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.HitosProyecto> Handle(GetHitoProyectoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.HitosProyecto>().GetByIdAsync(request.Id))!;
    }
}
