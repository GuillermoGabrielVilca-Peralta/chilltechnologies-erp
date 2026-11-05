using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aseguradoras.Commands;

public record UpdateAseguradoraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Ruc { get; set; }
    public string? ContactoNombre { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    // Activa o Inactiva
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAseguradoraCommandHandler : IRequestHandler<UpdateAseguradoraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAseguradoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAseguradoraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Aseguradora>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Ruc = request.Ruc;
        item.ContactoNombre = request.ContactoNombre;
        item.Telefono = request.Telefono;
        item.Email = request.Email;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
