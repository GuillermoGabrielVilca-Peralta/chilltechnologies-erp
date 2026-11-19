using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TarifasHora.Queries;

public record GetAllTarifasHoraQuery : IRequest<IEnumerable<Domain.Entities.TarifasHora>>;

internal sealed class GetAllTarifasHoraQueryHandler : IRequestHandler<GetAllTarifasHoraQuery, IEnumerable<Domain.Entities.TarifasHora>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTarifasHoraQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TarifasHora>> Handle(GetAllTarifasHoraQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TarifasHora>().GetAllAsync();
    }
}
