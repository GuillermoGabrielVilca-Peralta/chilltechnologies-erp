using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Camaras.Commands;

public record UpdateCamaraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? DireccionIp { get; set; }
    public int PosicionId { get; set; }
    // Conectada, Desconectada o Error
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateCamaraCommandHandler : IRequestHandler<UpdateCamaraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCamaraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCamaraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Camara>();

        var camara = await repo.GetByIdAsync(request.Id);

        camara!.Nombre = request.Nombre;
        camara.DireccionIp = request.DireccionIp;
        camara.PosicionId = request.PosicionId;
        camara.Estado = request.Estado;

        repo.Update(camara);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
