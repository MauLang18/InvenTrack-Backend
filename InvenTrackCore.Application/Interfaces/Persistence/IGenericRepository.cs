using InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAllQueryable();
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetSelectAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    void UpdateAsync(T entity);
    Task DeleteAsync(int id);
}