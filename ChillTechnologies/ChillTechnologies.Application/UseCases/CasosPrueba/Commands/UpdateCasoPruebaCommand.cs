using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CasosPrueba.Commands;

public record UpdateCasoPruebaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Precondiciones { get; set; }
    public string Pasos { get; set; } = null!;
    public string ResultadoEsperado { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public bool Automatizado { get; set; }
}

internal sealed class UpdateCasoPruebaCommandHandler : IRequestHandler<UpdateCasoPruebaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCasoPruebaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCasoPruebaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CasosPrueba>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Titulo = request.Titulo;
        item.Precondiciones = request.Precondiciones;
        item.Pasos = request.Pasos;
        item.ResultadoEsperado = request.ResultadoEsperado;
        item.Tipo = request.Tipo;
        item.Automatizado = request.Automatizado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
