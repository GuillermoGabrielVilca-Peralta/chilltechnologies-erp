using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasAliado.Queries;

public record GetCategoriaAliadoByIdQuery(int Id) : IRequest<Domain.Entities.CategoriasAliado>;

internal sealed class GetCategoriaAliadoByIdQueryHandler : IRequestHandler<GetCategoriaAliadoByIdQuery, Domain.Entities.CategoriasAliado>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriaAliadoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.CategoriasAliado> Handle(GetCategoriaAliadoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.CategoriasAliado>().GetByIdAsync(request.Id))!;
    }
}
