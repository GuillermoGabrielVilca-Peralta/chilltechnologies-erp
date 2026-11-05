using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ModelosIa.Queries;

public record GetAllModelosIaQuery : IRequest<IEnumerable<Domain.Entities.ModelosIum>>;

internal sealed class GetAllModelosIaQueryHandler : IRequestHandler<GetAllModelosIaQuery, IEnumerable<Domain.Entities.ModelosIum>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllModelosIaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.ModelosIum>> Handle(GetAllModelosIaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.ModelosIum>().GetAllAsync();
    }
}
