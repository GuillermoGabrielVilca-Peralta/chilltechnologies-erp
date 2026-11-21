using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EjecucionesPrueba.Queries;

public record GetEjecucionPruebaByIdQuery(int Id) : IRequest<Domain.Entities.EjecucionesPrueba>;

internal sealed class GetEjecucionPruebaByIdQueryHandler : IRequestHandler<GetEjecucionPruebaByIdQuery, Domain.Entities.EjecucionesPrueba>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEjecucionPruebaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.EjecucionesPrueba> Handle(GetEjecucionPruebaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.EjecucionesPrueba>().GetByIdAsync(request.Id))!;
    }
}
