using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aseguradoras.Queries;

public record GetAseguradoraByIdQuery(int Id) : IRequest<Domain.Entities.Aseguradora>;

internal sealed class GetAseguradoraByIdQueryHandler : IRequestHandler<GetAseguradoraByIdQuery, Domain.Entities.Aseguradora>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAseguradoraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Aseguradora> Handle(GetAseguradoraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Aseguradora>().GetByIdAsync(request.Id))!;
    }
}
