using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ContratosDesarrollo.Queries;

public record GetContratoDesarrolloByIdQuery(int Id) : IRequest<Domain.Entities.ContratosDesarrollo>;

internal sealed class GetContratoDesarrolloByIdQueryHandler : IRequestHandler<GetContratoDesarrolloByIdQuery, Domain.Entities.ContratosDesarrollo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContratoDesarrolloByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ContratosDesarrollo> Handle(GetContratoDesarrolloByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ContratosDesarrollo>().GetByIdAsync(request.Id))!;
    }
}
