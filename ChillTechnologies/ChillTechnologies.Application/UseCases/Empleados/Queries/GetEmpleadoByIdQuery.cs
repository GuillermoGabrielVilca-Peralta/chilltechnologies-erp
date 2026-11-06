using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empleados.Queries;

public record GetEmpleadoByIdQuery(int Id) : IRequest<Domain.Entities.Empleado>;

internal sealed class GetEmpleadoByIdQueryHandler : IRequestHandler<GetEmpleadoByIdQuery, Domain.Entities.Empleado>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmpleadoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Empleado> Handle(GetEmpleadoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Empleado>().GetByIdAsync(request.Id))!;
    }
}
