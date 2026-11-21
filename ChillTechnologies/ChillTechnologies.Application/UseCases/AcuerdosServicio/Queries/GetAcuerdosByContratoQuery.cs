using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AcuerdosServicio.Queries;

public record GetAcuerdosByContratoQuery(int ContratoId) : IRequest<IEnumerable<Domain.Entities.AcuerdosServicio>>;

internal sealed class GetAcuerdosByContratoQueryHandler : IRequestHandler<GetAcuerdosByContratoQuery, IEnumerable<Domain.Entities.AcuerdosServicio>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAcuerdosByContratoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.AcuerdosServicio>> Handle(GetAcuerdosByContratoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>()
            .FindAsync(a => a.ContratoId == request.ContratoId);
    }
}
