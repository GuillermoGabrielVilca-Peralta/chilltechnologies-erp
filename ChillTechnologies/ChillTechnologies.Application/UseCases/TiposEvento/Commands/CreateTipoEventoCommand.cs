using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposEvento.Commands;

public record CreateTipoEventoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public int ImpactoPuntajeDefault { get; set; }
}

internal sealed class CreateTipoEventoCommandHandler : IRequestHandler<CreateTipoEventoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoEventoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoEventoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposEvento
        {
            Nombre = request.Nombre,
            ImpactoPuntajeDefault = request.ImpactoPuntajeDefault,
        };

        await _unitOfWork.Repository<Domain.Entities.TiposEvento>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
