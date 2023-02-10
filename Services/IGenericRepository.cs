namespace Pasteleria.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetbByIdAsync(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
