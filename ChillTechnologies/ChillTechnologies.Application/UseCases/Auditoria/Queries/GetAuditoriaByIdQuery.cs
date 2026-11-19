using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Auditoria.Queries;

public record GetAuditoriaByIdQuery(int Id) : IRequest<Domain.Entities.Auditorium>;

internal sealed class GetAuditoriaByIdQueryHandler : IRequestHandler<GetAuditoriaByIdQuery, Domain.Entities.Auditorium>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuditoriaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Auditorium> Handle(GetAuditoriaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Auditorium>().GetByIdAsync(request.Id))!;
    }
}
