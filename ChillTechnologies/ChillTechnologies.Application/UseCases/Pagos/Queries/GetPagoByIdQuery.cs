using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pagos.Queries;

public record GetPagoByIdQuery(int Id) : IRequest<Domain.Entities.Pago>;

internal sealed class GetPagoByIdQueryHandler : IRequestHandler<GetPagoByIdQuery, Domain.Entities.Pago>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Pago> Handle(GetPagoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Pago>().GetByIdAsync(request.Id))!;
    }
}
