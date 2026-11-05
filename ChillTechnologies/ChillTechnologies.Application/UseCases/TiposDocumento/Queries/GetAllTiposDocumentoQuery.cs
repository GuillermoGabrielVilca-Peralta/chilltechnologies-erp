using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposDocumento.Queries;

public record GetAllTiposDocumentoQuery : IRequest<IEnumerable<Domain.Entities.TiposDocumento>>;

internal sealed class GetAllTiposDocumentoQueryHandler : IRequestHandler<GetAllTiposDocumentoQuery, IEnumerable<Domain.Entities.TiposDocumento>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposDocumentoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposDocumento>> Handle(GetAllTiposDocumentoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposDocumento>().GetAllAsync();
    }
}
