using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MetodosPago.Queries;

public record GetMetodoPagoByIdQuery(int Id) : IRequest<Domain.Entities.MetodosPago>;

internal sealed class GetMetodoPagoByIdQueryHandler : IRequestHandler<GetMetodoPagoByIdQuery, Domain.Entities.MetodosPago>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMetodoPagoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.MetodosPago> Handle(GetMetodoPagoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.MetodosPago>().GetByIdAsync(request.Id))!;
    }
}
