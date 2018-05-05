using LinqToDB.Data;

namespace Health.Web
{
    public interface IDataContextFactory<T>
        where T : DataConnection
    {
        T Create();
    }
}