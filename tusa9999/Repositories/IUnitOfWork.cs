using Party.WebApi.Interfaces;

namespace Party.WebApi.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGuestRepository Guests { get; }

        Task CommitAsync();
    }
}
