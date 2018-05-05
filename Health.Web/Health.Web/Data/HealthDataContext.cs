using Health.Web.Models;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;

namespace Health.Web.Data
{
    public class HealthDataContext : DataConnection
    {
        public HealthDataContext(IDataProvider dataProvider, string connectionString)
            : base(dataProvider, connectionString)
        { }

        public ITable<FitbitDevice> FitbitDevices => GetTable<FitbitDevice>();

        public ITable<Heartbeat> Heartbeats => GetTable<Heartbeat>();
    }
}
