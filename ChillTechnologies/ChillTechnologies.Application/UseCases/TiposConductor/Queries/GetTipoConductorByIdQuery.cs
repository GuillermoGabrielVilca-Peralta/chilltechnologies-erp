using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposConductor.Queries;

public record GetTipoConductorByIdQuery(int Id) : IRequest<Domain.Entities.TiposConductor>;

internal sealed class GetTipoConductorByIdQueryHandler : IRequestHandler<GetTipoConductorByIdQuery, Domain.Entities.TiposConductor>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoConductorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposConductor> Handle(GetTipoConductorByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposConductor>().GetByIdAsync(request.Id))!;
    }
}
