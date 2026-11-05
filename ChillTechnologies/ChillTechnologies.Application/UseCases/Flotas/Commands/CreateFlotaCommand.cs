using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Flotas.Commands;

public record CreateFlotaCommand : IRequest<int>
{
    public int EmpresaId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
}

internal sealed class CreateFlotaCommandHandler : IRequestHandler<CreateFlotaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlotaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateFlotaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Flota
        {
            EmpresaId = request.EmpresaId,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Flota>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
