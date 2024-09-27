using ScholarSyncMVC.Data;

namespace ScholarSyncMVC.Repository.Contract
{
    public interface IGenericRepository<T>
    {
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        int Complet();


    }
}
