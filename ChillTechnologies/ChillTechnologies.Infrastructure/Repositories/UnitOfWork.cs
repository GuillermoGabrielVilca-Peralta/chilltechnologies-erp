using System.Collections;
using ChillTechnologies.Domain.Interfaces;
using ChillTechnologies.Infrastructure.Context;

namespace ChillTechnologies.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Hashtable? _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _repositories = new Hashtable();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        _repositories ??= new Hashtable();
        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type))
            return (IGenericRepository<TEntity>)_repositories[type]!;

        var repositoryInstance = Activator.CreateInstance(
            typeof(GenericRepository<>).MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance is null)
            throw new Exception($"No se pudo crear el repositorio para el tipo {type}");

        _repositories.Add(type, repositoryInstance);
        return (IGenericRepository<TEntity>)repositoryInstance;
    }

    public Task<int> Complete()
        => _context.SaveChangesAsync();

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
