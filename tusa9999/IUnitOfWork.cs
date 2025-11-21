using Party.WebApi.Repositories;

namespace Party.WebApi
{
    public interface IUnitOfWork : IDisposable
    {
        IGuestRepository Guests { get; }

        Task CommitAsync();
    }
}
