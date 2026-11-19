using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Commands;

public record UpdateUsuarioSistemaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    //igual activo inac y bloq
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateUsuarioSistemaCommandHandler : IRequestHandler<UpdateUsuarioSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsuarioSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUsuarioSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.UsuariosSistema>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Username = request.Username;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
