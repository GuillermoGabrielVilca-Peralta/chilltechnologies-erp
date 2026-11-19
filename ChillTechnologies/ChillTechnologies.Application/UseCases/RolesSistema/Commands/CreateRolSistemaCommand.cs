using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolesSistema.Commands;

public record CreateRolSistemaCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
}

internal sealed class CreateRolSistemaCommandHandler : IRequestHandler<CreateRolSistemaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRolSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRolSistemaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.RolesSistema
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Estado = "Activo"
        };

        await _unitOfWork.Repository<Domain.Entities.RolesSistema>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
