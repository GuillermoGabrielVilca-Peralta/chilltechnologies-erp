using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Defectos.Queries;

public record GetDefectoByIdQuery(int Id) : IRequest<Domain.Entities.Defecto>;

internal sealed class GetDefectoByIdQueryHandler : IRequestHandler<GetDefectoByIdQuery, Domain.Entities.Defecto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDefectoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Defecto> Handle(GetDefectoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Defecto>().GetByIdAsync(request.Id))!;
    }
}
