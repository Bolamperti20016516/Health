using LinqToDB.Mapping;
using System;

namespace Health.Web.Models
{
    public class Heartbeat : IHasId<int>
    {
        [PrimaryKey]
        [NotNull]
        [Identity]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        [NotNull]
        public string DeviceId { get; set; }

        [Association(ThisKey = nameof(DeviceId), OtherKey = nameof(FitbitDevice.Id), CanBeNull = false)]
        public FitbitDevice Device { get; set; }

        [NotNull]
        public int Value { get; set; }
    }
}
