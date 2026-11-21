using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AcuerdosServicio.Queries;

public record GetAcuerdoServicioByIdQuery(int Id) : IRequest<Domain.Entities.AcuerdosServicio>;

internal sealed class GetAcuerdoServicioByIdQueryHandler : IRequestHandler<GetAcuerdoServicioByIdQuery, Domain.Entities.AcuerdosServicio>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAcuerdoServicioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.AcuerdosServicio> Handle(GetAcuerdoServicioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>().GetByIdAsync(request.Id))!;
    }
}
