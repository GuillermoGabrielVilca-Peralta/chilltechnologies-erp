using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empleados.Queries;

public record GetAllEmpleadosQuery : IRequest<IEnumerable<Domain.Entities.Empleado>>;

internal sealed class GetAllEmpleadosQueryHandler : IRequestHandler<GetAllEmpleadosQuery, IEnumerable<Domain.Entities.Empleado>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmpleadosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Empleado>> Handle(GetAllEmpleadosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Empleado>().GetAllAsync();
    }
}
