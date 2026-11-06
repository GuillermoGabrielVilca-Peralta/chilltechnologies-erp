using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cargos.Queries;

public record GetCargoByIdQuery(int Id) : IRequest<Domain.Entities.Cargo>;

internal sealed class GetCargoByIdQueryHandler : IRequestHandler<GetCargoByIdQuery, Domain.Entities.Cargo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCargoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Cargo> Handle(GetCargoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Cargo>().GetByIdAsync(request.Id))!;
    }
}
