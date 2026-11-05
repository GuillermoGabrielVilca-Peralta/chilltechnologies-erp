using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasAliado.Queries;

public record GetAllCategoriasAliadoQuery : IRequest<IEnumerable<Domain.Entities.CategoriasAliado>>;

internal sealed class GetAllCategoriasAliadoQueryHandler : IRequestHandler<GetAllCategoriasAliadoQuery, IEnumerable<Domain.Entities.CategoriasAliado>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoriasAliadoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CategoriasAliado>> Handle(GetAllCategoriasAliadoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CategoriasAliado>().GetAllAsync();
    }
}
