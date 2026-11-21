using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CasosPrueba.Queries;

public record GetCasoPruebaByIdQuery(int Id) : IRequest<Domain.Entities.CasosPrueba>;

internal sealed class GetCasoPruebaByIdQueryHandler : IRequestHandler<GetCasoPruebaByIdQuery, Domain.Entities.CasosPrueba>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCasoPruebaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.CasosPrueba> Handle(GetCasoPruebaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.CasosPrueba>().GetByIdAsync(request.Id))!;
    }
}
