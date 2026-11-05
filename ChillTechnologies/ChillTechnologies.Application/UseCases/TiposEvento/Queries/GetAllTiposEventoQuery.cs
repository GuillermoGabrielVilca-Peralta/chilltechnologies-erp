using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposEvento.Queries;

public record GetAllTiposEventoQuery : IRequest<IEnumerable<Domain.Entities.TiposEvento>>;

internal sealed class GetAllTiposEventoQueryHandler : IRequestHandler<GetAllTiposEventoQuery, IEnumerable<Domain.Entities.TiposEvento>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposEventoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposEvento>> Handle(GetAllTiposEventoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposEvento>().GetAllAsync();
    }
}
