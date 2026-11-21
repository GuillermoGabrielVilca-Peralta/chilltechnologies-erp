using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Ambientes.Queries;

public record GetAmbienteByIdQuery(int Id) : IRequest<Domain.Entities.Ambiente>;

internal sealed class GetAmbienteByIdQueryHandler : IRequestHandler<GetAmbienteByIdQuery, Domain.Entities.Ambiente>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAmbienteByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Ambiente> Handle(GetAmbienteByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Ambiente>().GetByIdAsync(request.Id))!;
    }
}
