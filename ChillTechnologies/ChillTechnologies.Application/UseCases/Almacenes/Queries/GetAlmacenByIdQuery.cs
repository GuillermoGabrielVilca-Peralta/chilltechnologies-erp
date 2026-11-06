using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Almacenes.Queries;

public record GetAlmacenByIdQuery(int Id) : IRequest<Domain.Entities.Almacene>;

internal sealed class GetAlmacenByIdQueryHandler : IRequestHandler<GetAlmacenByIdQuery, Domain.Entities.Almacene>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAlmacenByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Almacene> Handle(GetAlmacenByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Almacene>().GetByIdAsync(request.Id))!;
    }
}
