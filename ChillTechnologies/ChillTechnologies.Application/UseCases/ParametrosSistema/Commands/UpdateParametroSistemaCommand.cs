using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ParametrosSistema.Commands;

public record UpdateParametroSistemaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Valor { get; set; } = null!;
    public string? Descripcion { get; set; }
}

internal sealed class UpdateParametroSistemaCommandHandler : IRequestHandler<UpdateParametroSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateParametroSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateParametroSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ParametrosSistema>();

        var item = await repo.GetByIdAsync(request.Id);
        
        item!.Valor = request.Valor;
        item.Descripcion = request.Descripcion;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
