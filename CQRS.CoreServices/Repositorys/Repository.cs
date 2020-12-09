using CQRS.DatabaseEntity.Db;
using CQRS.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CoreServices.Repositorys
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = default;
        private DbSet<T> _entity = default;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public async Task<bool> CreateAsync(T item)
        {
            await _entity.AddAsync(item);
            return await SaveAsync();
        }

        public DbSet<T> Get()
        {
            return _entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            item.Id = id;
            _entity.Update(item);
            return await SaveAsync();
        }
    }
}
