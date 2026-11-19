using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TarifasHora.Queries;

public record GetTarifaHoraByIdQuery(int Id) : IRequest<Domain.Entities.TarifasHora>;

internal sealed class GetTarifaHoraByIdQueryHandler : IRequestHandler<GetTarifaHoraByIdQuery, Domain.Entities.TarifasHora>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTarifaHoraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TarifasHora> Handle(GetTarifaHoraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TarifasHora>().GetByIdAsync(request.Id))!;
    }
}
