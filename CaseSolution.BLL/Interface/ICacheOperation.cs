namespace CaseSolution.BLL.Interface
{
    public interface ICacheOperation
    {
        T Get<T>(string key);

        void Set<T>(string key, T value);

        void Clear(string key);


    }
}
