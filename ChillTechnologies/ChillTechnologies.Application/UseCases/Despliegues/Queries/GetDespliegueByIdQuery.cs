using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Despliegues.Queries;

public record GetDespliegueByIdQuery(int Id) : IRequest<Domain.Entities.Despliegue>;

internal sealed class GetDespliegueByIdQueryHandler : IRequestHandler<GetDespliegueByIdQuery, Domain.Entities.Despliegue>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDespliegueByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Despliegue> Handle(GetDespliegueByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Despliegue>().GetByIdAsync(request.Id))!;
    }
}
