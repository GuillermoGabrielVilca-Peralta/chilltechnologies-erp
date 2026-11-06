using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Clientes.Queries;

public record GetClienteByIdQuery(int Id) : IRequest<Domain.Entities.Cliente>;

internal sealed class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Domain.Entities.Cliente>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClienteByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Cliente>().GetByIdAsync(request.Id))!;
    }
}
