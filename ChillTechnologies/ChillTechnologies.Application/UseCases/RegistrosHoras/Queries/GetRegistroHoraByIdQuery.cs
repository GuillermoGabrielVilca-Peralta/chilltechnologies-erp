using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Queries;

public record GetRegistroHoraByIdQuery(int Id) : IRequest<Domain.Entities.RegistrosHora>;

internal sealed class GetRegistroHoraByIdQueryHandler : IRequestHandler<GetRegistroHoraByIdQuery, Domain.Entities.RegistrosHora>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRegistroHoraByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.RegistrosHora> Handle(GetRegistroHoraByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.RegistrosHora>().GetByIdAsync(request.Id))!;
    }
}
