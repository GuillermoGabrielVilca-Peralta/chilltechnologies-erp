using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ContratosDesarrollo.Queries;

public record GetAllContratosDesarrolloQuery : IRequest<IEnumerable<Domain.Entities.ContratosDesarrollo>>;

internal sealed class GetAllContratosDesarrolloQueryHandler : IRequestHandler<GetAllContratosDesarrolloQuery, IEnumerable<Domain.Entities.ContratosDesarrollo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllContratosDesarrolloQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.ContratosDesarrollo>> Handle(GetAllContratosDesarrolloQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.ContratosDesarrollo>().GetAllAsync();
    }
}
