using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Auditoria.Queries;

public record GetAllAuditoriaQuery : IRequest<IEnumerable<Domain.Entities.Auditorium>>;

internal sealed class GetAllAuditoriaQueryHandler : IRequestHandler<GetAllAuditoriaQuery, IEnumerable<Domain.Entities.Auditorium>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAuditoriaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Auditorium>> Handle(GetAllAuditoriaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Auditorium>().GetAllAsync();
    }
}
