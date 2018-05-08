using LinqToDB.Mapping;

namespace Health.Web.Models
{
    public class Category : IHasId<int>
    {
        [PrimaryKey]
        [NotNull]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
