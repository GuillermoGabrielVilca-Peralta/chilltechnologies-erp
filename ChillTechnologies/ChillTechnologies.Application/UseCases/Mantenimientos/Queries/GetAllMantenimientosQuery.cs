using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Mantenimientos.Queries;

public record GetAllMantenimientosQuery : IRequest<IEnumerable<Domain.Entities.Mantenimiento>>;

internal sealed class GetAllMantenimientosQueryHandler : IRequestHandler<GetAllMantenimientosQuery, IEnumerable<Domain.Entities.Mantenimiento>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMantenimientosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Mantenimiento>> Handle(GetAllMantenimientosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Mantenimiento>().GetAllAsync();
    }
}
