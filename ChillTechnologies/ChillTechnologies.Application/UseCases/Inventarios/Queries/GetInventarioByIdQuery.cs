using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Inventarios.Queries;

public record GetInventarioByIdQuery(int Id) : IRequest<Domain.Entities.Inventario>;

internal sealed class GetInventarioByIdQueryHandler : IRequestHandler<GetInventarioByIdQuery, Domain.Entities.Inventario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Inventario> Handle(GetInventarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Inventario>().GetByIdAsync(request.Id))!;
    }
}
