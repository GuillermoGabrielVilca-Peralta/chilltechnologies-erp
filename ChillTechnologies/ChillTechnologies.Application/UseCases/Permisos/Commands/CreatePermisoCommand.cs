using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Permisos.Commands;

public record CreatePermisoCommand : IRequest<int>
{
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Modulo { get; set; } = null!;
}

internal sealed class CreatePermisoCommandHandler : IRequestHandler<CreatePermisoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePermisoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePermisoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Permiso
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Modulo = request.Modulo
        };

        await _unitOfWork.Repository<Domain.Entities.Permiso>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
