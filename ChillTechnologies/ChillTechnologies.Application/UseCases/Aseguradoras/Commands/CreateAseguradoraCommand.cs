using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aseguradoras.Commands;

public record CreateAseguradoraCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Ruc { get; set; }
    public string? ContactoNombre { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
}

internal sealed class CreateAseguradoraCommandHandler : IRequestHandler<CreateAseguradoraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAseguradoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAseguradoraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Aseguradora
        {
            Nombre = request.Nombre,
            Ruc = request.Ruc,
            ContactoNombre = request.ContactoNombre,
            Telefono = request.Telefono,
            Email = request.Email,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Aseguradora>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
