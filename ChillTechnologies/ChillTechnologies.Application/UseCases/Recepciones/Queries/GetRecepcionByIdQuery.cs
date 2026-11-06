using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Recepciones.Queries;

public record GetRecepcionByIdQuery(int Id) : IRequest<Domain.Entities.Recepcione>;

internal sealed class GetRecepcionByIdQueryHandler : IRequestHandler<GetRecepcionByIdQuery, Domain.Entities.Recepcione>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRecepcionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Recepcione> Handle(GetRecepcionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Recepcione>().GetByIdAsync(request.Id))!;
    }
}
