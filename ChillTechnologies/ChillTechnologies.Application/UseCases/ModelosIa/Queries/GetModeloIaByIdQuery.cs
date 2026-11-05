using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ModelosIa.Queries;

public record GetModeloIaByIdQuery(int Id) : IRequest<Domain.Entities.ModelosIum>;

internal sealed class GetModeloIaByIdQueryHandler : IRequestHandler<GetModeloIaByIdQuery, Domain.Entities.ModelosIum>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetModeloIaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ModelosIum> Handle(GetModeloIaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ModelosIum>().GetByIdAsync(request.Id))!;
    }
}
