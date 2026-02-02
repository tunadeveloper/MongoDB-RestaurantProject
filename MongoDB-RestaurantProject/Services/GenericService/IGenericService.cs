namespace MongoDB_RestaurantProject.Services.GenericService
{
    public interface IGenericService<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(string id);
    }
}
