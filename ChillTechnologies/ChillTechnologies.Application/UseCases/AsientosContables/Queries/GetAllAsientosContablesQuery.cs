using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsientosContables.Queries;

public record GetAllAsientosContablesQuery : IRequest<IEnumerable<Domain.Entities.AsientosContable>>;

internal sealed class GetAllAsientosContablesQueryHandler : IRequestHandler<GetAllAsientosContablesQuery, IEnumerable<Domain.Entities.AsientosContable>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAsientosContablesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.AsientosContable>> Handle(GetAllAsientosContablesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.AsientosContable>().GetAllAsync();
    }
}
