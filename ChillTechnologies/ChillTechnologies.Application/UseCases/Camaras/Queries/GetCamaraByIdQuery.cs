using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Camaras.Queries;

public record GetCamaraByIdQuery(int Id) : IRequest<Domain.Entities.Camara>;

internal sealed class GetCamaraByIdQueryHandler : IRequestHandler<GetCamaraByIdQuery, Domain.Entities.Camara>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCamaraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Camara> Handle(GetCamaraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Camara>().GetByIdAsync(request.Id))!;
    }
}
