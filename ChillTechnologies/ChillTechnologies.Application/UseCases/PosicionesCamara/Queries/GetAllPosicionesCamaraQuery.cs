using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PosicionesCamara.Queries;

public record GetAllPosicionesCamaraQuery : IRequest<IEnumerable<Domain.Entities.PosicionesCamara>>;

internal sealed class GetAllPosicionesCamaraQueryHandler : IRequestHandler<GetAllPosicionesCamaraQuery, IEnumerable<Domain.Entities.PosicionesCamara>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPosicionesCamaraQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.PosicionesCamara>> Handle(GetAllPosicionesCamaraQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.PosicionesCamara>().GetAllAsync();
    }
}
