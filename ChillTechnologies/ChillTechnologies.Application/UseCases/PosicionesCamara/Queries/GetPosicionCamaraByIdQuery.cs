using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PosicionesCamara.Queries;

public record GetPosicionCamaraByIdQuery(int Id) : IRequest<Domain.Entities.PosicionesCamara>;

internal sealed class GetPosicionCamaraByIdQueryHandler : IRequestHandler<GetPosicionCamaraByIdQuery, Domain.Entities.PosicionesCamara>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPosicionCamaraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.PosicionesCamara> Handle(GetPosicionCamaraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.PosicionesCamara>().GetByIdAsync(request.Id))!;
    }
}
