using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cajas.Queries;

public record GetCajaByIdQuery(int Id) : IRequest<Domain.Entities.Caja>;

internal sealed class GetCajaByIdQueryHandler : IRequestHandler<GetCajaByIdQuery, Domain.Entities.Caja>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCajaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Caja> Handle(GetCajaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Caja>().GetByIdAsync(request.Id))!;
    }
}
