using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposDocumento.Queries;

public record GetTipoDocumentoByIdQuery(int Id) : IRequest<Domain.Entities.TiposDocumento>;

internal sealed class GetTipoDocumentoByIdQueryHandler : IRequestHandler<GetTipoDocumentoByIdQuery, Domain.Entities.TiposDocumento>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoDocumentoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposDocumento> Handle(GetTipoDocumentoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposDocumento>().GetByIdAsync(request.Id))!;
    }
}
