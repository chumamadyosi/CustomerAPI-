using CustomerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbset;
        private readonly CustomerDbContext _customerDbContext;
        public GenericRepository(CustomerDbContext context)
        {
            _customerDbContext = context;
            _dbset = _customerDbContext.Set<TEntity>();

        }
        public async Task AddAsync(TEntity entity) => await _dbset.AddAsync(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbset.ToListAsync();
        public async Task<TEntity?> GetAsync(int? id) => await _dbset.FindAsync(id);

        public async Task DeleteAsync(int id)
        {
            var record = await _dbset.FindAsync(id);
            if (record != null)
            {
                _dbset.Remove(record);
            }
        }


        public async Task SaveAsync()
        {
            await _customerDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _dbset.Attach(entity));
            _customerDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
