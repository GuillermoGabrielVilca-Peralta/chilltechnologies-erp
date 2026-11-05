using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposEvento.Queries;

public record GetTipoEventoByIdQuery(int Id) : IRequest<Domain.Entities.TiposEvento>;

internal sealed class GetTipoEventoByIdQueryHandler : IRequestHandler<GetTipoEventoByIdQuery, Domain.Entities.TiposEvento>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoEventoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposEvento> Handle(GetTipoEventoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposEvento>().GetByIdAsync(request.Id))!;
    }
}
