using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Repositorios.Queries;

public record GetRepositorioByIdQuery(int Id) : IRequest<Domain.Entities.Repositorio>;

internal sealed class GetRepositorioByIdQueryHandler : IRequestHandler<GetRepositorioByIdQuery, Domain.Entities.Repositorio>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRepositorioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Repositorio> Handle(GetRepositorioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Repositorio>().GetByIdAsync(request.Id))!;
    }
}
