using System.Collections.Generic;

namespace Health.Web.Models
{
    public interface IMenuItem
    {
        string Text { get; set; }
    }

    public class MenuItem : IMenuItem
    {
        public string Text { get; set; }

        public string Icon { get; set; }

        public string HRef { get; set; }
    }

    public class SubMenu : IMenuItem
    {
        public string Text { get; set; }

        public IEnumerable<IMenuItem> Items { get; set; }
    }
}
