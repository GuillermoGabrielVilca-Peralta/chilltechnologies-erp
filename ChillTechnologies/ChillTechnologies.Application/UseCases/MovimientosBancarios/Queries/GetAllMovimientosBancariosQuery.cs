using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosBancarios.Queries;

public record GetAllMovimientosBancariosQuery : IRequest<IEnumerable<Domain.Entities.MovimientosBancario>>;

internal sealed class GetAllMovimientosBancariosQueryHandler : IRequestHandler<GetAllMovimientosBancariosQuery, IEnumerable<Domain.Entities.MovimientosBancario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMovimientosBancariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MovimientosBancario>> Handle(GetAllMovimientosBancariosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MovimientosBancario>().GetAllAsync();
    }
}
