using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Mantenimientos.Queries;

public record GetMantenimientoByIdQuery(int Id) : IRequest<Domain.Entities.Mantenimiento>;

internal sealed class GetMantenimientoByIdQueryHandler : IRequestHandler<GetMantenimientoByIdQuery, Domain.Entities.Mantenimiento>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMantenimientoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Mantenimiento> Handle(GetMantenimientoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Mantenimiento>().GetByIdAsync(request.Id))!;
    }
}
