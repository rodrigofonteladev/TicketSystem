using TicketSystem.Application.Interfaces.Persistence;

namespace TicketSystem.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}