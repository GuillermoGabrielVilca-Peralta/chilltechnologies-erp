using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aliados.Queries;

public record GetAliadoByIdQuery(int Id) : IRequest<Domain.Entities.Aliado>;

internal sealed class GetAliadoByIdQueryHandler : IRequestHandler<GetAliadoByIdQuery, Domain.Entities.Aliado>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAliadoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Aliado> Handle(GetAliadoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Aliado>().GetByIdAsync(request.Id))!;
    }
}
