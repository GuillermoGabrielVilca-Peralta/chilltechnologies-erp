using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empresas.Commands;

public record DeleteEmpresaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteEmpresaCommandHandler : IRequestHandler<DeleteEmpresaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmpresaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Empresa>();

        var empresa = await repo.GetByIdAsync(request.Id);

        repo.Delete(empresa!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
