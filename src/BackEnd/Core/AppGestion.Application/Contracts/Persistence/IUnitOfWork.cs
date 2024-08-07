namespace AppGestion.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    Task CommitAsync();
    ValueTask RollBackAsync();
}