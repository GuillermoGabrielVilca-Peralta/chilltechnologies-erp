using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Almacenes.Queries;

public record GetAllAlmacenesQuery : IRequest<IEnumerable<Domain.Entities.Almacene>>;

internal sealed class GetAllAlmacenesQueryHandler : IRequestHandler<GetAllAlmacenesQuery, IEnumerable<Domain.Entities.Almacene>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAlmacenesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Almacene>> Handle(GetAllAlmacenesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Almacene>().GetAllAsync();
    }
}
