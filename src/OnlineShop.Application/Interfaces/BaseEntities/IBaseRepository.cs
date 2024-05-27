namespace OnlineShop.Application.Interfaces.BaseEntities
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T model);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> UpdateAsync();
        Task<T?> DeleteAsync(Guid id);
    }
}
