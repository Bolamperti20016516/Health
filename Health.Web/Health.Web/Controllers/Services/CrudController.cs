using Health.Web.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health.Web.Controllers.Services
{
    public abstract class CrudController<TEntity, TId> : BaseController
        where TEntity : class, IHasId<TId>
    {
        static readonly object Empty = new { };

        [HttpGet]
        public async Task<IEnumerable<TEntity>> Read() => await Db.GetTable<TEntity>().ToListAsync();

        [HttpGet("{id}")]
        public async Task<TEntity> Read(TId id) => await Db.GetTable<TEntity>().FirstOrDefaultAsync(c => c.Id.Equals(id));

        [HttpPost("create")]
        public async Task<object> Create([FromBody]TEntity item)
        {
            await Db.InsertAsync(item);

            return Empty;
        }

        [HttpPost("update")]
        public async Task<object> Update([FromBody]TEntity item)
        {
            // Quando la colonna "id" è editabile, la Grid Kendo invoca /update quando Id > 0.
            // Gestisco questo caso in Update facendo fallback su Create nel caso in cui il record non esista.
            var e = await Read(item.Id);
            if (e == null)
            {
                return await Create(item);
            }
            else
            {
                await Db.UpdateAsync(item);
            }

            return Empty;
        }

        [HttpPost("delete")]
        public async Task Delete([FromBody]TEntity item)
        {
            var id = item.Id;

            await Db.GetTable<TEntity>().Where(c => c.Id.Equals(id)).DeleteAsync();
        }
    }
}
