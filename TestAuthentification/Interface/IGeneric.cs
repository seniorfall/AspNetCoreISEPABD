namespace TestAuthentification.Interface
{
    public interface IGeneric<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetById(int id);

        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
    }
}
