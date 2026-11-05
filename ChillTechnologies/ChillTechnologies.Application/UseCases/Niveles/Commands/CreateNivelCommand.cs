using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Niveles.Commands;

public record CreateNivelCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public int PuntosMinimos { get; set; }
}

internal sealed class CreateNivelCommandHandler : IRequestHandler<CreateNivelCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNivelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateNivelCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Nivele
        {
            Nombre = request.Nombre,
            PuntosMinimos = request.PuntosMinimos,
        };

        await _unitOfWork.Repository<Domain.Entities.Nivele>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
