using CQRS.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CoreServices.Repositorys
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<bool> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        DbSet<T> Get();
        Task<bool> UpdateAsync(int id, T item);
        Task<bool> SaveAsync();
    }
}
