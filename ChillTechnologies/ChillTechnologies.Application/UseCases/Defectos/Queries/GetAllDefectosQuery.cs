using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Defectos.Queries;

public record GetAllDefectosQuery : IRequest<IEnumerable<Domain.Entities.Defecto>>;

internal sealed class GetAllDefectosQueryHandler : IRequestHandler<GetAllDefectosQuery, IEnumerable<Domain.Entities.Defecto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDefectosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Defecto>> Handle(GetAllDefectosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Defecto>().GetAllAsync();
    }
}
