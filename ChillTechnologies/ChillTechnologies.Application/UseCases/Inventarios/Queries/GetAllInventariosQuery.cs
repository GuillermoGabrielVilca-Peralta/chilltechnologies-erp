using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Inventarios.Queries;

public record GetAllInventariosQuery : IRequest<IEnumerable<Domain.Entities.Inventario>>;

internal sealed class GetAllInventariosQueryHandler : IRequestHandler<GetAllInventariosQuery, IEnumerable<Domain.Entities.Inventario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Inventario>> Handle(GetAllInventariosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Inventario>().GetAllAsync();
    }
}
