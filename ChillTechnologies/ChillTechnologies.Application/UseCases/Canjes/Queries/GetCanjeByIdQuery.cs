using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Canjes.Queries;

public record GetCanjeByIdQuery(int Id) : IRequest<Domain.Entities.Canje>;

internal sealed class GetCanjeByIdQueryHandler : IRequestHandler<GetCanjeByIdQuery, Domain.Entities.Canje>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCanjeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Canje> Handle(GetCanjeByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Canje>().GetByIdAsync(request.Id))!;
    }
}
