using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Clientes.Queries;

public record GetAllClientesQuery : IRequest<IEnumerable<Domain.Entities.Cliente>>;

internal sealed class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<Domain.Entities.Cliente>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllClientesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Cliente>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Cliente>().GetAllAsync();
    }
}
