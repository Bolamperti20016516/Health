using LinqToDB.Mapping;

namespace Health.Web.Models
{
    public class FitbitDevice : IHasId<string>
    {
        [PrimaryKey]
        [NotNull]
        public string Id { get; set; }

        public string AccountId { get; set; }
    }
}
