namespace CaseSolution.DAL.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
    }
}
