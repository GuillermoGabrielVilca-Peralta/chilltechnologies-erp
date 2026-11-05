using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ReglasScoring.Commands;

public record UpdateReglaScoringCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int TipoEventoId { get; set; }
    public int ImpactoPuntaje { get; set; }
    public decimal Peso { get; set; }
    public bool Activa { get; set; }
}

internal sealed class UpdateReglaScoringCommandHandler : IRequestHandler<UpdateReglaScoringCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReglaScoringCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateReglaScoringCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ReglasScoring>();

        var regla = await repo.GetByIdAsync(request.Id);

        regla!.TipoEventoId = request.TipoEventoId;
        regla.ImpactoPuntaje = request.ImpactoPuntaje;
        regla.Peso = request.Peso;
        regla.Activa = request.Activa;

        repo.Update(regla);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
