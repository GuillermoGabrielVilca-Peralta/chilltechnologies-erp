using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Queries;

public record GetUsuarioByIdQuery(int Id) : IRequest<Domain.Entities.Usuario>;

internal sealed class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, Domain.Entities.Usuario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsuarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Usuario> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Usuario>().GetByIdAsync(request.Id))!;
    }
}
