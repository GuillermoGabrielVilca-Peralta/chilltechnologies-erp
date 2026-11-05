using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aseguradoras.Queries;

public record GetAllAseguradorasQuery : IRequest<IEnumerable<Domain.Entities.Aseguradora>>;

internal sealed class GetAllAseguradorasQueryHandler : IRequestHandler<GetAllAseguradorasQuery, IEnumerable<Domain.Entities.Aseguradora>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAseguradorasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Aseguradora>> Handle(GetAllAseguradorasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Aseguradora>().GetAllAsync();
    }
}
